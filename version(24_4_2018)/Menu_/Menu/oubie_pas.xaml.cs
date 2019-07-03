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
    /// Logique d'interaction pour oubie_pas.xaml
    /// </summary>
    public partial class oubie_pas : Window
    {
        public oubie_pas()
        {
            InitializeComponent();

        }
        public static String ash(String p_word, String salt)
        {
            byte[] rng = System.Text.Encoding.UTF8.GetBytes(p_word + salt);
            SHA256Managed ss = new SHA256Managed();
            byte[] hash = ss.ComputeHash(rng);
            return Convert.ToBase64String(hash);
        }
        String conn_string = @"Data source=.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;  MultipleActiveResultSets=True";
        String salt;

        /*reset_password a = new reset_password();
        a.Show();*/

        private void Valider_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                String Query = "SELECT * FROM Profile WHERE UserName = '" + log_in.user + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);

                rdr = cmd.ExecuteReader();

                int count = 0;
                while (rdr.Read())
                {
                    salt = rdr[7].ToString();
                }
                rdr.Close();
                if (salt != "")
                {
                    Query = ("SELECT * FROM Profile WHERE Q1 = '" + ash(this.Q1.Password, salt) + "' and Q2 = '" + ash(this.Q2.Password, salt) + "' and Q3 = '" + ash(this.Q3.Password, salt) + "'");
                    cmd = new SqlCommand(Query, conn);

                    rdr = cmd.ExecuteReader();
                    count = 0;
                    while (rdr.Read())
                    {
                        count++;
                    }
                    if (count > 0)
                    {
                        reset_password a = new reset_password();
                        a.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERREUR !!!");
                    }
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
            Q1.Password = "";
            Q2.Password = "";
            Q3.Password = "";
        }
    }
}
