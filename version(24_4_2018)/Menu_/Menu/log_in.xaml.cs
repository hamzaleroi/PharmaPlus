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
    /// Logique d'interaction pour log_in.xaml
    /// </summary>
    public partial class log_in : Window
    {
        //public static string adress_ip_serveur;
        public static String user;
        public static MainWindow main;
        public log_in()
        {
            InitializeComponent();
        }
        String conn_string = @"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ";
        public static String ash(String p_word, String salt)
        {
            byte[] rng = System.Text.Encoding.UTF8.GetBytes(p_word + salt);
            SHA256Managed ss = new SHA256Managed();
            byte[] hash = ss.ComputeHash(rng);
            return Convert.ToBase64String(hash);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /**********************************************/

            SqlConnection conn = new SqlConnection(conn_string);
            SqlDataReader rdr = null;
            String salt = "";
            try
            {
                conn.Open();
                String Query = "SELECT * FROM Profile WHERE UserName = '" + this.T_email.Text + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);

                rdr = cmd.ExecuteReader();
                int count = 0;
                while (rdr.Read())
                {
                    salt = rdr[7].ToString();
                }
                String res;
                if (salt != "")
                {
                    res = ash(T_pass.Password, salt);
                    Query = "SELECT * FROM Profile WHERE UserName = '" + this.T_email.Text + "' and Password = '" + res + "'";
                    SqlCommand cm = new SqlCommand(Query, conn);
                    if (rdr != null) rdr.Close();
                    rdr = cm.ExecuteReader();


                    while (rdr.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        //MessageBox.Show("Nom d'utilisateur et mot de passe sont corrects");
                        user = T_email.Text;
                        main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        if (count > 1)
                        {
                            MessageBox.Show("Nom d'utilisateur et mot de passe sont dupliqué !!!");
                        }
                        else
                        {
                            if (count < 1)
                            {
                                // MessageBox.Show("User name and Password are not correct");
                                Query = "SELECT * FROM Profile WHERE Username= '" + this.T_email.Text + "'";
                                SqlCommand cmd1 = new SqlCommand(Query, conn);
                                if (rdr != null) rdr.Close();
                                rdr = cmd1.ExecuteReader();
                                count = 0;
                                while (rdr.Read())
                                {
                                    count++;
                                }
                                if (count >= 1) MessageBox.Show("Le mot de passe est incorrect ! ");
                                else
                                {
                                    Query = "SELECT * FROM Profile WHERE Password = '" + this.T_pass.Password + "'";
                                    SqlCommand cmd2 = new SqlCommand(Query, conn);
                                    if (rdr != null) rdr.Close();
                                    rdr = cmd2.ExecuteReader();
                                    count = 0;
                                    while (rdr.Read())
                                    {
                                        count++;
                                    }
                                    if (count >= 1) MessageBox.Show("Le nom d'utilisateur est incorrect ! ");
                                    else
                                    {
                                        MessageBox.Show("Creez un compte ! ");
                                    }

                                }
                            }
                        }
                    }



                }
                else MessageBox.Show("Ce nom d'utilisateur n'existe pas  ! ");



            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }

        }

        private void oublie_Click(object sender, RoutedEventArgs e)
        {
            user = T_email.Text;
            oubie_pas b = new oubie_pas();
            this.Hide();

            b.Show();

        }

        private void regester_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection conn = new SqlConnection(conn_string);
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                String Query = "SELECT * FROM Profile WHERE Admin = '" + true + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);

                rdr = cmd.ExecuteReader();
                int count = 0;
                while (rdr.Read())
                {
                    count = count + 1;
                }
                if (count > 0) MessageBox.Show("Contacter l'Administrateur");
                else
                {
                    info_pharm a = new info_pharm();
                    a.Show();
                    this.Hide();
                }
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }


        }

        private void fermer_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
