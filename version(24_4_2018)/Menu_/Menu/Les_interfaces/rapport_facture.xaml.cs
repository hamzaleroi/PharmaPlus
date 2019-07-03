using System.Collections.Generic;
using System.Windows;
using Menu.Les_interfaces;
using Menu;

namespace facture
{
    /// <summary>
    /// Logique d'interaction pour rapport_facture.xaml
    /// </summary>
    public partial class rapport_facture : Window
    {
        public rapport_facture(int a,object list_inf, List<info_fact> list_info_fact)
        {
            InitializeComponent();
            if (a==1)
            {
                CrystalReport1 cr = new CrystalReport1();
                cr.Database.Tables[0].SetDataSource(list_inf);
                cr.Database.Tables[1].SetDataSource(list_info_fact);
                crystalReportV.ViewerCore.ReportSource = cr;
            }
            if(a==2)
            {
                CrystalReport_cmd_bien_etre cr = new CrystalReport_cmd_bien_etre();
                cr.Database.Tables[0].SetDataSource(list_inf);
                cr.Database.Tables[1].SetDataSource(list_info_fact);
                crystalReportV.ViewerCore.ReportSource = cr;
            }
            if(a==3)
            {
                CrystalReport_cmd_med cr = new CrystalReport_cmd_med();
                cr.Database.Tables[0].SetDataSource(list_inf);
                cr.Database.Tables[1].SetDataSource(list_info_fact);
                crystalReportV.ViewerCore.ReportSource = cr;
            }

            
        }
    }
}
