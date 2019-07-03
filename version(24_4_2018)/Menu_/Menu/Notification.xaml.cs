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
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        private SqlConnection conn = new SqlConnection(@"Data source=.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;");
        public String type_notif, id_med;
        public Notification()
        {
            InitializeComponent();
        }

        private void supprim_notif_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            SqlCommand cmd_notif;
            if (type_notif == "5" || type_notif == "6")                                         
                cmd_notif = new SqlCommand("UPDATE Tab_notification SET Type_notif=-" + type_notif + " WHERE [Marque] = '"+ marque.Content +"' and [Type] = '"+ dci.Content +"' and Type_notif=" + type_notif, conn);
            else
                cmd_notif = new SqlCommand("UPDATE Tab_notification SET Type_notif=-" + type_notif + " WHERE med_id=" + id_med + " and Type_notif=" + type_notif, conn);
            conn.Open();
            SqlDataReader rd_notif = cmd_notif.ExecuteReader();
            conn.Close();
        }
    }
}