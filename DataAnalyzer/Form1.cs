using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace DataAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void AuthorMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tomasz Falarz");
        }

        private void ConnComMenuItem_Click(object sender, EventArgs e)
        {
        }

        public void UpdateTextFields()
        {
            SerialPort serialPort = new SerialPort();
            ConnectViaCOM COM_Conn = new ConnectViaCOM(ref serialPort);
            COM_Conn.OpenSerialPort(serialPort);
            if (serialPort.IsOpen)
            {
                startToolStripMenuItem.Visible = false;
                stopToolStripMenuItem.Visible = true;

                while (true)
                {
                    currentTextBox.Text = COM_Conn.ListenPort(serialPort);
                    avgTextBox.Text = DataAggregator.AvgValue();
                    minTextBox.Text = DataAggregator.MinValue();
                    maxTextBox.Text = DataAggregator.MaxValue();
                }
            }
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var threadStart = new ThreadStart(UpdateTextFields);
            var thread = new Thread(threadStart);
            thread.Start();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var threadStart = new ThreadStart(UpdateTextFields);
            var thread = new Thread(threadStart);
            thread.Abort();
            stopToolStripMenuItem.Visible = false;
            startToolStripMenuItem.Visible = true;
        }
    }
}
