using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Device.Location;
using System.Globalization;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour info_pharm.xaml
    /// </summary>
    public partial class info_pharm : Window
    {
        private GeoCoordinateWatcher Watcher=new GeoCoordinateWatcher();
        public info_pharm()
        {   
            InitializeComponent();
            
        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.                
                if (Watcher.Position.Location.IsUnknown)
                {
                    MessageBox.Show("Cannot find location data");
                }
                else
                {
                    GeoCoordinate location = Watcher.Position.Location;
                    SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "Update echange set lat =" + location.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ", long = " + location.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + " where moi = 'true'"
                    };
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        private void pharmacie_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            
            
            Boolean est_moi = true;
            float deg = 0;
            SqlCommand cmd;



            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");


            try
            {
                string pharm = pharmacie.Text;
                string adr = adress.Text;
                int Faxe = Convert.ToInt32(fax.Text);
                int nmr = Convert.ToInt32(telephone.Text.ToString());
                cn.Open();
                cmd = new SqlCommand("INSERT INTO echange (ip , N_telephone ,nom_pharm ,adress ,FAX ,degre, moi,nb_recu) values ('" + IP.Text+"', '" + nmr + "','" + pharm + "' ,'" + adr + "' ," + Faxe + "," + deg + " ,'" + est_moi + "',"+0+")", cn);
                cmd.ExecuteNonQuery();
                // Catch the StatusChanged event.         
                Watcher.StatusChanged += Watcher_StatusChanged;
                // Start the watcher.            
                Watcher.Start();
                Regetration1 a = new Regetration1();
                a.Show();
                this.Hide();
            }
            catch
            {
            }

            finally
            {
                cn.Close();
            }
        }
    }
}
