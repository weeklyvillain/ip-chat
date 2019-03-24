using System;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Windows;
using System.IO;


namespace LAB
{
    class listener
    {
        public static string data = null;
        private static MainWindow owner;

        public static void StartListening(object stateInfo)
        {
            owner = (MainWindow)stateInfo;
            TcpListener server = null;
            try
            {
                Int32 port = MainWindow.PortNumber;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();

                Byte[] bytes = new Byte[2000000000];
                String data = null;

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    ClientHandler ch = new ClientHandler(client);
                    data = null;
                    NetworkStream stream = client.GetStream();
                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                        dynamic jsonData = JsonConvert.DeserializeObject(data);
                        string returnMsg = "";
                        RequestHandler(jsonData, ref returnMsg);

                        if (returnMsg != "end")
                        {
                            ch.send_message(returnMsg);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                server.Stop();
                owner.Close();
            }
            finally
            {
                server.Stop();
                owner.Close();
            }
        }
        public static void RequestHandler(dynamic jsonObj, ref string returnMessage)
        {
            switch ((string)jsonObj["type"])
            {
                case "newConnection":
                    System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show((string)jsonObj["myUser"] + " is asking to connect! " , "Connection Incoming!", System.Windows.MessageBoxButton.YesNo);
                    if (result == System.Windows.MessageBoxResult.Yes)
                    {
                        MainWindow.RemoteUser = (string)jsonObj["myUser"];
                        MainWindow.RemoteIP = (string)jsonObj["IP"];
                        MainWindow.RemotePORT = (int)jsonObj["PORT"];
                        ClientHandler ch = new ClientHandler(MainWindow.RemoteUser, MainWindow.RemoteIP, MainWindow.RemotePORT);

                        Application.Current.Dispatcher.Invoke(new Action(() => {
                            owner.SuccessfulConnection(ch);
                            MainWindow.CurrentChatMessages.Add(new MessageObject() { Who = MainWindow.RemoteUser + " connected!", Type = "text", Data = "" });
                        }));

                        returnMessage = "{'type': 'acceptedConnection', 'myUser': '" + MainWindow.UserName + "'}";
                    }
                    else
                    {
                        returnMessage = "{ 'type': 'refusedConnection'}";
                    }
                    break;
                case "message":
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        MessageObject tmpMsg = new MessageObject() { Who = MainWindow.RemoteUser, Type = "text", Data = (string)jsonObj["message"] };
                        MainWindow.CurrentChatMessages.Add(tmpMsg);
                        MainWindow.db.addToDB(tmpMsg);
                        owner.chattBox.SelectedIndex = MainWindow.CurrentChatMessages.Count - 1;
                        owner.chattBox.ScrollIntoView(owner.chattBox.SelectedItem);
                    }));

                    returnMessage = "{ 'type': 'receivedMessage'}";
                    break;
                case "image":
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        byte[] img = Convert.FromBase64String((string)jsonObj["source"]);
                        File.WriteAllBytes(System.AppDomain.CurrentDomain.BaseDirectory + "/assets/img/tmp_" + (string)jsonObj["data"], img);

                        MessageObject tmpMsg = new MessageObject() { Who = MainWindow.RemoteUser, Type = "image", Data = "tmp_" + (string)jsonObj["data"] };
                        MainWindow.CurrentChatMessages.Add(tmpMsg);
                        MainWindow.db.addToDB(tmpMsg);
                        owner.chattBox.SelectedIndex = MainWindow.CurrentChatMessages.Count - 1;
                        owner.chattBox.ScrollIntoView(owner.chattBox.SelectedItem);
                    }));

                    returnMessage = "{ 'type': 'receivedImage'}";
                    break;
                case "endConnection":
                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        MainWindow.CurrentChatMessages.Add(new MessageObject() { Who = MainWindow.RemoteUser + " disconnected!", Type = "text", Data = "" });
                        owner.chattBox.SelectedIndex = MainWindow.CurrentChatMessages.Count - 1;
                        owner.chattBox.ScrollIntoView(owner.chattBox.SelectedItem);
                        owner.sendMessage.IsEnabled = false;
                        owner.sendImage.IsEnabled = false;
                        MainWindow.connected = false;
                    }));

                    returnMessage = "end";
                    break;
                default:
                    System.Windows.MessageBox.Show("Default case");
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
