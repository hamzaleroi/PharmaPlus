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
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour cmd_recu.xaml
    /// </summary>
    public partial class cmd_recu : Window
    {
        SqlCommand cmd;
        SqlDataReader dr = null;
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
        string res;
        string nom_pharm;
        string adress;
        string faxe;
        string N_telephone;
        float lat;
        float lg;
        int nb_recu = 0;
        public cmd_recu()
        {
            InitializeComponent();
        }
        
        public void initialiser (string ch)
        {
            this.Dispatcher.Invoke(() =>
            {
                res =ch;
                InitializeComponent();
                String[] tab = ch.Split('/');
                nom.Text = tab[1];
                adr.Text = tab[2];
                tel.Text = tab[3];
                fax.Text = tab[4];
                dci.Text = tab[5];
                marque.Text = tab[6];
                forme.Text = tab[7];
                quant.Text = tab[8];
                dosage.Text = tab[9];
                restitue.Text = tab[10];

            });
        }

        public new void Show()

        {
            this.Dispatcher.Invoke(() =>
            {
                base.Show();
            });

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

        private void refuse_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM echange WHERE    moi = 1", cn);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                nom_pharm = dr["nom_pharm"].ToString();
                N_telephone = dr["N_telephone"].ToString();
                adress = dr["adress"].ToString();
                faxe = dr["FAX"].ToString();
                lat =float.Parse( dr["lat"].ToString());
                lg = float.Parse(dr["long"].ToString());
                nb_recu = Convert.ToInt32(dr["nb_recu"].ToString());
            }
            string request = "OUI/" + res.Split('/')[0] + "/" + nom_pharm + "/" + adress + "/" + N_telephone + "/" + faxe + "/" + res.Split('/')[5] + "/" + res.Split('/')[6] + "/" + res.Split('/')[7] + "/" + res.Split('/')[8] + "/" + res.Split('/')[9] + "/" + res.Split('/')[10]+"/"+lat + "/" + lg+"/"+ nb_recu;
            SendRequest(request);
            cn.Close();
            this.Hide();
        }
    }
}
