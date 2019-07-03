using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataLibrary;
using System.Data.SqlClient;
using facture;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour supprimer_med.xaml
    /// </summary>
    public partial class supprimer_med : Page
    {
        object map_forme = new Dictionary<int, String>();
        //object map_effet = new Dictionary<int, String>();
        Tab_Med med;
        SqlCommand cmd;
        SqlDataReader dr = null;
        Database db = new Database();
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
        public supprimer_med()
        {
            InitializeComponent();
            //date_peromp.IsEnabled = false;


            cn.Open();
            cmd = new SqlCommand("Select * From Formes_galenique ", cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((Dictionary<int, String>)map_forme).Add(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
                Forme.Items.Add(dr[1].ToString());
            }

            dr.Close();
            
            cn.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            med = new Tab_Med();
            SqlCommand cmd;
            Database db = new Database();
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            bool restitue = false;
            bool choix = false;

            if (restit.SelectedItem.ToString().Equals(rest.ToString())) restitue = true;
            if (restit.SelectedItem.ToString().Equals(non_rest.ToString())) restitue = false;
            if (restit.SelectedItem.ToString().Equals(deux.ToString()))
            {
                choix = true;
            }
            int Lot = 0;
            med.dci = DCI.Text;
            med.marque = Nom_com.Text;
            med.tab_MedID = 0;
            if (!Dosage.Text.Equals("")) med.Dosage = Convert.ToDouble(Dosage.Text);
            if (!lot.Text.Equals("")) Lot = Convert.ToInt32(lot.Text);
            if (Forme.SelectedItem != null)
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


           
            cn.Open();
            String Query = "SELECT * FROM Tab_med WHERE Marque ='" + med.marque + "' and DCI ='" + med.dci + "' and Dosage ="+ med.Dosage +" and forme = '"+med.Forme+"'";
             cmd = new SqlCommand(Query, cn);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                med.tab_MedID = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

            if (med.tab_MedID != 0)
            {
                cn.Open();
                DateTime? selected_date_perom = date_peromp.SelectedDate;

                if (selected_date_perom.HasValue)
                {
                    string formated2 = selected_date_perom.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    if(!choix)
                    {
                        if (restitue)
                        {
                            if (Lot==0)
                            {
                                cmd = new SqlCommand("DELETE From TabRestitue Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "'", cn);
                                if (cmd.ExecuteNonQuery() == 0)
                                    MessageBox.Show("Il n'y a pas un stock avec cette date de péremption ");
                                else MessageBox.Show("Médicament supprimé avec succé ");
                            }
                            else
                            {
                                cmd = new SqlCommand("DELETE From TabRestitue Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "' AND lot = '" + Lot + "'", cn);
                                if (cmd.ExecuteNonQuery() == 0)
                                    MessageBox.Show("Il n'y a pas un stock avec cette date de péremption ou ce lot ");
                                else MessageBox.Show("Médicament supprimé avec succé ");
                            }
                        }
                        else
                        {
                            if (Lot == 0)
                            {
                                cmd = new SqlCommand("DELETE From Tab_NEW Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "'", cn);
                                if (cmd.ExecuteNonQuery() == 0)
                                    MessageBox.Show("Il n'y a pas un stock avec cette date de péremption ");
                                else MessageBox.Show("Médicament supprimé avec succé ");
                            }
                                
                            else
                            {
                                cmd = new SqlCommand("DELETE From Tab_NEW Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "' AND lot = '" + Lot + "'", cn);
                                if (cmd.ExecuteNonQuery() == 0)
                                    MessageBox.Show("Il n'y a pas un stock avec cette date de péremption ou ce lot ");
                                else MessageBox.Show("Médicament supprimé avec succé ");
                            }
                                
                        }
                        
                    }
                    else
                    {
                        if (Lot == 0)
                        {
                            cmd = new SqlCommand("DELETE From TabRestitue Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "'", cn);
                            if (cmd.ExecuteNonQuery() == 0)
                                MessageBox.Show("Il n'y a pas de stock restitué avec cette date de péremption ");
                            else MessageBox.Show("Médicament supprimé avec succé ");
                        }
                        else
                        {
                            cmd = new SqlCommand("DELETE From TabRestitue Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "' AND lot = '" + Lot + "'", cn);
                            if (cmd.ExecuteNonQuery() == 0)
                                MessageBox.Show("Il n'y a pas de stock restitué avec cette date de péremption ou ce lot ");
                            else MessageBox.Show("Médicament supprimé avec succé ");
                        }

                        if (Lot == 0)
                        {
                            cmd = new SqlCommand("DELETE From Tab_NEW Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "'", cn);
                            if (cmd.ExecuteNonQuery() == 0)
                                MessageBox.Show("Il n'y a pas de nouveau stock avec cette date de péremption ");
                            else MessageBox.Show("Médicament supprimé avec succé ");
                        }

                        else
                        {
                            cmd = new SqlCommand("DELETE From Tab_NEW Where DateDePeremption = '" + formated2 + "' AND Tab_medID = '" + med.tab_MedID + "' AND lot = '" + Lot + "'", cn);
                            if (cmd.ExecuteNonQuery() == 0)
                                MessageBox.Show("Il n'y a pas de nouveau stock avec cette date de péremption ou ce lot ");
                            else MessageBox.Show("Médicament supprimé avec succé ");
                        }
                    }
                }
                else
                {
                    cmd = new SqlCommand("DELETE From TabRestitue Where Tab_medID = '" + med.tab_MedID + "'", cn);
                    int a=cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DELETE From Tab_NEW Where Tab_medID = '" + med.tab_MedID + "'", cn);
                    int b=cmd.ExecuteNonQuery();

                    if ((a==0)&&(b==0))
                        MessageBox.Show("Il n'y a pas de stock pour ce médicament  ");
                    else
                        MessageBox.Show("Médicament supprimé avec succé ");
                }
                cn.Close();

            }
            else
            {
                MessageBox.Show("Ce médicament n'existe pas !!");
            }
        }

     
            






            

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DCI.Text = "";
            Nom_com.Text = "";
            date_peromp.Text = "";
            Dosage.Text = "";
            lot.Text = "";
        }

        private void Nom_com_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
