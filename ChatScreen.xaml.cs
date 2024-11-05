using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
    public partial class ChatScreen : Window
    {
        public string send, text;
        public Thread serverThread;
        public AutoResetEvent newMessage = new AutoResetEvent(false);
        public static Queue<string> nm = new Queue<string>();
        public ChatScreen(string name)
        {
            InitializeComponent();
            send = name;
        }

        public void startServer()
        {
            Server Server = new Server(newMessage);
            serverThread = new Thread(Server.server);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

      

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                e.Handled = true; // Предотвращаем переход на новую строку
                SendButton_Click(sender, e); 
                Window_Loaded(sender, e);
            }
            while (nm.Count != 0)
            {
                string message = nm.Dequeue();
                int index = message.IndexOf(">");
                string user = message.Substring(0, index);
                string new_text = message.Substring(index + 1);
                SendMessage(user, new_text);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Focus();
        }

        public void SendMessage(string sender, string message)
        {
            MessagesList.Items.Add(new ChatMessage { Sender = sender, Message = message });
            MessagesList.ScrollIntoView(MessagesList.Items[MessagesList.Items.Count - 1]);
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Users userList = new Users(send);
            userList.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            text = "";
            if (!string.IsNullOrEmpty(MessageBox.Text))
            {
                text = MessageBox.Text.Trim();
                Client client = new Client();
                Thread clientThread = new Thread(() => Client.client(text, send));
                clientThread.Start(); 
                newMessage.WaitOne();
                while (nm.Count != 0)
                {
                    string message = nm.Dequeue();
                    int index = message.IndexOf(">");
                    string user = message.Substring(0, index);
                    string new_text = message.Substring(index + 1);
                    SendMessage(user, new_text);    
                }   
            }

            if (!string.IsNullOrEmpty(text))
            {
                bool result = true;

                if (result)
                {
                    MessageBox.Text = "";
                }
            }
        }
    }
}
