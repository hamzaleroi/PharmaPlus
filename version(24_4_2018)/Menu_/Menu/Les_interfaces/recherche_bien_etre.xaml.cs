using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Menu.Les_interfaces
{
    /// <summary>
    /// Logique d'interaction pour recherche_bien_etre.xaml
    /// </summary>
    public partial class recherche_bien_etre : Page
    {
        public recherche_bien_etre()
        {
            InitializeComponent();
        }


        //**********************************************************************************************************************
        //**********************************************************************************************************************
        public List<bien_etre> list_inf = new List<bien_etre>();
        String conn_string = @"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;";

        private void view_bien_etre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //**********************************************************************************************************************
        //**********************************************************************************************************************

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection conn = new SqlConnection(conn_string);
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                String Query = "SELECT * FROM Bien_etre WHERE Marque ='" + this.Marque.Text + "' and Type ='" + this.type.Text + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    bien_etre pharm_inf = new bien_etre();
                    pharm_inf.Marque = rdr["Marque"].ToString();
                    pharm_inf.Type = rdr["Type"].ToString();
                    pharm_inf.DateDePeremption = Convert.ToDateTime(rdr["DateDePeremption"]).ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    pharm_inf.DateDeProduction = Convert.ToDateTime(rdr["DateDeProduction"]).ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    pharm_inf.Prix = Convert.ToDouble(rdr["Prix"]);
                    pharm_inf.Gout = rdr["Gout"].ToString();
                    pharm_inf.Quantite = Convert.ToInt32(rdr["Quantite"]);



                    list_inf.Add(pharm_inf);

                }
                if (list_inf.Count == 0) MessageBox.Show("Produit n'existe pas !");
                view_bien_etre.ItemsSource = list_inf;


            }
            finally
            {
                conn.Close();

                rdr.Close();
            }

        }
    }
        }
