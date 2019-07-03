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
using LiveCharts;
using LiveCharts.Wpf;
using Menu.DataLibrary;
namespace Menu
{
    
    /// <summary>
    /// Interaction logic for BasicColumn.xaml
    /// </summary>
    public partial class BasicColumn : UserControl
    {
        public String serveur = @".\SQLEXPRESS";
        public BasicColumn()
        {
            InitializeComponent();
            var cn = Database.Connect(serveur,"mydb");
            cn.Open();
            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Restitue"
                },
                new StackedColumnSeries
                {
                    Title = "Nouveau"
                }
            };
            var list = Database.plotlist3_restitue(cn, DateTime.Now.Year, DateTime.Now.Month, true);
            SeriesCollection[0].Values = new ChartValues<double>();
            
            List<String> l = new List<string>();
            foreach (var o in list)
            {
                SeriesCollection[0].Values.Add(o.Y);
                l.Add(o.X.ToString());
                
            }
            cn.Close();
            cn.Open();
            list = Database.plotlist3(cn, DateTime.Now.Year, DateTime.Now.Month, true);
            SeriesCollection[1].Values = new ChartValues<double>();
            
            foreach (var o in list)
            {
                SeriesCollection[1].Values.Add(o.Y);
                
                
            }
            //adding series will update and animate the chart automatically
            Labels = l.ToArray();
            cn.Close();

            //also adding values updates and animates the chart automatically
            
            Formatter = value => (value+1).ToString("0.");
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> Formatter2 { get; set; }
        public object year=null,month=null;
        public double total=0;
        public bool prix;
        public void updategraph(object year,object month,bool price)
        {
            var cn = Database.Connect(serveur, "mydb");
            cn.Open();
            var list = Database.plotlist3_restitue(cn, year, month, price);
            List<String> l = new List<string>();
            SeriesCollection[0].Values = new ChartValues<double>();
            foreach (var o in list)
            {
                SeriesCollection[0].Values.Add(o.Y);
                l.Add(o.X.ToString());
                

            }
            cn.Close();
            cn.Open();
            list = Database.plotlist3(cn, year, month, price);
            SeriesCollection[1].Values = new ChartValues<double>();
            
            foreach (var o in list)
            {
                SeriesCollection[1].Values.Add(o.Y);
                
                
            }
            //adding series will update and animate the chart automatically
            Labels = l.ToArray();
            ff.AxisX[0].Labels = Labels;
            cn.Close();
        }
        void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			year = ((ComboBoxItem)((ComboBox) sender).SelectedItem).Content;
			//plotrefresh(plot);
            updategraph(year, month, prix);
		}
		void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
		{
			month = ((ComboBoxItem)((ComboBox) sender).SelectedItem).Content;
			//plotrefresh(plot);
            updategraph(year, month, prix);
		}
		void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
            theyear.Visibility = Visibility.Visible;
            year = DateTime.Now.Year;
            theyear.SelectedIndex = 4;
            updategraph(year, month, prix);
            /*if (theyear != null && plot != null)
            {
                plotrefresh(plot);
            }*/
		}
		void CheckBox_Checked2(object sender, RoutedEventArgs e)
		{
            month_count.Visibility = Visibility.Visible;
            month = 1;
            month_count.SelectedIndex = 0;
            updategraph(year, month, prix);/*
            if (month_count != null && plot != null)
            {
               
                plotrefresh(plot);
            }*/
		}
		void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			month_count.Visibility = Visibility.Collapsed;
			month = null;
			//plotrefresh(plot);
            updategraph(year, month, prix);
		}
		void CheckBox_Unchecked2(object sender, RoutedEventArgs e)
		{
			theyear.Visibility = Visibility.Collapsed;
			year = null;
			//plotrefresh(plot);
            updategraph(year, month, prix);
		}
		void CheckBox_Checked3(object sender, RoutedEventArgs e)
		{
            var t = sender as System.Windows.Controls.Primitives.ToggleButton;
            t.Content = "Quantite";
			prix =true;
			//plotrefresh(plot);
            updategraph(year, month, prix);
		}
		void CheckBox_Unchecked3(object sender, RoutedEventArgs e)
		{
            var t = sender as System.Windows.Controls.Primitives.ToggleButton;
            t.Content = "Prix";
			prix = false;
			//plotrefresh(plot);
            updategraph(year, month, prix);
		}

    }
}
