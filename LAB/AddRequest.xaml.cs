using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LAB
{
    public partial class AddRequest : Window
    {
        private int PortNumberHidden = 3000;
        private string IpHidden = "127.0.0.1";
        private string ClientUsername;
        private string ClientIp;
        private int ClientPort;
        private MainWindow CreatorHidden;

        public string PortNumber { get { return PortNumberHidden.ToString(); } set { PortNumberHidden = int.Parse(value); } }
        public string Ip { get { return IpHidden; } set { IpHidden = value; } }

        public AddRequest(string username, string ip, int port, MainWindow creator)
        {
            InitializeComponent();
            this.DataContext = this;
            ClientUsername = username;
            ClientIp = ip;
            ClientPort = port;
            CreatorHidden = creator;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            ClientHandler CH = new ClientHandler(ClientUsername, IpHidden, PortNumberHidden);
            CH.establish_connection();
            if (CH.Get_Success())
            {
                CreatorHidden.SuccessfulConnection(CH);
                this.Close();
            }
        }
    }
}
