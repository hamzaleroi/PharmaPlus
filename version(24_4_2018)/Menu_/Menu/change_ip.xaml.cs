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

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour change_ip.xaml
    /// </summary>
    public partial class change_ip : Window
    {
        private SqlConnection cn = new SqlConnection(@"Data source=.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;");
        SqlCommand cmd;
        public change_ip()
        {
            InitializeComponent();
        }

        private void Con_serv_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ip_adr_serv = ip.Text;
            cn.Open();
            cmd = new SqlCommand("INSERT INTO echange (ip ) values ('" + ip.Text + "') where moi=1", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            this.Hide();
        }
        public new void Show()

        {
            this.Dispatcher.Invoke(() =>
            {
                base.Show();
            });

        }
    }
}
