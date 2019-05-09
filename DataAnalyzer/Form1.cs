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
            SerialPort serialPort = new SerialPort();
            ConnectViaCOM COM_Conn = new ConnectViaCOM(ref serialPort);
            COM_Conn.OpenSerialPort(serialPort);
            if (serialPort.IsOpen)
            {
                while (true)
                {
                    currentTextBox.Text = COM_Conn.ListenPort(serialPort);
                    Thread.Sleep(5000);
                    DataAggregator.GenerateLog();
                }
            }


        }

        private void AuthorMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tomasz Falarz");
        }
    }
}
