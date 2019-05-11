using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;

namespace DataAnalyzer
{
    public class ConnectViaCOM
    {
        ThreadStart ts;
        Thread listeningThread;
        public ConnectViaCOM(ref SerialPort serialPort)
        {
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM3";
        }
        public void ListenPort(SerialPort serialPort)
        {
            OpenSerialPort(serialPort);
            if (serialPort.IsOpen)
            {
                ts = new ThreadStart(delegate ()
                {
                    while (listeningThread.ThreadState == ThreadState.Running)
                    {
                        var val = serialPort.ReadLine();
                        var dc = DataCorrection(serialPort.ReadLine());
                        DataAggregator.AggregateData(dc.Replace("°C", ""));
                    }

                });
                listeningThread = new Thread(ts);

                if(listeningThread.ThreadState == ThreadState.Suspended)
                    listeningThread.Resume();
                else
                    listeningThread.Start();
            }
        }
        public void StopListeningPort(SerialPort serialPort)
        {
            listeningThread.Suspend();
            serialPort.Close();
        }
        private string DataCorrection(string data)
        {
            data = data.Replace("\r", "°C");
            data = Regex.Match(data, @"(\w{1,2}\.\w{2}°C)").ToString();
            return data;
        }
        private void OpenSerialPort(SerialPort serialPort)
        {
            try
            {
                serialPort.Open();
            }
            catch
            {
                MessageBox.Show("Device is not available!");
            }
        }
    }
}
