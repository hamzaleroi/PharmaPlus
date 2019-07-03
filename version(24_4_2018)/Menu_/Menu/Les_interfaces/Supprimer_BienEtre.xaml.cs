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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour Supprimer_BienEtre.xaml
    /// </summary>

    public partial class Supprimer_BienEtre : Page
    {
        public List<bien_etre> list_inf = new List<bien_etre>();
        public Supprimer_BienEtre()
        {
            InitializeComponent();


        }
        private void supprimer1_Click(object sender, RoutedEventArgs e)
        {

            SqlCommand cmd;
            SqlDataReader dr = null;
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            cn.Open();
            String Marqu = marque.Text;
            String typ = type.Text;
            DateTime? selected_date = date.SelectedDate;
            string formated="";


            if (selected_date.HasValue)
            {
                formated = selected_date.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                cmd = new SqlCommand("select * from Bien_etre where Marque ='" + Marqu + "' and Type ='" + typ + "' and  DateDePeremption =' " + formated + "'", cn);
            }
            else
                cmd = new SqlCommand("select * from Bien_etre where Marque ='" + Marqu + "' and Type ='" + typ +  "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bien_etre pharm_inf = new bien_etre();
                pharm_inf.Marque = dr["Marque"].ToString();
                pharm_inf.Type = dr["Type"].ToString();
                if (selected_date.HasValue)
                    pharm_inf.DateDePeremption = Convert.ToDateTime(dr["DateDePeremption"]).ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                pharm_inf.Prix = Convert.ToDouble(dr["Prix"]);
                pharm_inf.Gout = dr["Gout"].ToString();
                pharm_inf.Quantite = Convert.ToInt32(dr["Quantite"]);
                list_inf.Add(pharm_inf);
            }

            if (list_inf.Count == 0) MessageBox.Show("Produit n'existe pas !");
            else
            {
                view_bien_etre.ItemsSource = list_inf;
                dr.Close();
                if (selected_date.HasValue)
                     cmd = new SqlCommand("DELETE From Bien_etre Where Marque = '" + Marqu + "' AND Type ='" + typ + "' AND DateDePeremption ='" + formated + "' ", cn);
                else  cmd = new SqlCommand("DELETE From Bien_etre Where Marque = '" + Marqu + "' AND Type ='" + typ + "' ", cn);

                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("ERREUR ");
                else MessageBox.Show("Produit supprimé avec succé ");
            }

            cn.Close();

        }

        private void view_bien_etre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



    }
}
