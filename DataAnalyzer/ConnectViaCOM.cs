using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

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
                        DataAggregator.AggregateData(val);
                    }

                });
                listeningThread = new Thread(ts);

                if (listeningThread.ThreadState == ThreadState.Suspended)
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
