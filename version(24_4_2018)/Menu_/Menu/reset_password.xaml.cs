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
    /// Logique d'interaction pour reset_password.xaml
    /// </summary>
    public partial class reset_password : Window
    {
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

        public String user1;
        public reset_password()
        {
            InitializeComponent();
            user1 = log_in.user;

        }
        String conn_string = @"Data Source=NM19;Initial Catalog=mydb;Integrated Security = SSPI";

        private void Valider2_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection conn = new SqlConnection(conn_string);
            SqlDataReader rdr = null;
            try
            {
                if (this.pass1.Password.Equals(this.pass2.Password))
                {
                    conn.Open();
                    String Salt = CreateSalt(15);
                    String p = ash(pass1.Password, Salt);

                    String Query = ("UPDATE Profile SET PassWord = '" + p + "' , Salt= '" + Salt + "' WHERE UserName = '" + this.user1 + "'");
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Votre Mot de passe a ete reinitialiser !!");
                    log_in a = new log_in();
                    a.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Failed !!");
                }

            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            pass1.Password = "";
            pass2.Password = "";
        }
    }
}
