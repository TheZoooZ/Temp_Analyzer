using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataAnalyzer
{
    public class ConnectViaCOM
    {
        public ConnectViaCOM(ref SerialPort serialPort)
        {
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM3";
        }
        public void OpenSerialPort(SerialPort serialPort)
        {
            try
            {
                serialPort.Open();
            }
            catch
            {
                MessageBox.Show("Device not available!");
            }
        }
        public string ListenPort(SerialPort serialPort)
        {
            return DataCorrection(serialPort.ReadLine());
        }
        private string DataCorrection(string data)
        {
            data = data.Replace("\r", " °C");
            data = Regex.Match(data, @"(\w{2} °C)").ToString();
            DataAggregator.AggregateData(data.Replace(" °C", ""));
            return data;
        }
    }
}
