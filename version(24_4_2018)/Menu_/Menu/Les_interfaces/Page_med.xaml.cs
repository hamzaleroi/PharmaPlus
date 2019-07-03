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
    /// Logique d'interaction pour Page_med.xaml
    /// </summary>
    public partial class Page_med : Page
    {


        private string DCI;
        private string marque;
        private int forme;
        private float dosage;
        private Boolean restitue;
        private int quant;
        private double prix;
        object map = new Dictionary<int, String>();
        
        SqlCommand cmd;
        SqlDataReader dr = null;
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
        public Page_med()
        {   
        cn.Open();
            InitializeComponent();
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
            restit.SelectedItem = none;
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
                bool exist = false, choix = true;
                int id = 0;
                cn.Open();
                DCI = DCItextbox.Text;
                marque = Marquetextbox.Text;
                dosage = Int32.Parse(Dosagetextbox.Text);
                quant = Int32.Parse(Quanttextbox.Text);

                foreach (var kvp in ((Dictionary<int, String>)map))
                {
                    if ((kvp.Value != null) && (kvp.Value.Equals(Forme_combobox.SelectedValue.ToString())))
                    {
                        forme = kvp.Key;
                        break;
                    }

                }
                if (restit.SelectedItem.ToString().Equals(rest.ToString())) restitue = true;
                if (restit.SelectedItem.ToString().Equals(non_rest.ToString())) restitue = false;
                if (restit.SelectedItem.ToString().Equals(none.ToString()))
                {
                    choix = false;
                    restitue = false;
                }
                cmd = new SqlCommand("Select * From Tab_med  where DCI='" + DCI + "'  and marque='" + marque + "' and forme=" + forme + " and dosage=" + dosage, cn);
                dr = cmd.ExecuteReader();
                exist = false;
                if (dr.Read())
                {
                    id = Convert.ToInt32(dr[0].ToString());
                }
                dr.Close();
                if (id != 0)
                {
                    foreach (Listview_content element in Window1.list_inf)
                    {
                        if ((element.id == id)&&(element.Medicament==true))
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                    {
                        if (choix)
                        {
                            if (!restitue)
                            {
                                prix =Window1.db.Stock_suffi("Tab_NEW", id, quant);
                            }
                            else
                            {
                                prix = Window1.db.Stock_suffi("TabRestitue", id, quant);
                            }

                            if (prix != -1)
                            {
                                if (Saisir_facture.modifier)
                                {
                                    //foreach (Up_Del elem in list_stock)
                                    //{
                                    //    if (elem.Id == Saisir_facture.id_mod)
                                    //    {
                                    //        list_stock.Remove(elem);
                                    //        break;
                                    //    }
                                    //}
                                    foreach (Listview_content elem in Window1.list_inf)
                                    {
                                        if ((elem.ID == Saisir_facture.id_mod)&& (elem.Medicament == true))
                                        {
                                            Window1.list_inf.Remove(elem);
                                            break;
                                        }
                                    }
                                }

                                //list_stock.Add(new Up_Del(id, quant, restitue));
                                Listview_content med_inf = new Listview_content();
                                med_inf.marque = marque;
                                med_inf.prix = prix;
                                med_inf.quant = quant;
                                med_inf.medicament = true;
                                 med_inf.restitue = restitue;
                                med_inf.id = id;
                                Window1.list_inf.Add(med_inf);


                            }
                            else
                            {
                                MessageBox.Show("Quantité insuffisante !!");
                            }
                        }
                        else
                        {
                            prix = Window1.db.Stock_suffi("Tab_NEW", id, quant);

                            if (prix != -1)
                            {
                                if (Saisir_facture.modifier)
                                {
                                    Window1.list_inf.Remove(Saisir_facture.a_modifie);
                                }
                                Listview_content med_inf = new Listview_content();
                                med_inf.marque = marque;
                                med_inf.prix = prix;
                                med_inf.quant = quant;
                                med_inf.medicament = true;
                                med_inf.id = id;
                                med_inf.restitue = false ;
                                Window1.list_inf.Add(med_inf);
                            }
                            else
                            {
                                prix = Window1.db.Stock_suffi("TabRestitue", id, quant);
                                if (prix != -1)
                                {
                                    if (Saisir_facture.modifier)
                                    {
                                        Window1.list_inf.Remove(Saisir_facture.a_modifie);
                                    }
                                    //list_stock.Add(new Up_Del(id, quant, restitue));
                                    Listview_content med_inf = new Listview_content();
                                    med_inf.marque = marque;
                                    med_inf.prix = prix;
                                    med_inf.quant = quant;
                                    med_inf.medicament = true;
                                    med_inf.id = id;
                                    med_inf.restitue = true;
                                    Window1.list_inf.Add(med_inf);
                                }
                                else
                                {
                                    MessageBox.Show("Quantité insuffisante !!");
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vous avez déjà insérer ce médicament !!! ");
                    }
                }
                else
                {
                    MessageBox.Show("Médicament n'existe pas !!");
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
            reinitialiser(0, 0, "Non");
        }

        public void reinitialiser(int id, int quant, string restitue)
        {
            if (id != 0)
            {
                if (restitue.Equals("Oui"))
                    restit.SelectedItem = rest;
                else restit.SelectedItem = non_rest;
                cn.Open();
                cmd = new SqlCommand("Select * From Tab_med  where Tab_MedID = '" + id + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    DCItextbox.Text = dr["DCI"].ToString();
                    Marquetextbox.Text = dr["Marque"].ToString();
                    Dosagetextbox.Text = dr["Dosage"].ToString();
                    Quanttextbox.Text = quant.ToString();
                    Forme_combobox.SelectedIndex = Convert.ToInt32(dr["Forme"].ToString()) - 1;
                }
                cn.Close();
            }
            else
            {
                DCItextbox.Text = "";
                Marquetextbox.Text = "";
                Dosagetextbox.Text = "";
                Quanttextbox.Text = "";
                restit.SelectedItem = none;
                Forme_combobox.SelectedIndex = 0;
            }
        }
    }
}
