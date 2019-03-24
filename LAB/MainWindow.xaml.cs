using System;
using System.Threading;
using System.Windows;
using System.Collections.ObjectModel;

namespace LAB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static jsonAPI db;
        private static int portNumberHidden = 3000;
        private static string ipHidden = "127.0.0.1";
        private static string userNameHidden = "Anon";
        private static string RemoteIPHidden;
        private static int RemotePORTHidden;
        private static string RemoteUserHidden;
        private static ObservableCollection<MessageObject> CurrentChatMessagesHidden = new ObservableCollection<MessageObject>();
        public static bool connected = false;
        public static ClientHandler CurrentClient;
   
        public static ObservableCollection<MessageObject> CurrentChatMessages { get { return CurrentChatMessagesHidden; } }
        public static string RemoteIP { get { return RemoteIPHidden; } set { RemoteIPHidden = value; } }
        public static int RemotePORT { get { return RemotePORTHidden; } set { RemotePORTHidden = value; } }
        public static string RemoteUser { get { return RemoteUserHidden; } set { RemoteUserHidden = value; } }
        public static int PortNumber { get { return portNumberHidden; } set { portNumberHidden = value; } }
        public static string IP { get { return ipHidden; } set { ipHidden = value; } }
        public static string UserName { get { return userNameHidden; } set { userNameHidden = value; } }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            chattGrid.Visibility = Visibility.Collapsed;
            chattBox.ItemsSource = CurrentChatMessages;
            db = new jsonAPI("/assets/db/db.json");
        }

        public void SuccessfulConnection( ClientHandler clientTmp )
        {
            connected = true;
            sendRequest.Click -= sendRequest_Click;
            sendRequest.Click += Disconnect_User_Event;
            sendRequest.Content = "Disconnect";
            CurrentClient = clientTmp;
        }

        private void Disconnect_User_Event(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sendRequest_Click(object sender, RoutedEventArgs e)
        {
            AddRequest AR = new AddRequest(userNameHidden, ipHidden, portNumberHidden, this);
            AR.Show();
        }

        private void viewHistory_Click(object sender, RoutedEventArgs e)
        {
            viewHistory vh = new viewHistory();
            vh.Show();
        }

        private void StartListen_Click(object sender, RoutedEventArgs e)
        {
            listenGrid.Visibility = Visibility.Collapsed;
            chattGrid.Visibility = Visibility.Visible;
            sendRequest.IsEnabled = true;
            ThreadPool.QueueUserWorkItem(listener.StartListening, this);

            this.Title += " - " + userNameHidden;
        }

        private void sendMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageObject tmpMsg = new MessageObject() { Who = userNameHidden, Type = "text", Data = chattTextBox.Text };
            CurrentChatMessages.Add(tmpMsg);
            db.addToDB(tmpMsg);
            chattBox.SelectedIndex = CurrentChatMessages.Count - 1;
            chattBox.ScrollIntoView(chattBox.SelectedItem);
            try
            {
                try
                {
                    CurrentClient.send_message("{'type': 'message', 'message': '" + chattTextBox.Text + "'}");
                }
                catch (NullReferenceException n)
                {
                    Console.WriteLine("NullReferenceException: {0}", e);
                    throw new ConnectionException();
                }
            }
            catch (ConnectionException ce)
            {
                Console.WriteLine("connectionException: {0}", ce);
                System.Windows.MessageBox.Show("Can't send message if not connected", "Connection Error");
            }
            chattTextBox.Text = "";
            chattTextBox.Focus();
        }

        private void sendImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.gif";
            dlg.DefaultExt = ".png";
            Nullable<bool> result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string filename = dlg.SafeFileName;
                byte[] imageArray = System.IO.File.ReadAllBytes(dlg.FileName);
                System.IO.File.Copy(dlg.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "/assets/img/" + dlg.SafeFileName, true);


                MessageObject tmpMsg = new MessageObject() { Who = userNameHidden, Type = "image", Data = dlg.SafeFileName };
                CurrentChatMessages.Add(tmpMsg);
                db.addToDB(tmpMsg);

                CurrentClient.send_image(imageArray, filename);
            }
            chattBox.SelectedIndex = CurrentChatMessages.Count - 1;
            chattBox.ScrollIntoView(chattBox.SelectedItem);
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.writeToDB();
            if (connected)
            {
                CurrentClient.Close_Connection();
                System.Windows.MessageBox.Show("You are now disconnecting!");
            }
        }

   
    }
}
