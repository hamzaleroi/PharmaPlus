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

namespace Menu
{
    /// <summary>
    /// Interaction logic for BilanDeVente.xaml
    /// </summary>
    public partial class BilanDeVente : Page
    {
        public BilanDeVente()
        {
            InitializeComponent();
            Setter2_Initialized(null, null);
            Setter3_Initialized(null, null);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chart.container.Visibility = (chart.container.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed;
            var x = arrowbutton.Template;
            ;
        }
        void Setter2_Initialized(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=true;Initial Catalog=mydb");
            con.Open();
            SqlCommand com = new SqlCommand("select SUM(Quantite*Prix) from Tab_NEW_STAT where Convert(Date,DateDeVente) = Convert(Date,getDate())", con);
            var reader = com.ExecuteReader();
            double val = 0;
            if (reader.HasRows)
            {
                reader.Read();
                try
                {
                    object o = reader[0];
                    val = (double)reader[0];

                }
                catch (Exception ex)
                {
                    //	MessageBox.Show(ex.ToString());
                }
            }
            reader.Close();
            com.CommandText = "select SUM(Quantite*Prix) from TabRestitue_STAT where Convert(Date,DateDeVente) = Convert(Date,getDate())";
            reader = com.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                try
                {
                    val = (double)reader[0];
                }
                catch
                {

                }
            }
            con.Close();
            setter2.icon.Icon = FontAwesome.WPF.FontAwesomeIcon.Money;
            setter2.title.Content = "Interet";
            setter2.number.Content = val + " DA";

            setter2.number.FontSize = (((String)setter2.number.Content).Length > 8) ? ((String)setter2.number.Content).Length / 8 * 30 : 30;
        }
        void Setter3_Initialized(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=true;Initial Catalog=mydb");
            con.Open();
            SqlCommand com = new SqlCommand("select SUM(Quantite) from Tab_NEW_STAT where Convert(Date,DateDeVente) = Convert(Date,getDate())", con);
            var reader = com.ExecuteReader();
            int val = 0;
            if (reader.HasRows)
            {
                reader.Read();
                try
                {
                    object o = reader[0];
                    val = (int)reader[0];

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
            reader.Close();
            com.CommandText = "select SUM(Quantite) from TabRestitue_STAT where Convert(Date,DateDeVente) = Convert(Date,getDate())";
            reader = com.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                try
                {
                    val = (int)reader[0];
                }
                catch
                {

                }
            }
            con.Close();
            setter3.number.Content = val;
        }
    }
}