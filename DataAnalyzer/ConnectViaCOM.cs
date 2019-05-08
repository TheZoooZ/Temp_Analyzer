using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Text.RegularExpressions;

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
            serialPort.Open();
        }
        public string ListenPort(SerialPort serialPort)
        {
            return DataCorrection(serialPort.ReadLine());
        }
        private string DataCorrection(string data)
        {
            data = data.Replace("\r", " °C");
            return Regex.Match(data, @"(\w{2} °C)").ToString();
        }
    }
}
