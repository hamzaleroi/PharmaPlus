using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facture
{
    public class Listview_content
    {
        public  String Marque { get; set; }
        public String marque
        {
            get { return Marque; }
            set { Marque = value; }
        }
        public  int Quant { get; set; }
        public int quant
        {
            get { return Quant; }
            set { Quant = value; }
        }
        public  double Prix { get; set; }
        public double prix
        {
            get { return Prix; }
            set { Prix = value; }
        }
        public String Restitue { get; set; }
        public String restitue
        {
            get { return Restitue; }
            set { Restitue = value; }
        }
        public int ID { get; set; }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public double Total { get; set; }
        public double total
        {
            get { return Total; }
            set { Total = value; }
        }
        public string Code { get; set; }
        public string code
        {
            get { return Code; }
            set { Code = value; }
        }
    }
}
