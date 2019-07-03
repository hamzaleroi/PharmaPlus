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
using Menu.Properties;
using Menu;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using CCC = System.Xml.Serialization;
using System.Globalization;

namespace Menu
{
    /// <summary>
    /// Interaction logic for recherche.xaml
    /// </summary>
    public partial class recherche : Page
    {
        public string Cmd_select(string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
        {
            bool cond = (DCI != null) || (Marque != null) || (Forme != null) || (Dosage != null) || (Categorie != null) || (Effet_Therapeutique != null) || (Remboursement != null) || (Oriente != null) || (Restitue != null) || (Rupture != null);
            string commande = "SELECT * FROM " + pTableName;
            if (cond) commande += " WHERE ";
            try
            {

                if (DCI != null) commande += " DCI = '" + DCI + "' AND ";
                if (Marque != null) commande += " Marque = '" + Marque + "' AND ";
                if (Forme != null) commande += " Forme = " + Convert.ToInt32(Forme) + "  AND ";
                if (Dosage != null) commande += " Dosage = " + Convert.ToSingle(Dosage).ToString(new CultureInfo("en-US")) + "  AND ";
                if (Categorie != null) commande += " Categorie = " + Convert.ToInt32(Convert.ToBoolean(Categorie)) + "  AND ";
                if (Effet_Therapeutique != null) commande += " Effet_Therapeutique = " + Convert.ToInt32(Effet_Therapeutique) + "  AND ";
                if (Remboursement != null) commande += " Remboursement = " + Convert.ToInt32(Convert.ToBoolean(Remboursement)) + "  AND ";
                if (Oriente != null) commande += " Oriente = " + Convert.ToInt32(Convert.ToBoolean(Oriente)) + "  AND ";
                if (Restitue != null) commande += " Restitue = " + Convert.ToInt32(Convert.ToBoolean(Restitue)) + "  AND ";
                if (Rupture != null) commande += " Rupture = " + Convert.ToInt32(Convert.ToBoolean(Rupture)) + "  AND ";
                if (cond) commande = commande.Remove(commande.Length - 5);
                else commande = "SELECT * from " + pTableName;
                return commande;
            }
            catch
            {
                return null;
            }
        }
        public SqlDataReader Recherche_Med(SqlConnection cn, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
        {
            SqlDataReader reader = null;

            try
            {

                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_select(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                cn.Open();
                //Console.WriteLine("ede = " + Cmd_select(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ );
                reader = cmd.ExecuteReader();
                if (reader.HasRows) return reader;

            }
            catch (Exception ex)
            {

            }


            return reader;
        }
        public SqlDataReader recherche_forme(SqlConnection cn)
        {
            SqlDataReader reader = null;
            try
            {

                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "select * from Formes_galenique" };
                cn.Open();
                //Console.WriteLine("ede = " + Cmd_select(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ );
                reader = cmd.ExecuteReader();
                if (reader.HasRows) return reader;

            }
            catch (Exception ex)
            {

            }
            return reader;
        }
        public SqlDataReader recherche_effet(SqlConnection cn)
        {
            SqlDataReader reader = null;
            try
            {

                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "select * from Effet_therapeutique" };
                cn.Open();
                //Console.WriteLine("ede = " + Cmd_select(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ );
                reader = cmd.ExecuteReader();
                if (reader.HasRows) return reader;

            }
            catch (Exception ex)
            {

            }
            return reader;
        }
        public class medID_qunt
        {
            public String Tab_MedID { get; set; }
            public String DCI { get; set; }
            public String Marque { get; set; }
            public String Forme { get; set; }
            public String Dosage { get; set; }
            public String Effet { get; set; }
            public Boolean Remboursable { get; set; }
            public int MedID { get; set; }
            public int Quant { get; set; }
            public int Rest { get; set; }
        }
        public recherche()
        {
            InitializeComponent();
            forme_ComboBox(forme);
            effet_ComboBox(effet);
        }

        public SqlConnection Connect(string pServer, string pDatabase)
        {
            return new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
        }

        private void viewmore_Checked(object sender, RoutedEventArgs e)
        {
            grid.Visibility = (grid.Visibility == System.Windows.Visibility.Collapsed) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            the_list.Visibility = System.Windows.Visibility.Collapsed;
            aucune.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void reset_Checked(object sender, RoutedEventArgs e)
        {
            dci.Text = "";
            marque.Text = "";
            dosage.Text = "";
            remboursement.IsChecked = false;
            oriente.IsChecked = false;
            forme.SelectedItem = null;
            effet.SelectedItem = null;
            categorie.SelectedItem = null;
        }

        private void recherche_button_Click(object sender, RoutedEventArgs e)
        {
            the_list.Visibility = System.Windows.Visibility.Visible;
            aucune.Visibility = System.Windows.Visibility.Collapsed;
            the_list.ItemsSource = null;
            String DCI = dci.Text;


            string Dosage = dosage.Text;
            String Marque = marque.Text;
            object Forme = forme.SelectedValue;
            object Effet = effet.SelectedValue;
            object Categorie = categorie.SelectedIndex;
            object Remboursement = remboursement.IsChecked;
            object Oriente = oriente.IsChecked;

            string pServerName = ".\\SQLEXPRESS";
            string pDataBase = "mydb";
            string pTableName = "Tab_med";
            if (DCI == "") DCI = null;
            if (Marque == "") Marque = null;
            if (Dosage == "") Dosage = null;
            if ((int)Categorie == -1) Categorie = null;
            if (grid.Visibility == Visibility.Collapsed)
            {
                Marque = null;
                Forme = null;
                Effet = null;
                Categorie = null;
                Remboursement = null;
                Oriente = null;
                Dosage = null;
            }
            grid.Visibility = System.Windows.Visibility.Collapsed;
            //recherche.Visibility = System.Windows.Visibility.Visible;
            SqlDataReader rdr = Recherche_Med(Connect(pServerName, pDataBase), pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet, Remboursement, Oriente, null, null);

            /*
                recuperation des fomres de la base de donnée
                */
            SqlDataReader rdr1 = recherche_forme(Connect(pServerName, pDataBase));
            const int a = 40;
            String[] tab_forme = new string[a]; ;
            int m = 0;
            while (rdr1.Read())
            {
                tab_forme[m] = rdr1[1].ToString();
                m++;
            }
            /*
                  recuperation des effets de la base de donnée
             */
            SqlDataReader rdr2 = recherche_effet(Connect(pServerName, pDataBase));
            const int b = 40;
            String[] tab_effet = new string[b]; ;
            m = 0;
            while (rdr2.Read())
            {
                tab_effet[m] = rdr2[1].ToString();
                m++;
            }
            List<medID_qunt> l = new System.Collections.Generic.List<medID_qunt>();

            if (rdr == null || rdr != null && !rdr.HasRows) // medicament equivalent
            {
                SqlDataReader rdr3 = Recherche_Med(Connect(pServerName, pDataBase), pTableName, DCI, null, Forme, null, null, Effet, null, null, null, null);
                if (rdr3 == null)
                {
                    the_list.ItemsSource = l;
                    the_list.Visibility = Visibility.Collapsed;
                    MessageBox.Show("aucune resultat");
                    aucune.Visibility = Visibility.Visible;
                }
                else if (rdr3.HasRows)
                {
                    while (rdr3.Read())
                    {
                        var i = new medID_qunt();
                        i.Tab_MedID = rdr3[0].ToString();
                        i.DCI = rdr3[1].ToString();
                        i.Dosage = rdr3[4].ToString();
                        i.Marque = rdr3[2].ToString();
                        i.Rest = Convert.ToInt32(rdr3[9]);
                        if (!(rdr3[3].GetType().ToString() == "System.DBNull"))
                        {
                            i.Forme = tab_forme[(int)(rdr3[3]) - 1];

                        }
                        if (!(rdr3[6].GetType().ToString() == "System.DBNull"))
                        {
                            i.Effet = tab_effet[(int)(rdr3[6]) - 1];
                        }
                        l.Add(i);
                    }
                    the_list.ItemsSource = l;
                }

                else
                {
                    the_list.ItemsSource = l;
                    the_list.Visibility = Visibility.Collapsed;
                    MessageBox.Show("aucune resultat");
                    aucune.Visibility = Visibility.Visible;
                }
            }
            else
            {
                while (rdr.Read())
                {
                    var i = new medID_qunt();
                    i.Tab_MedID = rdr[0].ToString();
                    i.DCI = rdr[1].ToString();
                    i.Dosage = rdr[4].ToString();
                    i.Marque = rdr[2].ToString();
                    i.Rest = Convert.ToInt32(rdr[9]);
                    if (!(rdr[3].GetType().ToString() == "System.DBNull"))
                    {
                        i.Forme = tab_forme[(int)(rdr[3]) - 1];

                    }
                    if (!(rdr[6].GetType().ToString() == "System.DBNull"))
                    {
                        i.Effet = tab_effet[(int)(rdr[6]) - 1];
                    }
                    l.Add(i);

                }
                the_list.ItemsSource = l;
            }
            dci.Text = "";
            marque.Text = "";
            dosage.Text = "";
            remboursement.IsChecked = false;
            oriente.IsChecked = false;
            forme.SelectedItem = null;
            effet.SelectedItem = null;
            categorie.SelectedItem = null;
        }

        public void forme_ComboBox(ComboBox comboBoxName)
        {
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            SqlDataAdapter da = new SqlDataAdapter("select * from Formes_galenique", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Formes_galenique");
            comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["forme"].ToString();
            comboBoxName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
        }

        public void effet_ComboBox(ComboBox comboBoxName)
        {
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            SqlDataAdapter da = new SqlDataAdapter("select * from Effet_therapeutique", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Effet_therapeutique");
            comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["Effet_th"].ToString();
            comboBoxName.SelectedValuePath = ds.Tables[0].Columns["ID"].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem di = the_list.ContainerFromElement(sender as DependencyObject) as ListBoxItem;
            medID_qunt c = di.Content as medID_qunt;

            //MessageBox.Show(c.DCI.ToString() + c.Marque.ToString() + c.Tab_MedID.ToString() + c.Dosage.ToString());

            SqlDataReader reader = null;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            SqlCommand cmd = null;
            if (c.Rest == 0)
            {
                cmd = new SqlCommand { Connection = cn, CommandText = "select * from Tab_NEW where Tab_medID = " + c.Tab_MedID.ToString() };
            }
            else
            {
                cmd = new SqlCommand { Connection = cn, CommandText = "select * from TabRestitue where Tab_medID = " + c.Tab_MedID.ToString() };
            }
            cn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                {
                    string aff = "- DCI : " + c.DCI.ToString();
                    aff += "\n- Date de production : " + reader[1].ToString().Remove(reader[1].ToString().Length - 9);
                    aff += "\n- Date de peremption : " + reader[2].ToString().Remove(reader[2].ToString().Length - 9);
                    aff += "\n- Stock : " + reader[3].ToString();
                    aff += "\n- Prix : " + reader[4].ToString();

                    Label l1 = new Label();
                    BrushConverter k = new BrushConverter();
                    l1.BorderThickness = new Thickness(1);
                    l1.BorderBrush = (Brush)k.ConvertFrom("#FF000000");
                    l1.Background = (Brush)k.ConvertFrom("AliceBlue");
                    l1.Foreground = (Brush)k.ConvertFrom("#FF151922");
                    l1.FontWeight = FontWeights.DemiBold;
                    l1.FontSize = 15;
                    l1.FontStyle = FontStyles.Italic;
                    l1.Margin = new Thickness(2, 2, 2, 5);
                    l1.Content = aff;
                    plus_infos.Children.Add(l1);
                    bool zz = plus.IsOpen;
                    plus.IsOpen = true;
                    MainWindow.GetWindow(this).IsEnabled = false;
                    //plus.Visibility = System.Windows.Visibility.Visible;
                }

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            plus.IsOpen = false;
            MainWindow.GetWindow(this).IsEnabled = true;
            plus_infos.Children.Clear();
            //plus_infos.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
