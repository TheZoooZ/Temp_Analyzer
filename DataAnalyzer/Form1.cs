using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using LiveCharts;
using LiveCharts.WinForms;
using System.Drawing;
using System.Linq;
using LiveCharts.Wpf;

namespace DataAnalyzer
{
    public partial class Form1 : Form
    {
        Thread drawingThread;
        SerialPort serialPort;
        ConnectViaCOM connection;

        ChartValues<double> chartValues = new ChartValues<double>();

        Random rnd = new Random();
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
            ThreadStart startDrawing = new ThreadStart(delegate ()
            {
                while (drawingThread.ThreadState == ThreadState.Running)
                {
                    currentTextBox.Invoke(new Action(delegate ()
                    {
                        currentTextBox.Text = DataAggregator.CurrentValue() + " °C";
                        if (dispChartBtn.Checked)
                        {
                            ChartStuff();
                        }
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
                }

            });
            drawingThread = new Thread(startDrawing);
            drawingThread.Start();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.StopListeningPort(serialPort);
        }

        private void ChartStuff()
        {
            chartValues.Clear();
            chartValues.AddRange(DataAggregator.DataList.Select(x=>double.Parse(x.Value.ToString())));
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
