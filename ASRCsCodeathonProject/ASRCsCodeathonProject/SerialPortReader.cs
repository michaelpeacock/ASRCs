using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

/**
 * @Deprecated
 * 
 * Makes use of Virtual Serial Port Driver
 * which maps two serial ports as pairs so it can be read in by two programs -- this program and the Kestrel Communicator
 * unfortunately this isn't useful for interpretting data when only byte data is given..
 * 
 */
namespace ASRCsCodeathonProject
{
    class SerialPortReader
    {
        SerialPort port;

        SerialPortReader()
        {
            port = new SerialPort("COM5");
            Console.WriteLine("Attempting to read incoming Data...");
            // Attach a method to be called when there
            // is data waiting in the port's buffer 
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications 
            port.Open();
            // keeps this application running, console open
            Application.Run();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!port.IsOpen)
            {
                Console.WriteLine("Port wasn't open..");
                return;
            }
            Console.WriteLine("Reading from buffer");

            while (true)
            {
                int dataLength = port.BytesToRead;
                byte[] data = new byte[dataLength];
                int nbrDataRead = port.Read(data, 0, dataLength);

                //this won't be reading all the data, just the data that is ready to be read after the sleep timer...
                Console.WriteLine("Read Data: " + nbrDataRead);
                Thread.Sleep(500);
            }
        }

        /*public static void Main()
        {
            SerialPortReader spr = new SerialPortReader();
        }*/


    }
}
