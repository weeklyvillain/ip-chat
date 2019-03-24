using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace LAB
{
    public partial class viewHistory : Window
    {
        jsonAPI DB;
        private string SearchTxt= "";
        private static ObservableCollection<string> Users = new ObservableCollection<string>();
        private static ObservableCollection<MessageObject> ChatMessages = new ObservableCollection<MessageObject>();

        public static ObservableCollection<MessageObject> OldChatMessages { get { return ChatMessages; } set
            {
                ChatMessages = value;
            }
        }
        public static ObservableCollection<string> UserList { get { return Users; }  }
        public string SearchText { get { return SearchTxt; } set { SearchTxt = value; } }

        public viewHistory()
        {
            InitializeComponent();
            this.DataContext = this;
            DB = MainWindow.db;
            Users = DB.Search("");       
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            UsersBox.ItemsSource = DB.Search(SearchText);
        }

        private void UsersBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                chattBox.ItemsSource = DB.GetChat(e.AddedItems[0].ToString());
            }
        }
    }
}
