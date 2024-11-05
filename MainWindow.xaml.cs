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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Chat
{
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        public static string nameUser = "";

        private void startChat(object sender, RoutedEventArgs e)
        {
            nameUser = userName.Text;
            bool check = true;

            if (nameUser.Length < 1)
            {
                MessageBox.Show("Укажите свое имя!");
                userName.Text = "";
                check = false;
            }
            if (check)
            {
                ChatScreen ChatScreen = new ChatScreen(nameUser);
                ChatScreen.Show();
                ChatScreen.startServer();
                Hide();
            }
        }
    }
}
