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
using System.Globalization;
using System.util;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour cmd_recu.xaml
    /// </summary>
    public partial class reponse_recu : Window
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
        public reponse_recu()
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
                nom.Text = tab[2];
                adr.Text = tab[3];
                tel.Text = tab[4];
                fax.Text = tab[5];
                dci.Text = tab[6];
                marque.Text = tab[7];
                forme.Text = tab[8];
                quant.Text = tab[9];
                dosage.Text = tab[10];
                restitue.Text = tab[11];

            });
        }

        public new void Show()

        {
            this.Dispatcher.Invoke(() =>
            {
                base.Show();

            });

        }

        public void effect_echange(string text)
        {
            bool exist = false;
            float nb = 0;
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM echange WHERE N_telephone = '" + res.Split('/')[4]+"'", cn);
            dr = cmd.ExecuteReader();
            if(dr.Read()) 
            {
                exist = true;
                nb=Convert.ToInt32( dr["nb_recu"].ToString());
            }
            dr.Close();
            if(exist)//incrementer
            {
                string fl = ((nb + 1 + float.Parse(res.Split('/')[14])) / 2).ToString();
                String t ="";
                StringTokenizer st = new StringTokenizer(fl, ",", false);
                while (st.hasMoreElements())
                {
                    t += st.nextElement().ToString();
                    if(!t.Contains("."))
                    t+=".";
                }
                cmd = new SqlCommand("UPDATE echange SET lat = "+ float.Parse(res.Split('/')[12]).ToString("G", CultureInfo.InvariantCulture) +" , long = "+float.Parse( res.Split('/')[13]).ToString("G", CultureInfo.InvariantCulture) + " , nb_recu = "+(nb+1) + " , degre = "+t + " WHERE N_telephone = " + res.Split('/')[4], cn);
                cmd.ExecuteNonQuery();
            }
            else // inserer une nouvelle pharmacie
            {
                cmd = new SqlCommand("INSERT INTO echange (N_telephone,nom_pharm,adress,FAX,degre,lat,long,moi,nb_recu) VALUES ( '"+ res.Split('/')[4]+"' , '"+res.Split('/')[3]+"' , '"+ res.Split('/')[2] +"' ,'"+ res.Split('/')[5] + "' ,'" + ((1+ Convert.ToInt32(res.Split('/')[13])) / 2).ToString() + "' ,'" + res.Split('/')[12] + "' ,'" + Convert.ToDouble(res.Split('/')[13]).ToString("G", CultureInfo.InvariantCulture) + "' ,'" + false+ "' ,'1')", cn);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
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
        

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
