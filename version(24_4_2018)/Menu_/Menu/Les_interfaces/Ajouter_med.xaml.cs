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
using System.Data.SqlClient;
using DataLibrary;

namespace facture
{
    /// <summary>
    /// Logique d'interaction pour Ajouter_med.xaml
    /// </summary>
    public partial class Ajouter_med : Page
    {
        object map_forme = new Dictionary<int, String>();
        object map_effet = new Dictionary<int, String>();
        Tab_Med med;
        SqlCommand cmd;
        SqlDataReader dr = null;
        Database db = new Database();
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
        public Ajouter_med()
        {
            InitializeComponent();
            cn.Open();
            cmd = new SqlCommand("Select * From Formes_galenique ", cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((Dictionary<int, String>)map_forme).Add(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
                Forme.Items.Add(dr[1].ToString());
            }

            dr.Close();
            cmd = new SqlCommand("Select * From Effet_therapeutique ", cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((Dictionary<int, String>)map_effet).Add(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
                Effet.Items.Add(dr[1].ToString());
            }

            dr.Close();
            cn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            med = new Tab_Med();
            med.restitue =(bool) restitue.IsChecked;
          //  med.rupture = (bool)repture.IsChecked;
            med.oriente= (bool)oriente.IsChecked;
            med.remboursement = (bool)rembours.IsChecked;
            int quant = 0;
            double Prix = 0;
            int Lot = 0;
            med.dci = DCI.Text;
            
            med.marque= Nom_com.Text;
            med.Categorie = true;
            med.tab_MedID = 0;
            if (!Dosage.Text.Equals("")) med.Dosage = Convert.ToDouble(Dosage.Text);
            if (!Quantite.Text.Equals(""))  quant = Convert.ToInt32( Quantite.Text);
            if (!prix.Text.Equals(""))  Prix = Convert.ToDouble(prix.Text);
            if (!lot.Text.Equals("")) Lot = Convert.ToInt32(lot.Text);
            if (Forme.SelectedItem!=null)
            {
                foreach (var kvp in ((Dictionary<int, String>)map_forme))
                {
                    if ((kvp.Value != null) && (kvp.Value.Equals(Forme.SelectedValue.ToString())))
                    {
                        med.Forme = kvp.Key;
                        break;
                    }
                }
            }
            if(Effet.SelectedItem!=null)
            {
                foreach (var kvp in ((Dictionary<int, String>)map_effet))
                {
                    if ((kvp.Value != null) && (kvp.Value.Equals(Effet.SelectedValue.ToString())))
                    {
                        med.effet_Therapeutique = kvp.Key;
                        break;
                    }
                }
            }
            dr = med.Recherche_Med(cn, "Tab_med");
            if (dr.Read())
            {
                med.tab_MedID = Convert.ToInt32(dr[0].ToString());
            }
                
            dr.Close();
            if (med.tab_MedID!=0)
            {
                DateTime? selected_date_prod = date_prod.SelectedDate;
                DateTime? selected_date_perom = date_peromp.SelectedDate;
                if ((selected_date_prod.HasValue) && (selected_date_perom.HasValue))
                {
                    string formated = selected_date_prod.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string formated2 = selected_date_perom.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    if (med.restitue)
                    {
                        db.Incr_Stock("TabRestitue", med.tab_MedID, quant, Convert.ToDateTime(formated), Convert.ToDateTime(formated2), Prix,Lot);
                    }
                    else
                        db.Incr_Stock("Tab_NEW", med.tab_MedID, quant, Convert.ToDateTime(formated), Convert.ToDateTime(formated2), Prix,Lot);

                    //med.Insertion_Med(cn, "Tab_med");
                    MessageBox.Show("Médicament inséré avec succé ");
                }
                else
                {
                    MessageBox.Show("Inserer Les dates de péremption et de production de médicament !!!", "ERREUR !");
                }
                cn.Close();
            }
            else
            {
                cn.Close();
                med.Insertion_Med(cn, "Tab_med");
                cn.Close();
                dr = med.Recherche_Med(cn, "Tab_med");
                if (dr.Read())
                {
                    
                    med.tab_MedID = Convert.ToInt32(dr[0].ToString());
                }
                    
                dr.Close();
                DateTime? selected_date_prod = date_prod.SelectedDate;
                DateTime? selected_date_perom = date_prod.SelectedDate;
                if ((selected_date_prod.HasValue) && (selected_date_perom.HasValue))
                {
                    string formated = selected_date_prod.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string formated2 = selected_date_perom.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    cn.Close();
                    if (med.restitue)
                    {
                         db.Incr_Stock("TabRestitue", med.tab_MedID, quant, Convert.ToDateTime(formated), Convert.ToDateTime(formated2), Prix,Lot).ToString();
                        
                    }
                    else
                        db.Incr_Stock("Tab_NEW", med.tab_MedID, quant, Convert.ToDateTime(formated), Convert.ToDateTime(formated2), Prix,Lot).ToString();
                    
                    MessageBox.Show("Médicament inséré avec succé ");
                }
                else
                {
                    MessageBox.Show("Inserer Les dates de péremption et de production de médicament !!!", "ERREUR !");
                }
                cn.Close();
            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DCI.Text = "";
            Nom_com.Text = "";
            date_peromp.Text = "";
            date_prod.Text = "";
            prix.Text = "";
            Quantite.Text = "";
            Dosage.Text = "";
            lot.Text="";
            Forme.Text = "";
            Effet.Text = "";
        }

        private void Nom_com_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
