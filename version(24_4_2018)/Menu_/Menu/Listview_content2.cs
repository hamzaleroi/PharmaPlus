using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facture
{
    public class Listview_content2
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
        public  Boolean Restitue { get; set; }
        public Boolean restitue
        {
            get { return Restitue; }
            set { Restitue = value; }
        }
    }
}
