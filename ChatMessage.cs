using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
    internal class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public static List<string> users = new List<string>();
        public void addUser(string name)
        {
            bool check = users.Contains(name);
           if (!check)
            {
                users.Add(name);
            }
        }
    }
}