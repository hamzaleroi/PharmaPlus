using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Parametre.xaml
    /// </summary>
    public partial class Parametre : Page
    {

        String conn_string = @"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ";

        public Parametre()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            String Query = "SELECT * FROM Profile WHERE UserName = '" + log_in.user + "'";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            if ((bool)rdr["Admin"] == false) gest_compt.Visibility = Visibility.Collapsed;

            rdr.Close();
            conn.Close();
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

        private void chng_nom_Click(object sender, RoutedEventArgs e)
        {
            this.Reset_Click(null, null);
            this.page_setting.Visibility = Visibility.Collapsed;
            this.page_chng_nom.Visibility = Visibility.Visible;
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            page_chng_nom.Visibility = Visibility.Collapsed;
            page_setting.Visibility = Visibility.Visible;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            pass.Password = "";
            nom.Text = "";
        }

        private void chng_pass_Click(object sender, RoutedEventArgs e)
        {
            this.Reset2_Click(null, null);
            this.page_setting.Visibility = Visibility.Collapsed;
            this.page_chng_pass.Visibility = Visibility.Visible;
        }

        private void Reset2_Click(object sender, RoutedEventArgs e)
        {
            pass2.Password = "";
            pass_conf.Password = "";
            pass_conf2.Password = "";
        }

        private void annuler2_Click(object sender, RoutedEventArgs e)
        {
            this.page_chng_pass.Visibility = Visibility.Collapsed;
            this.page_setting.Visibility = Visibility.Visible;
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            if (pass.Password == "" || nom.Text == "")
            {
                MessageBox.Show("Remplir les chapms correctement !");
            }
            else
            {
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
                        Query = "UPDATE Profile SET UserName='" + nom.Text + "' WHERE UserName = '" + log_in.user + "' and Password = '" + res + "'";
                        cmd = new SqlCommand(Query, conn);
                        rdr = cmd.ExecuteReader();
                        log_in.user = nom.Text;
                        log_in.main.user.Content = nom.Text;
                        annuler_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Le mot de pass est incorrecte !");
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void valider2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);

            if (pass2.Password == "" || pass_conf.Password == "" || pass_conf2.Password == "")
            {
                MessageBox.Show("Remplir les chapms correctement !");
            }
            else
            {
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
                    String res = ash(pass2.Password, salt);
                    Query = "SELECT * FROM Profile WHERE UserName = '" + log_in.user + "' and Password = '" + res + "'";
                    cmd = new SqlCommand(Query, conn);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        if (this.pass_conf.Password.Equals(this.pass_conf2.Password))
                        {
                            rdr.Close();
                            String Salt = CreateSalt(15);
                            String p = ash(this.pass_conf.Password, Salt);
                            Query = "UPDATE Profile SET PassWord='" + p + "' , Salt='" + Salt + "' WHERE UserName = '" + log_in.user + "' and Password = '" + res + "'";
                            cmd = new SqlCommand(Query, conn);
                            rdr = cmd.ExecuteReader();
                            annuler2_Click(null, null);
                        }
                        else MessageBox.Show("Nouveau mot de passe est incorrect !");
                    }
                    else
                    {
                        MessageBox.Show("Le mot de pass est incorrecte");
                    }
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void gest_compt_Click(object sender, RoutedEventArgs e)
        {
            list_comptes.Children.Clear();
            SqlConnection conn = new SqlConnection(conn_string);
            try
            {
                conn.Open();
                String Query = "SELECT * FROM Profile WHERE UserName != '" + log_in.user + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                Compte cmp;
                while (rdr.Read())
                {
                    cmp = new Compte();
                    cmp.Nom.Content = rdr["UserName"].ToString();
                    if ((bool)rdr["Admin"] == true)
                    {
                        cmp.make_admin.Visibility = Visibility.Collapsed;
                        cmp.delete.Visibility = Visibility.Collapsed;
                        cmp.adm.Visibility = Visibility.Visible;
                    }
                    this.list_comptes.Children.Add(cmp);
                }
                rdr.Close();
            }
            finally
            {
                conn.Close();
            }
            this.page_setting.Visibility = Visibility.Collapsed;
            this.page_gest_compt.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reset1_Click(null, null);
            this.page_add_copmte.Visibility = Visibility.Visible;
            this.page_gest_compt.Visibility = Visibility.Collapsed;
        }

        private void valider1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_string);
            SqlDataReader rdr = null;
            if (Nom.Text == "" || pass1_Copy.Password == "" || pass1.Password == "" || Q1.Password == "" || Q2.Password == "" || Q3.Password == "") MessageBox.Show("Vous n'aver pas remplir tous les champs !");
            else
            {
                if (pass1_Copy.Password.Equals(pass1.Password))
                {
                    try
                    {
                        conn.Open();
                        String Query = "SELECT* FROM Profile WHERE UserName = '" + this.Nom.Text + "'";
                        SqlCommand cmd = new SqlCommand(Query, conn);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read()) MessageBox.Show("Nom d'utilisateur existe deja !");
                        else
                        {
                            pass0.Password = "";
                            popup.IsOpen = true;
                        }
                    }
                    finally
                    {
                        rdr.Close();
                        conn.Close();
                    }
                }
                else MessageBox.Show("Mot de passe incorrect !");
            }
        }

        private void annuler1_Click(object sender, RoutedEventArgs e)
        {
            this.page_add_copmte.Visibility = Visibility.Collapsed;
            gest_compt_Click(null, null);
        }

        private void Reset1_Click(object sender, RoutedEventArgs e)
        {
            Nom.Text = "";
            pass1_Copy.Password = "";
            pass1.Password = "";
            Q1.Password = "";
            Q2.Password = "";
            Q3.Password = "";
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
                String res = ash(pass0.Password, salt);
                Query = "SELECT * FROM Profile WHERE UserName = '" + log_in.user + "' and Password = '" + res + "'";
                cmd = new SqlCommand(Query, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    rdr.Close();
                    String Salt = CreateSalt(15);
                    String p = ash(pass1_Copy.Password, Salt);
                    Query = ("INSERT INTO Profile (Admin,UserName,PassWord,Q1,Q2,Q3,Salt) Values( '" + false + "','" + this.Nom.Text + "' ,'" + p + "','" + ash(this.Q1.Password, Salt) + "','" + ash(this.Q2.Password, Salt) + "','" + ash(this.Q3.Password, Salt) + "','" + Salt + "')");
                    cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    annuler1_Click(null, null);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.page_gest_compt.Visibility = Visibility.Collapsed;
            this.page_setting.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            pass_.Password = "";
            popup_supp.IsOpen = true;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
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
                String res = ash(pass_.Password, salt);
                Query = "SELECT * FROM Profile WHERE UserName = '" + log_in.user + "' and Password = '" + res + "'";
                cmd = new SqlCommand(Query, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    rdr.Close();
                    Query = "DELETE FROM Profile WHERE [UserName] = '" + log_in.user + "'";
                    cmd = new SqlCommand(Query, conn);
                    rdr = cmd.ExecuteReader();
                    popup_supp.IsOpen = false;
                    log_in log = new log_in();
                    log.Show();
                    log_in.main.Close();
                }
                else
                {
                    MessageBox.Show("Le mot de pass est incorrecte !");
                }
                rdr.Close();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
