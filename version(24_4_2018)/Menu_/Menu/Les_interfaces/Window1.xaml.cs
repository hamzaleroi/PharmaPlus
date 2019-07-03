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
using Menu.Les_interfaces;

namespace facture
{

    public partial class Window1 : Window
    {
        public static Boolean med=true;
        public static Database db = new Database();
        public static List<Listview_content> list_inf = new List<Listview_content>();

        public Window1()
        {
            InitializeComponent();
            Main.Content = new Page_med();
            
        }

        private void click_page1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page_med();
        }
        private void click_page2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page_bien();
        }

        private void fermer_bouton(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public new void Show() 
            
        {
            
            if(med)
            {
                Main.Content = new Page_med();
            }
            else
            {
                Main.Content = new Page_bien();
            }
            base.Show();
        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.DragMove();
        }

    }
}