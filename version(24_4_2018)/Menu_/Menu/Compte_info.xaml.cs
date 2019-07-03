using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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

namespace Menu
{
    /// <summary>
    /// Interaction logic for Compte.xaml
    /// </summary>
    public partial class Compte : UserControl
    {
        
        String conn_string = @"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ";
        public Compte()
        {
            InitializeComponent();
            
        }

       
        private static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static String ash(String p_word, String salt)
        {
            byte[] rng = System.Text.Encoding.UTF8.GetBytes(p_word + salt);
            SHA256Managed ss = new SHA256Managed();
            byte[] hash = ss.ComputeHash(rng);
            return Convert.ToBase64String(hash);
        }
        private void make_admin_Click(object sender, RoutedEventArgs e)
        {
            pass.Password = "";
            this.btn.Content = "Mettre Admin";
            popup.IsOpen = true;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            pass.Password = "";
            this.btn.Content = "Supprimer";
            popup.IsOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            try
            {
                conn.Open();
                String Query = "SELECT * FROM Profile WHERE UserName = '" + log_in.user + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                String salt;
                rdr.Read();
                salt = rdr["Salt"].ToString();
                rdr.Close();
                String res = ash(pass.Password, salt);
                Query = "SELECT * FROM Profile WHERE UserName = '" + log_in.user + "' and Password = '" + res + "'";
                cmd = new SqlCommand(Query, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    rdr.Close();
                    if (this.btn.Content == "Supprimer")
                    {
                        Query = "DELETE FROM Profile WHERE [UserName] = '" + this.Nom.Content + "'"; //"' and [Q1] = '" + this.N_Carte.Content + "' and [Q2] = '"+ this.N_CCP.Content +"' and [Q3] = '" + this.Cle_CCP.Content +"'";
                        cmd = new SqlCommand(Query, conn);
                        rdr = cmd.ExecuteReader();
                        this.Visibility = Visibility.Collapsed;
                    }
                    if (this.btn.Content == "Mettre Admin")
                    {
                        Query = "UPDATE Profile SET [Admin]=1 WHERE [UserName] = '" + this.Nom.Content + "'"; //"' and [Q1] = '" + this.N_Carte.Content + "' and [Q2] = '" + this.N_CCP.Content + "' and [Q3] = '" + this.Cle_CCP.Content + "'";
                        cmd = new SqlCommand(Query, conn);
                        rdr = cmd.ExecuteReader();
                        this.make_admin.Visibility = Visibility.Collapsed;
                        this.delete.Visibility = Visibility.Collapsed;
                        this.adm.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Le mot de pass est incorrecte !");
                }
                popup.IsOpen = false;
                rdr.Close();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}