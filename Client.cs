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

    internal class Client
    {
        public static void client(string message, string user)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;

            IPAddress broadcastAddress = IPAddress.Broadcast;
            IPEndPoint endPoint = new IPEndPoint(broadcastAddress, 1234);

            message = user + ">" + message;
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, endPoint);
            
            udpClient.Close();
        }


    }
}