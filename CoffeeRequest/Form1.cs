using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;

namespace CoffeeRequest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public string coffeeSetCups(int number)
        {
            string cupsHex = "";
            if (number <= 12 & number >= 1)
            {
                cupsHex = number.ToString("X2"); 
            }
            else
            {
                cupsHex = "01";
            }
	
            return "36" + cupsHex + "7e";
        }

        // State object for receiving data from remote device.
        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 20;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

        // The port number for the remote device.
        private const int port = 2081;

        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.
        private static String response = String.Empty;

        private static void StartClient()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // The name of the 
                // remote device is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.Resolve("esp_125e0a");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Send test data to the remote device.
                Console.Write(ConvertHexToString("35017e"));
                Send(client, new byte[]
                {
                    0x35,
                    0x02,
                    0x7e
                });
                sendDone.WaitOne();

                // Receive the response from the remote device.
                //  Receive(client);
                // receiveDone.WaitOne();

                // Write the response to the console.
                //   Console.WriteLine("Response received : {0}", response);

                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        public static string ConvertHexToString(string HexValue)
        {
            string StrValue = "";
            while (HexValue.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
                HexValue = HexValue.Substring(2, HexValue.Length - 2);
            }
            return StrValue;
        }

        static string Hex2Binary(string hexvalue)
        {
            StringBuilder binaryval = new StringBuilder();
            for (int i = 0; i < hexvalue.Length; i++)
            {
                string byteString = hexvalue.Substring(i, 1);
                byte b = Convert.ToByte(byteString, 16);
                binaryval.Append(Convert.ToString(b, 2).PadLeft(4, '0'));
            }
            return binaryval.ToString();
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, byte[] data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = data;

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnBrew_Click(object sender, EventArgs e)
        {
            
            int cups = (int)this.numCups.Value;
            int strength = (int)this.numStrength.Value;
            int warmTime = (int)this.numWarm.Value;
            int grind = (chkGrind.Checked) ?  1 : 0;
            
            try
            {
                // Establish the remote endpoint for the socket.
                // The name of the 
                // remote device is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.Resolve("esp_125e0a");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Send test data to the remote device.
                Console.Write(ConvertHexToString("35017e"));
                Send(client, StringToByteArray(coffeeStartFunc(cups,strength,grind,warmTime)));

                sendDone.WaitOne();

                // Receive the response from the remote device.
                //  Receive(client);
                // receiveDone.WaitOne();

                // Write the response to the console.
                //   Console.WriteLine("Response received : {0}", response);

                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string coffeeStartFunc(int cupsStart, int strenghtStart, int grindStart, int hotPlateTime)
        {
            string cupsHex = "";
            string strengthHex = "";
            string grindHex = "";
            string hotPlateHex = "";
            if (cupsStart <= 12 & cupsStart >= 1)
            {
                cupsHex = cupsStart.ToString("X2") ;
            }
            else
            {
                cupsHex = "01";
            }
            strenghtStart = strenghtStart - 1;
            if (strenghtStart >= 0 & strenghtStart <= 2)
            {
                strengthHex = strenghtStart.ToString("X2") ;
            }
            else
            {
                strengthHex = "00";
            }

            if (grindStart == 1)
            {
                grindHex = "01";
            }
            else
            {
                grindHex = "00";
            }

            if (hotPlateTime < 5)
            {
                hotPlateHex = "05";
            }
            else
            {
                hotPlateHex = hotPlateTime.ToString("X2") ;
            }

            return "33" + cupsHex + strengthHex + hotPlateHex + grindHex + "7e";
        }
    }
}