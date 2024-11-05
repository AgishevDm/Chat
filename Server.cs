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


//namespace Chat
//{
//    internal class Server
//    {
//        AutoResetEvent newMes;
//        public Server(AutoResetEvent newMessage)
//        {
//            newMes = newMessage;
//        }

//        //public void server()
//        //{
//        //    // Создаем UDP сокет для приема широковещательных запросов
//        //    UdpClient udpServer = new UdpClient(1234);

//        //    // Задаем адрес точки назначения для отправки ответа
//        //    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Broadcast, 1235);

//        //    while (true)
//        //    {
//        //        // Принимаем запрос от пользователя
//        //        byte[] requestData = udpServer.Receive(ref ipEndPoint);
//        //        string requestMessage = Encoding.UTF8.GetString(requestData);

//        //        //MessageBox.Show("Получен запрос: " + requestMessage);

//        //        string message = requestMessage;
//        //        ChatScreen.nm.Enqueue(message);
//        //        int index = message.IndexOf(">");
//        //        string user = message.Substring(0, index);
//        //        message = message.Substring(index + 1);
//        //        //MessageBox.Show("Добавили в очередь: " + message);
//        //        newMes.Set();
//        //        // Отправляем ответ с IP-адресом сервера
//        //        //string responseMessage = "IP-адрес сервера: " + GetLocalIPAddress();
//        //        //byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
//        //        //udpServer.Send(responseData, responseData.Length, ipEndPoint);

//        //        //MessageBox.Show("Отправлен ответ: " + responseMessage);

//        //        Application.Current.Dispatcher.Invoke(() =>
//        //        {
//        //            ChatMessage newUser = new ChatMessage();
//        //            newUser.addUser(user);
//        //        });
//        //    }
//        //}

//        public void server()
//        {
//            
//            UdpClient udpServer = new UdpClient(1234);
//            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 1234);

//            while (true)
//            {
//                byte[] data = udpServer.Receive(ref remoteEP);
//                string message = Encoding.UTF8.GetString(data);
//                ChatScreen.nm.Enqueue(message);
//                //Console.WriteLine("Получено сообщение: " + message);

//                int index = message.IndexOf(">");
//                string user = message.Substring(0, index);
//                message = message.Substring(index + 1);

//                newMes.Set();

//                // Create a new thread to handle each client request
//                ThreadPool.QueueUserWorkItem((state) =>
//                {
//                    Application.Current.Dispatcher.Invoke(() =>
//                    {
//                        ChatMessage newUser = new ChatMessage();
//                        newUser.addUser(user);
//                    });
//                });
//            }
//        }


//        // Метод для получения IP-адреса сервера
//        static string GetLocalIPAddress()
//        {
//            string localIP = "";
//            foreach (IPAddress ipAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
//            {
//                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
//                {
//                    localIP = ipAddress.ToString();
//                    break;
//                }
//            }
//            return localIP;
//        }
//    }
//}