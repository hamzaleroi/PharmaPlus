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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Menu.Les_interfaces
{
    /// <summary>
    /// Logique d'interaction pour liste_produit_categorie.xaml
    /// </summary>
    public partial class liste_produit_categorie : Page
    {
        object map = new Dictionary<int, String>();
        object map2 = new Dictionary<int, String>();
        SqlCommand cmd;
        SqlDataReader dr = null ;
        SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
        public liste_produit_categorie()
        {
            InitializeComponent();
            remplir_med();
            remplir_bien_etre();
        }
        //*********************************************************************************************************************************************************
        public void remplir_med()
        {
            StackPanel myStackPanel;
            Expander myExpander;
            TextBlock txta;
            String forme = "";
            cn.Open();
            cmd = new SqlCommand("Select * From Effet_therapeutique ", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ((Dictionary<int, String>)map).Add(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
            }
            dr.Close();
            cmd = new SqlCommand("Select * From Formes_galenique ", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ((Dictionary<int, String>)map2).Add(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
            }
            dr.Close();
            foreach (var kvp in ((Dictionary<int, String>)map))
            {
                myStackPanel = new StackPanel();
                myStackPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                myStackPanel.Margin = new Thickness(24, 8, 24, 16);
                myExpander = new Expander();
                myExpander.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                myExpander.Header = kvp.Value;
                cmd = new SqlCommand("Select * From Tab_med WHERE Effet_Therapeutique ='" + kvp.Key + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    foreach (var kvp2 in ((Dictionary<int, String>)map))
                    {
                        if ((kvp2.Value != null) && (kvp2.Key == Convert.ToInt32(dr["Forme"].ToString())))
                        {
                            forme = kvp2.Value;
                            break;
                        }

                    }
                    txta = new TextBlock();
                    txta.Text = dr["Marque"].ToString() + " ,    " + dr["DCI"].ToString() + " ,    " + forme + ",    " + dr["Dosage"].ToString();
                    myStackPanel.Children.Add(txta);
                }
                dr.Close();
                myExpander.Content = myStackPanel;
                medica.Children.Add(myExpander);
            }
            cn.Close();
        }
        //*********************************************************************************************************************************************************
        public void remplir_bien_etre()
        {
            StackPanel myStackPanel;
            Expander myExpander;
            TextBlock txta;
            List<String> lis = new List<string>();
            string type_preced="";
            cn.Open();
            cmd = new SqlCommand("Select Type From Bien_etre ", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string a = dr[0].ToString();
                lis.Add(a);
            }
            dr.Close();
            foreach (string kvp in lis)
            {
                if(!type_preced.Equals(kvp))
                {
                    myStackPanel = new StackPanel();
                    myStackPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                    myStackPanel.Margin = new Thickness(24, 8, 24, 16);
                    myExpander = new Expander();
                    myExpander.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    myExpander.Header = kvp;
                    cmd = new SqlCommand("Select * From Bien_etre WHERE Type ='" + kvp + "'", cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txta = new TextBlock();
                        txta.Text = dr["Marque"].ToString() + " ,    " + dr["Gout"].ToString() ;
                        myStackPanel.Children.Add(txta);
                    }
                    dr.Close();
                    myExpander.Content = myStackPanel;
                    bien_etre.Children.Add(myExpander);
                    type_preced = kvp;
                }
            }
            cn.Close();
        }
    }
}