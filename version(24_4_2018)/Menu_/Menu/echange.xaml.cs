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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;


namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour test.xaml
    /// </summary>
    public partial class echange : Page
    {
        public List<Listview_content1> list_inf = new List<Listview_content1>();

        public echange()
        {
            InitializeComponent();

            List<Bar> _bar = new List<Bar>();
            

            SqlCommand cmd;
            SqlDataReader dr = null;


            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            try
            {

                cn.Open();
                cmd = new SqlCommand("select nom_pharm , degre  from  echange", cn);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if(Convert.ToInt32(dr["degre"])!=0)
                    {
                        Bar bar = new Bar();
                        bar.BarName = dr["nom_pharm"].ToString();
                        bar.Value = Convert.ToInt32(dr["degre"]);
                        _bar.Add(bar);
                        this.DataContext = new RecordCollection(_bar);
                    }
                }

            }
            finally
            {
                cn.Close();
                dr.Close();
            }
        }
        class RecordCollection : ObservableCollection<Record>
        {

            public RecordCollection(List<Bar> barvalues)
            {
                Random rand = new Random();
                BrushCollection brushcoll = new BrushCollection();

                foreach (Bar barval in barvalues)
                {
                    int num = rand.Next(brushcoll.Count / 3);
                    Add(new Record(barval.Value, brushcoll[num], barval.BarName));
                }
            }

        }

        class BrushCollection : ObservableCollection<Brush>
        {
            public BrushCollection()
            {
                Type _brush = typeof(Brushes);
                PropertyInfo[] props = _brush.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    Brush _color = (Brush)prop.GetValue(null, null);
                    if (_color != Brushes.LightSteelBlue && _color != Brushes.White &&
                         _color != Brushes.WhiteSmoke && _color != Brushes.LightCyan &&
                         _color != Brushes.LightYellow && _color != Brushes.Linen)
                        Add(_color);
                }
            }
        }

        class Bar
        {

            public string BarName { set; get; }

            public int Value { set; get; }

        }

        class Record : INotifyPropertyChanged
        {
            public Brush Color { set; get; }

            public string Name { set; get; }

            private int _data;
            public int Data
            {
                set
                {
                    if (_data != value)
                    {
                        _data = value;

                    }
                }
                get
                {
                    return _data;
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public Record(int value, Brush color, string name)
            {
                Data = value;
                Color = color;
                Name = name;
            }

            protected void PropertyOnChange(string propname)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propname));
                }
            }
        }
        private void viewpharm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // public static Database db = new Database();
            SqlCommand cmd;
            SqlDataReader dr = null;
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            cn.Open();
            cmd = new SqlCommand("select * from echange ", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (Convert.ToInt32( dr["degre"])!=0)
                {
                    Listview_content1 pharm_inf = new Listview_content1();
                    pharm_inf.Nom = dr["nom_pharm"].ToString();
                    pharm_inf.Adress = dr["adress"].ToString();
                    pharm_inf.Fax = dr["fax"].ToString();
                    pharm_inf.Degre = dr["degre"].ToString();
                    list_inf.Add(pharm_inf);
                }

            }

            viewpharm.ItemsSource = list_inf;
            cn.Close();
            dr.Close();
        }
    }
}
