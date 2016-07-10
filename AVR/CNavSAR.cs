using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace navSAR {
    class CNavSAR {
        SerialPort serialPort = new SerialPort();

        Thread t;
        AutoResetEvent  ReceiveEvent;
        public CNmeaParser     NmeaParser = new CNmeaParser();

        public string ReceivedString;

        public CNavSAR() {
            t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
        }

        public void Release() {
            t.Abort();
        }

        public  void ThreadProc() {
            while(true){
                if (serialPort.IsOpen) {
                    ReceivedString = ReadPort();

                    CNmeaParser.NMEA_TERMS cmd =  NmeaParser.ParseBuffer(ReceivedString);

                    if (cmd == CNmeaParser.NMEA_TERMS.NP_TERM_NAVINS2) {
                        ReceiveEvent.Set();
                    }
                }
                Thread.Sleep(0);
            }
        }

        public bool Open(string SerialPortName){
            serialPort.PortName = SerialPortName;
            serialPort.BaudRate = 115200;
            try {
                serialPort.Open();
            } catch(Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message, "Ошибка");
                return false;
            }
            return true;
        }

        public void Close() {
            serialPort.Close();
        }

        public bool PortIsOpen() {
            return serialPort.IsOpen;
        }

        public string ReadPort() {
            return serialPort.ReadLine();
        }

        public void Initialize(ref AutoResetEvent Event) {
            ReceiveEvent = Event;
            serialPort.WriteLine("$NAVON,\r\n");
            serialPort.WriteLine("$NAVCTL1,10\r\n");
            serialPort.WriteLine("$NAVCTL2,1,1\r\n");
        }

        public void WriteCal1String(string str) {
            serialPort.WriteLine("$NAVCAL1" + str + "\r\n");          
        }

        public void WriteIdentityCal1String() {
            serialPort.WriteLine("$NAVCAL1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1\r\n");         
            //serialPort.WriteLine("$NAVCAL1,1,0,0,300,0,1,0,400,0,0,1,500,0,0,0,1\r\n");         
        }

    }
}
