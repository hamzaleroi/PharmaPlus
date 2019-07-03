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
    /// Logique d'interaction pour registration2.xaml
    /// </summary>
    public partial class registration2 : Window
    {
        public registration2()
        {
            InitializeComponent();
        }
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
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            try
            {
                conn.Open();
                String Salt = CreateSalt(15);
                String p = ash(Regetration1.pass, Salt);
                int value = 1;
                String Query = ("INSERT INTO Profile (Admin,UserName,PassWord,Q1,Q2,Q3,Salt) Values( '"+ true +"','"+ Regetration1.user + "' ,'" + p + "','" + ash(this.Q1.Password, Salt) + "','" + ash(this.Q2.Password, Salt) + "','" + ash(this.Q3.Password, Salt) + "','" + Salt + "')");
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Votre compte a été creé " + Regetration1.user);
                log_in a = new log_in();
                a.Show();
                this.Close();

            }
            finally
            {
                conn.Close();
            }

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.Q1.Password = "";
            this.Q2.Password = "";
            this.Q3.Password = "";
        }

        private void connect1_Click(object sender, RoutedEventArgs e)
        {
            log_in a = new log_in();
            a.Show();
            this.Hide();
        }
    }
}
