using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using facture;

namespace Menu.Les_interfaces
{
    /// <summary>
    /// Logique d'interaction pour Saisir_cmd_bien_etre.xaml
    /// </summary>
    public partial class Saisir_cmd_bien_etre : Page
    {
        int succ = 0;

        List<info_fact> list_info_fact;
        Window_cmd_bien_etre a;
        public static Boolean modifier;
        public static int id_mod;
        public static facture.Listview_content a_modifie;
        public Saisir_cmd_bien_etre()
        { 
            InitializeComponent();
            modifier = false;
            a = new Window_cmd_bien_etre();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            succ = 0;
            SqlCommand cmd;
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            try
            {

                cn.Open();
                if ((fournisseur.Text != "") && (code.Text != ""))
                {
                    list_info_fact = new List<info_fact>();
                    info_fact info = new info_fact(fournisseur.Text, Convert.ToInt32(code.Text), 0);
                    list_info_fact.Add(info);
                    if (date.Text != "")
                        cmd = new SqlCommand("Insert into Commande (fournisseur,Date,code) values('" + fournisseur.Text + "','" + date.Text + "'," + code.Text + ")", cn);
                    else
                        cmd = new SqlCommand("Insert into Commande (fournisseur,code) values('" + fournisseur.Text + "'," + code.Text + ")", cn);
                    succ = cmd.ExecuteNonQuery();
                    if (succ != 0)
                    {
                        MessageBox.Show("L'opération à finis avec succèe");
                        //Window_cmd.list_stock.Clear();
                        //fournisseur.Text = "";
                        //date.Text = "";
                        //code.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Veillez insérer tous les information du commande (Fournisseur, date et code) !!");
                }

            }
            catch
            {
                MessageBox.Show("ERREUR !! Verifiez vos saisies");
            }
            finally
            {
                cn.Close();
            }
        }

        private void Reinitialiser_Click(object sender, RoutedEventArgs e)
        {
            fournisseur.Text = "";
            date.Text = "";
            code.Text = "";
            viewMed.ItemsSource = new List<list_content_cmd>();
            a.list_inf.Clear();
            viewMed.ItemsSource = a.list_inf;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            a.Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            viewMed.ItemsSource = new List<list_content_cmd>();
            viewMed.ItemsSource = a.list_inf;
        }

        private void modifier_med(object sender, RoutedEventArgs e)
        {
            if (viewMed.SelectedItem != null)
            {
                modifier = true;
                list_content_cmd_b1_etre a_modifie = ((list_content_cmd_b1_etre)viewMed.SelectedItem);
                id_mod = (a_modifie).id;
                a.Show();
                a.reinitialiser(((list_content_cmd_b1_etre)viewMed.SelectedItem));
            }
            else MessageBox.Show("Vous devez sélectionner un produit de la liste ");
        }

        private void Supprimer_med(object sender, RoutedEventArgs e)
        {
            if (viewMed.SelectedItem != null)
            {
                a.list_inf.Remove(((list_content_cmd_b1_etre)viewMed.SelectedItem));
                viewMed.ItemsSource = new List<list_content_cmd_b1_etre>();
                viewMed.ItemsSource = a.list_inf;
            }
            else MessageBox.Show("Vous devez sélectionner un produit de la liste ");
        }


        private void imprim_Click(object sender, RoutedEventArgs e)
        {
            if (succ>0)
            {
                rapport_facture cr_facture = new rapport_facture(2,a.list_inf, list_info_fact);
                cr_facture.Show();
            }
            else
                MessageBox.Show("Vous devez valider la commande avant !!");
        }
    }
}
