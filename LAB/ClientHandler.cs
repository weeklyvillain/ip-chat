using System;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace LAB
{
    public class ClientHandler
    {
        public static bool success = false;
        public static string data = null;
        private string usernameHidden;
        private string IPHidden;
        private int PortHidden;
        private TcpClient s;

        public ClientHandler(string username, string ip, int RemotePort)
        {
            usernameHidden = username;
            IPHidden = ip;
            PortHidden = RemotePort;

            try
            {
                Int32 port = PortHidden;
                TcpClient client = new TcpClient(IPHidden, port);
                s = client;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public ClientHandler(TcpClient client)
        {
            s = client;
        }

        public bool Get_Success()
        {
            return success;
        }

        public TcpClient Get_Client()
        {
            return s;
        }

        public void Close_Connection()
        {
            if (MainWindow.connected) {
                send_message("{'type': 'endConnection'}");
                s.Close();
            }
        }

        public void establish_connection()
        {
            try
            {
                Byte[] data = System.Text.Encoding.UTF8.GetBytes("{'type': 'newConnection', 'myUser': '" + usernameHidden + "', 'IP': '" + MainWindow.IP + "', 'PORT':'" + MainWindow.PortNumber + "'}");
                NetworkStream stream = s.GetStream();
                stream.Write(data, 0, data.Length);

                data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received in Establish Connection: {0}", responseData);

                dynamic jsonData = JsonConvert.DeserializeObject(responseData);
                if (jsonData["type"] == "acceptedConnection")
                {
                    MainWindow.RemoteUser = jsonData["myUser"];
                    MainWindow.RemoteIP = IPHidden;
                    MainWindow.RemotePORT = PortHidden;
                    MainWindow.CurrentChatMessages.Add(new MessageObject() { Who = MainWindow.RemoteUser + " Connected", Type = "text", Data = "" });
                    success = true;
                }
                else
                {
                    System.Windows.MessageBox.Show("Connection refused by remote user", "Connection Refused");
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NullReferenceException: {0}", e);
            }
        }

        public void send_message(string message)
        {
            try
            {
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                NetworkStream stream = s.GetStream();
                stream.Write(data, 0, data.Length);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public void send_image(byte[] img, string name)
        {
            try
            {             
                string base64Image = Convert.ToBase64String(img);
                string message = "{ 'type': 'image', 'data': '" + name + "', 'source': '"+ base64Image +"' }";
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                NetworkStream stream = s.GetStream();
                stream.Write(data, 0, data.Length);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}
