using DataLibrary;
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

namespace Menu.Les_interfaces
{
    /// <summary>
    /// Logique d'interaction pour Ajouter_b1_etre.xaml
    /// </summary>
    public partial class Ajouter_b1_etre : Page
    {
        public Ajouter_b1_etre()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DateTime? selected_date_prod = date_prod.SelectedDate;
            DateTime? selected_date_perom = date_peromp.SelectedDate;
            string formated, formated2;
            object d1 = null, d2 = null;
            if (selected_date_prod.HasValue)
            {
                formated = selected_date_prod.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                d1 = Convert.ToDateTime(formated);
            }
            else formated = null;
            if (selected_date_perom.HasValue)
            {
                formated2 = selected_date_perom.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                d2 = Convert.ToDateTime(formated2);
            }
            else formated2 = null;

            bien_etre b1_etre = new bien_etre(d1, d2, Quantite.Text, prix.Text, Marque.Text, Type.Text, main_ingred.Text, 0);
            Database datab = new Database();
            if(b1_etre.inserer()) MessageBox.Show("Produit inséré avec succès");
            else MessageBox.Show(b1_etre.ExceptionMessage);
        }//"Un ERREUR a été produit!! Réessayez s'il vous plaît"

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            date_prod.Text = "";
            date_peromp.Text = "";
            Quantite.Text = "";
            prix.Text = "";
            Marque.Text = "";
            Type.Text = "";
            main_ingred.Text = "";
        }
    }
}
