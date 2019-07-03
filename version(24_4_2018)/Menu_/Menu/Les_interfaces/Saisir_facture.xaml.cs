using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using Menu;

namespace facture
{
    /// <summary>
    /// Logique d'interaction pour Saisir_facture.xaml
    /// </summary>
    public partial class Saisir_facture : Page
    {
        List<info_fact> list_info_fact;
        Window1 a;
        Boolean valide = false;
        public static Boolean modifier;
        public static int id_mod;
        public static Listview_content a_modifie;
        public Saisir_facture()
        {
            InitializeComponent();

            a = new Window1();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {

            bool succ = true;
            SqlCommand cmd;
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            try
            {

                cn.Open();
                DateTime? selected_date = date.SelectedDate;

                if ((selected_date.HasValue) && (code.Text != ""))
                {
                    string formated = selected_date.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    if (Window1.list_inf.Count != 0)
                    {
                        list_info_fact = new List<info_fact>();
                        info_fact info = new info_fact(client.Text, Convert.ToInt32(code.Text), prix_tot());
                        list_info_fact.Add(info);
                        if (client.Text != "")
                            cmd = new SqlCommand("Insert into Facture (Client,Date,code) values('" + client.Text + "','" + formated + "'," + code.Text + ")", cn);
                        else
                            cmd = new SqlCommand("Insert into Facture (Date,code) values('" + formated + "'," + code.Text + ")", cn);

                        cmd.ExecuteNonQuery();
                        foreach (Listview_content produit in Window1.list_inf)
                        {
                            if (produit.Medicament)
                            {
                                if (produit.restitue)
                                {
                                    if (Window1.db.Dec_Stock_med("TabRestitue", produit.id, produit.Quant) == -1)
                                    {
                                        succ = false;
                                        MessageBox.Show("ERREUR");
                                        break;
                                    }
                                }
                                else
                                {
                                    if (Window1.db.Dec_Stock_med("Tab_NEW", produit.id, produit.Quant) == -1)
                                    {
                                        succ = false;
                                        MessageBox.Show("ERREUR");
                                        break;
                                    }
                                }

                            }
                            else //decrementer le stock de produit de bien etre
                            {
                                if (Window1.db.Dec_Stock_bien_etre("Bien_etre", produit.id, produit.Quant, produit.marque, produit.type, produit.comp) == -1)
                                {
                                    succ = false;
                                    MessageBox.Show("ERREUR");
                                    break;
                                }
                            }


                        }
                        if (succ)
                        {
                            MessageBox.Show("L'opération à finis avec succèe");
                            valide = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous devez insérer au moins un médicament !!");
                    }

                }
                else
                {
                    MessageBox.Show("Veillez insérer tous les information du commande (Nom, date et code) !!");
                }

            }
            finally
            {
                cn.Close();
            }
        }

        private void Reinitialiser_Click(object sender, RoutedEventArgs e)
        {
            valide = false;
            client.Text = "";
            date.Text = "";
            code.Text = "";
            prix_total.Text = "";
            viewMed.ItemsSource = new List<Listview_content>();
            Window1.list_inf.Clear();
            viewMed.ItemsSource = Window1.list_inf;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            modifier = false;
            a.Show();
        }

        private double prix_tot()
        {
            double prix = 0;
            foreach (Listview_content elem in Window1.list_inf)
            {
                prix += (elem.prix * elem.quant);
            }
            return (prix);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            viewMed.ItemsSource = new List<Listview_content>();
            viewMed.ItemsSource = Window1.list_inf;
            prix_total.Text = prix_tot().ToString();

        }


        private void Supprimer_med(object sender, RoutedEventArgs e)
        {
            if (viewMed.SelectedItem != null)
            {
                Window1.list_inf.Remove(((Listview_content)viewMed.SelectedItem));
                viewMed.ItemsSource = new List<Listview_content>();
                viewMed.ItemsSource = Window1.list_inf;
                prix_total.Text = prix_tot().ToString();
            }
            else MessageBox.Show("Vous devez sélectionner un produit de la liste ");
        }

        private void modifier_med(object sender, RoutedEventArgs e)
        {
            if (viewMed.SelectedItem != null)
            {
                modifier = true;
                Listview_content a_modifie = ((Listview_content)viewMed.SelectedItem);
                id_mod = (a_modifie).id;
                a.Show();
                if ((a_modifie).Medicament == true)
                {
                    Window1.med = true;
                }
                else
                {
                    Window1.med = false;
                }
            }
            else MessageBox.Show("Vous devez sélectionner un produit de la liste ");
        }

        private void imprim_Click(object sender, RoutedEventArgs e)
        {
            if (valide)
            {
                rapport_facture cr_facture = new rapport_facture(1, Window1.list_inf, list_info_fact);
                cr_facture.Show();
            }
            else
                MessageBox.Show("Vous devez valider l'achat avant !!");

        }
    }
}
