using DataLibrary;
using facture;
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
using System.Windows.Shapes;

namespace Menu.Les_interfaces
{
    /// <summary>
    /// Logique d'interaction pour Window_cmd_bien_etre.xaml
    /// </summary>
    public partial class Window_cmd_bien_etre : Window
    {
        private string type;
        private string marque;
        private String compo;
        private int quant;
        public List<list_content_cmd_b1_etre> list_inf = new List<list_content_cmd_b1_etre>();
        public static int id = 0;
        object map = new Dictionary<int, String>();
        public static Database db = new Database();
        SqlCommand cmd;
        SqlDataReader dr = null;
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");


        public Window_cmd_bien_etre()
        {
            InitializeComponent();
            Typetextbox.Text = "";
            Marquetextbox.Text = "";
            Compotextbox.Text = "";
            Quanttextbox.Text = "";

        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader dr = null;
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            try
            {
                bool exist = false;

                cn.Open();
                type = Typetextbox.Text;
                marque = Marquetextbox.Text;
                compo = Compotextbox.Text;
                quant = Int32.Parse(Quanttextbox.Text);
                exist = false;


                foreach (list_content_cmd_b1_etre element in list_inf)
                {
                    if ((element.compo == compo) && (element.type == type) && (element.marque == marque))
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    if (Saisir_commande.modifier)
                    {
                        foreach (list_content_cmd_b1_etre elem in list_inf)
                        {
                            if (elem.id == Saisir_commande.id_mod)
                            {
                                list_inf.Remove(elem);
                                break;
                            }
                        }
                    }
                    list_content_cmd_b1_etre med_inf = new list_content_cmd_b1_etre();
                    med_inf.marque = marque;
                    med_inf.quant = quant;
                    med_inf.type = type;
                    med_inf.compo = compo;
                    med_inf.id = id + 1;
                    id = id + 1;
                    list_inf.Add(med_inf);

                }
                else
                {
                    MessageBox.Show("Vous avez déjà commander ce produit !!! ");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (dr != null) dr.Close();
                cn.Close();
                this.Hide();
            }
        }

        private void Renitialiser_Click(object sender, RoutedEventArgs e)
        {
            Typetextbox.Text = "";
            Marquetextbox.Text = "";
            Compotextbox.Text = "";
            Quanttextbox.Text = "";
        }

        private void fermer_bouton(object sender, RoutedEventArgs e)
        {

            Typetextbox.Text = "";
            Marquetextbox.Text = "";
            Compotextbox.Text = "";
            Quanttextbox.Text = "";
            this.Hide();
        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.DragMove();
        }

        private void Renitialiser_Click_1(object sender, RoutedEventArgs e)
        {
            reinitialiser(null);
            Typetextbox.Text = "";
            Marquetextbox.Text = "";
            Compotextbox.Text = "";
            Quanttextbox.Text = "";
        }
        public void reinitialiser(list_content_cmd_b1_etre med)
        {
            if (med != null)
            {
                Typetextbox.Text = med.type;
                Marquetextbox.Text = med.marque;
                Compotextbox.Text = med.compo;
                Quanttextbox.Text = med.quant.ToString();
            }
            else
            {
                Typetextbox.Text = "";
                Marquetextbox.Text = "";
                Compotextbox.Text = "";
                Quanttextbox.Text = "";
            }
        }
    }
}
