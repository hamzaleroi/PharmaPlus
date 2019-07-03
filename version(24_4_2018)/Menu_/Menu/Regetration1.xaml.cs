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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour Regetration1.xaml
    /// </summary>
    public partial class Regetration1 : Window
    {
        public Regetration1()
        {
            InitializeComponent();
        }


        public static String user;
        public static String pass;
        private static string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        public static String ash(String p_word, String salt)
        {
            byte[] rng = System.Text.Encoding.UTF8.GetBytes(p_word + salt);
            SHA256Managed ss = new SHA256Managed();
            byte[] hash = ss.ComputeHash(rng);
            return Convert.ToBase64String(hash);


        }



        String conn_string = @"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;";

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            pass1.Password = "";
            pass1_Copy.Password = "";
            Nom.Text = "";
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                String Query = "SELECT* FROM Profile WHERE UserName = '" + this.Nom.Text + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                rdr = cmd.ExecuteReader();
                int count = 0;
                while (rdr.Read())
                {
                    count = count + 1;
                }
                if (count <= 0)
                {
                    if (this.pass1.Password.Equals(this.pass1_Copy.Password))
                    {
                        pass = pass1.Password;
                        user = Nom.Text;

                        registration2 a = new registration2();
                        a.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Mot de passe incorrect !");
                }
                else MessageBox.Show("Nom d'utilisateur existe deja !");
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
        }

        private void connect1_Click(object sender, RoutedEventArgs e)
        {
            log_in a = new log_in();
            a.Show();
            this.Hide();
        }
    }
}
