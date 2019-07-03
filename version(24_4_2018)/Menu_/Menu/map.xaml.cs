using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Device.Location;
namespace Menu
{
    /// <summary>
    /// Interaction logic for map.xaml
    /// </summary>
    public partial class map : Page
    {
        LocationConverter locConverter = new LocationConverter();
        private GeoCoordinateWatcher Watcher;

        public map()
        {
            InitializeComponent();
            bing_map.ZoomLevel = 5;
            bing_map.IsEnabled = true;

            bing_map.ViewChangeOnFrame += new EventHandler<MapEventArgs>(map_ViewChangeOnFrame);
            //Create the watcher.
            Watcher = new GeoCoordinateWatcher();

            // Catch the StatusChanged event.
            Watcher.StatusChanged += Watcher_StatusChanged;

            // Start the watcher.
            Watcher.Start();
            add_Pushpin();

        }
        public SqlConnection Connect(string pServer, string pDatabase)
        {
            return new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
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
                    var pushpin = new Pushpin();
                    GeoCoordinate location = Watcher.Position.Location;
                    pushpin.Location = new Location(location.Latitude, location.Longitude);

                    BrushConverter k = new BrushConverter();
                    pushpin.Background = (Brush)k.ConvertFrom("Red");

                    bing_map.Children.Add(pushpin);

                    SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = cn,
                        CommandText = "Update echange set lat =" + location.Latitude.ToString("G", CultureInfo.InvariantCulture) +
                            ", long = " + location.Longitude.ToString("G", CultureInfo.InvariantCulture) + " where moi = 'true'"
                    };
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                }
            }
        }
        void add_Pushpin()
        {
            SqlDataReader reader = null;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "select * from echange" };
            cn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (!(reader[5].GetType().ToString() == "System.DBNull" || reader[6].GetType().ToString() == "System.DBNull"))
                {
                    var pushpin = new Pushpin();
                    pushpin.Location = new Location((double)reader[5], (double)reader[6]);
                    pushpin.MouseEnter += add_label;
                    pushpin.MouseLeave += no_label;
                    bing_map.Children.Add(pushpin);
                }
            }
            cn.Close();
        }

        private void no_label(object sender, MouseEventArgs e)
        {
            info.IsOpen = false;
        }

        private void add_label(object sender, MouseEventArgs e)
        {
            SqlDataReader reader = null;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "select * from echange" };
            cn.Open();
            reader = cmd.ExecuteReader();

            string name = "information inexistante";
            string adress = "information inexistante";
            double degr_echang = 0;

            var puph = (Pushpin)sender;
            double lat = puph.Location.Latitude;
            double longi = puph.Location.Longitude;

            Boolean find = false;

            while (reader.Read() && !find)
            {
                if ((double)reader[5] == lat && (double)reader[6] == longi)
                {
                    find = true;
                    name = (string)reader[1];
                    adress = (string)reader[2];
                    degr_echang = (float)reader[4];
                }
            }
            string affihcer = ("- Nom : " + name + "\n- Adresse : " + adress + "\n- Degré d'échange : " + degr_echang.ToString());
            info_label.Content = affihcer;
            info.IsOpen = true;
            info.Visibility = System.Windows.Visibility.Visible;
        }

        private void map_ViewChangeOnFrame(object sender, MapEventArgs e)
        {
            double z = bing_map.ZoomLevel;

            //Maximum Zoom 9
            if (z > 9)
            {
                bing_map.ZoomLevel = 9;
            }

            //Minimum Zoom 5
            if (z < 5)
            {
                bing_map.ZoomLevel = 5;
            }
        }
    }
}
