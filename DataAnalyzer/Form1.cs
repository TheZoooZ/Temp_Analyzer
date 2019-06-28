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
        ConnectViaCOM connection;


        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            connection = new ConnectViaCOM(ref serialPort);
        }
        private void AuthorMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tomasz Falarz");
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.ListenPort(serialPort);
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
                    //cartesianChart1.Invoke(new Action(delegate ()
                    //{
                    //    //chart.DrawChart(ref dispChartBtn, DataAggregator.DataList.Values.Reverse().Take(30).Reverse().ToArray());
                    //}));
                    Thread.Sleep(10000);
                }

            });
            drawingThread = new Thread(startDrawing);
            drawingThread.Start();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.StopListeningPort(serialPort);
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
