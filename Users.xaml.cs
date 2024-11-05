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
using System.Collections.ObjectModel;

namespace Chat
{
    public partial class Users : Window
    {
        public string send;
        public Users(string name)
        {
            InitializeComponent();
            send = name;
            foreach (var person in ChatMessage.users)
            {
                UsersList.Items.Add(person);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }


}
