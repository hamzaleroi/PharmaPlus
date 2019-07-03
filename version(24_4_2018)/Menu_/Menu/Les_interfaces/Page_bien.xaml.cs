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
using DataLibrary;
using facture;

namespace Menu.Les_interfaces
{
    /// <summary>
    /// Logique d'interaction pour Page_bien.xaml
    /// </summary>
    public partial class Page_bien : Page
    {

        private string type;
        private string marque;
        private string comp;
        private int quant;
        private double prix;
        
        SqlCommand cmd;
        SqlDataReader dr = null;
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");


        public Page_bien()
        {
            cn.Open();
            InitializeComponent();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader dr = null;
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            try
            {
                bool exist = false;
                int id = 0;
                cn.Open();
                marque = marquetextbox.Text;
                type = typetextbox.Text;
                comp = comptextbox.Text;
                quant = Int32.Parse(quanttextbox.Text);

                cmd = new SqlCommand("Select * From Bien_etre  where Marque='" + marque + "'  and Type='" + type + "' and Gout='" + comp + "' ORDER BY DateDePeremption ASC", cn);
                dr = cmd.ExecuteReader();
                //exist = false;
                if (dr.Read())
                {
                    id = Convert.ToInt32(dr[0].ToString());
                }
                dr.Close();
                if (id != 0)
                {
                    foreach (Listview_content element in Window1.list_inf)
                    {
                        if ((element.id == id) && (element.Medicament == false))
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                    {
                        prix = Window1.db.Stock_suffi_bien(marque, type, comp, quant);

                        if (prix != -1)
                        {
                            if (Saisir_facture.modifier)
                            {
                                foreach (Listview_content elem in Window1.list_inf)
                                {
                                    if ((elem.ID == Saisir_facture.id_mod) && (elem.Medicament == true))
                                    {
                                        Window1.list_inf.Remove(elem);
                                        break;
                                    }
                                }
                            }

                            //list_stock.Add(new Up_Del_bien(id, quant, false));
                            prix = Window1.db.Stock_suffi_bien(marque, type, comp, quant);
                            Listview_content med_inf = new Listview_content();
                            med_inf.marque = marque;
                            med_inf.type = type;
                            med_inf.prix = prix;
                            med_inf.quant = quant;
                            med_inf.id = id;
                            med_inf.comp = comp;
                            med_inf.medicament = false;
                            Window1.list_inf.Add(med_inf);



                        }
                        else
                        {
                            MessageBox.Show("Quantité insuffisante !!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vous avez déjà insérer ce produit !!! ");
                    }
                }
                else
                {
                    MessageBox.Show("produit n'existe pas !!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERREUR !!");

            }
            finally
            {
                if (dr != null) dr.Close();
                cn.Close();
            }
        }


        private void Renitialiser_Click_1(object sender, RoutedEventArgs e)
        {
            reinitialiser(0, 0);
        }

        public void reinitialiser(int id, int quant)
        {
            if (id != 0)
            {
                cn.Open();
                cmd = new SqlCommand("Select * From Bien_etre  where ID = '" + id + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    marquetextbox.Text = dr["Marque"].ToString();
                    typetextbox.Text = dr["Type"].ToString();
                    comptextbox.Text = dr["Gout"].ToString();
                    quanttextbox.Text = quant.ToString();

                }
                cn.Close();
            }
            else
            {
                marquetextbox.Text = "";
                typetextbox.Text = "";
                comptextbox.Text = "";
                quanttextbox.Text = "";

            }
        }
    }
}
