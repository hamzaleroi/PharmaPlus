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
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using DataLibrary;
using facture;

namespace Menu.Les_interfaces
{
    /// <summary>
    /// Logique d'interaction pour Window_cmd.xaml
    /// </summary>
    public partial class Window_cmd : Window
    {
        private string DCI;
        private string marque;
        private String forme;
        private float dosage;
        private int quant;
        public List<list_content_cmd> list_inf = new List<list_content_cmd>();
        public static int id = 0;
        object map = new Dictionary<int, String>();
        public static Database db = new Database();
        SqlCommand cmd;
        SqlDataReader dr = null;
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");


        public Window_cmd()
        {
            cn.Open();
            InitializeComponent();
            id = 0;
            cmd = new SqlCommand("Select * From Formes_galenique ", cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ((Dictionary<int, String>)map).Add(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
                Forme_combobox.Items.Add(dr[1].ToString());
            }
            DCItextbox.Text = "";
            Marquetextbox.Text = "";
            Dosagetextbox.Text = "";
            Quanttextbox.Text = "";
            dr.Close();
            cn.Close();

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
                DCI = DCItextbox.Text;
                marque = Marquetextbox.Text;
                dosage = Int32.Parse(Dosagetextbox.Text);
                quant = Int32.Parse(Quanttextbox.Text);


                foreach (var kvp in ((Dictionary<int, String>)map))
                {
                    if ((kvp.Value != null) && (kvp.Value.Equals(Forme_combobox.SelectedValue.ToString())))
                    {
                        forme = kvp.Value;
                        break;
                    }
                }
                exist = false;


                foreach (list_content_cmd element in list_inf)
                {
                    if ((element.forme==forme)&&(element.dosage==dosage)&&(element.dci==DCI)&&(element.marque==marque))
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    if (Saisir_commande.modifier)
                    {
                        foreach (list_content_cmd elem in list_inf)
                        {
                            if (elem.id == Saisir_commande.id_mod)
                            {
                                list_inf.Remove(elem);
                                break;
                            }
                        }
                    }
                    list_content_cmd med_inf = new list_content_cmd();
                    med_inf.marque = marque;
                    med_inf.quant = quant;
                    med_inf.Dci = DCI;
                    med_inf.Dosage = dosage;
                    med_inf.Forme = forme;
                    med_inf.id = id+1;
                    id = id + 1;
                    list_inf.Add(med_inf);

                }
                else
                {
                    MessageBox.Show("Vous avez déjà commander ce médicament !!! ");
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
            DCItextbox.Text = "";
            Marquetextbox.Text = "";
            Dosagetextbox.Text = "";
            Quanttextbox.Text = "";
        }

        private void fermer_bouton(object sender, RoutedEventArgs e)
        {
            DCItextbox.Text = "";
            Marquetextbox.Text = "";
            Dosagetextbox.Text = "";
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
            DCItextbox.Text = "";
            Marquetextbox.Text = "";
            Dosagetextbox.Text = "";
            Quanttextbox.Text = "";
        }
        public void reinitialiser(list_content_cmd med)
        {
            if (med != null)
            {
                DCItextbox.Text = med.dci;
                Marquetextbox.Text = med.marque;
                Dosagetextbox.Text = med.dosage.ToString();
                Quanttextbox.Text = med.quant.ToString();
                Forme_combobox.SelectedValue =med.forme;
            }
            else
            {
                DCItextbox.Text = "";
                Marquetextbox.Text = "";
                Dosagetextbox.Text = "";
                Quanttextbox.Text = "";
                Forme_combobox.SelectedIndex = 0;
            }
        }
    }
}
