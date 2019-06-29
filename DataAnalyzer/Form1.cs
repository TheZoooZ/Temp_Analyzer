using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DataAnalyzer
{
    public partial class Form1 : Form
    {
        Thread drawingThread;
        SerialPort serialPort;
        ConnectViaCOM comConnection;
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            comConnection = new ConnectViaCOM(ref serialPort);
        }
        public void UpdateBoxes()
        {
            var chart = new Chart(ref cartesianChart1);

            ThreadStart startDrawing = new ThreadStart(delegate ()
            {
                while (drawingThread.ThreadState == ThreadState.Running)
                {
                    currentTextBox.Invoke(new Action(delegate ()
                    {
                        currentTextBox.Text = DataAggregator.CurrentValue() + " °C";
                    }));
                    avgTextBox.Invoke(new Action(delegate ()
                    {
                        avgTextBox.Text = DataAggregator.AvgValue() + " °C";
                    }));
                    minTextBox.Invoke(new Action(delegate ()
                    {
                        minTextBox.Text = DataAggregator.MinValue() + " °C";
                    }));
                    maxTextBox.Invoke(new Action(delegate ()
                    {
                        maxTextBox.Text = DataAggregator.MaxValue() + " °C";
                    }));
                    cartesianChart1.Invoke(new Action(delegate ()
                    {
                        chart.DrawChart(ref dispChartBtn, DataAggregator.dataList.Select(x => x.Value));
                    }));
                    Thread.Sleep(10000);
                }

            });
            drawingThread = new Thread(startDrawing);
            drawingThread.Start();
        } 
        private void AuthorMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tomasz Falarz");
        }
        private void EnableCOMConnection(object sender, EventArgs e)
        {
            comConnection.ListenPort(serialPort);
            if (comConnection.Statement(serialPort))
            {
                connComMenuItem.Enabled = false;
                disableCOMConnectionToolStripMenuItem.Enabled = true;
                UpdateBoxes();
            }
        }
        private void DisableCOMConnection(object sender, EventArgs e)
        {
            comConnection.StopListeningPort(serialPort);
            disableCOMConnectionToolStripMenuItem.Enabled = false;
            connComMenuItem.Enabled = true;
        }

        private void DispChartBtn_Click(object sender, EventArgs e)
        {
            switch (dispChartBtn.Checked)
            {
                case false:
                    this.Size = new Size(468, 326);
                    cartesianChart1.Visible = true;
                    dispChartBtn.Checked = true;
                    break;
                case true:
                    this.Size = new Size(468, 120);
                    cartesianChart1.Visible = false;
                    dispChartBtn.Checked = false;
                    break;
            }

        }
    }
}
