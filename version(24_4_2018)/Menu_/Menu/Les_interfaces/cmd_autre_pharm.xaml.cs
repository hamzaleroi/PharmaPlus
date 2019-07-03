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
using System.Net.Sockets;
using System.Net;
using System.Data.SqlClient;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour cmd_autre_pharm.xaml
    /// </summary>
    public partial class cmd_autre_pharm : Page
    {
        SqlCommand cmd;
        SqlDataReader dr = null;
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
        string form;
        string rest;
        string nom_pharm;
        string adress;
        string fax;
        string N_telephone;
        public cmd_autre_pharm()
        {
            InitializeComponent();
            cn.Open();
            cmd = new SqlCommand("Select * From Formes_galenique ", cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Forme.Items.Add(dr[1].ToString());
            }

            dr.Close();
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)restitue.IsChecked)
                    rest = "oui";
                else rest = "non";
                cn.Open();
                cmd = new SqlCommand("SELECT * FROM echange WHERE    moi = 1", cn);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    nom_pharm = dr["nom_pharm"].ToString();
                    N_telephone = dr["N_telephone"].ToString();
                    adress = dr["adress"].ToString();
                    fax = dr["FAX"].ToString();
                }
                string request = GetLocalIP() + "/ " + nom_pharm + " / " + adress + " / " + N_telephone + " / " + fax + " / " + DCI.Text + " / " + Marque.Text + " / " + Forme.SelectedValue.ToString() + " / " + Quant.Text + " / " + dosage.Text + " / " + rest;
                SendRequest(request);
                MainWindow.echn = false;
                dr.Close();
                cn.Close();
            }
            catch
            {

            }
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
    }
}
