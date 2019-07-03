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
using System.Windows.Shapes;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour oui_non.xaml
    /// </summary>
    public partial class oui_non : Window
    {
        string res;
        public oui_non(string reseved)
        {
             res = reseved;
            InitializeComponent();
        }
        private static void SendRequest(string request)
        {
            SendString(request);

            if (request.ToLower() == "exit")
            {
                Exit();
            }
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            MainWindow.ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        private static void Exit()
        {
            SendString("exit"); // Tell the server we are exiting
            MainWindow.ClientSocket.Shutdown(SocketShutdown.Both);
            MainWindow.ClientSocket.Close();
            Environment.Exit(0);
        }

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return (ip.ToString());
                }
            }
            return ("127.0.0.1");
        }
        private void oui_Click(object sender, RoutedEventArgs e)
        {
            //GetLocalIP() + " / " + res.Split('/')[1] + " / " + res.Split('/')[2] + " / " + res.Split('/')[3] + " / " + res.Split('/')[4] + " / " + res.Split('/')[5] + " / " + res.Split('/')[6] + " / " + res.Split('/')[7] + " / " + res.Split('/')[8] + " / " + res.Split('/')[9] + " / " + res.Split('/')[10]
            string request ="OUI / "+ res;
            SendRequest(request);
        }

        private void non_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
