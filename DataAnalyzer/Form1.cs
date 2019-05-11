using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

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
            ThreadStart startDrawing = new ThreadStart(delegate ()
            {
                while (drawingThread.ThreadState == ThreadState.Running)
                {
                    currentTextBox.Invoke(new Action(delegate ()
                    {
                        currentTextBox.Text = DataAggregator.CurrentValue();
                    }));
                    avgTextBox.Invoke(new Action(delegate ()
                    {
                        avgTextBox.Text = DataAggregator.AvgValue();
                    }));
                    minTextBox.Invoke(new Action(delegate ()
                    {
                        minTextBox.Text = DataAggregator.MinValue();
                    }));
                    maxTextBox.Invoke(new Action(delegate ()
                    {
                        maxTextBox.Text = DataAggregator.MaxValue();
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
    }
}
