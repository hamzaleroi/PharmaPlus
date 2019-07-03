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
        public String Comp { get; set; }
        public String comp
        {
            get { return Comp; }
            set { Comp = value; }
        }
        public String Type { get; set; }
        public String type
        {
            get { return Type; }
            set { Type = value; }
        }
        public Boolean Restitue { get; set; }
        public Boolean restitue
        {
            get { return Restitue; }
            set { Restitue = value; }
        }
        public Boolean medicament { get; set; }
        public Boolean Medicament
        {
            get { return medicament; }
            set { medicament = value; }
        }
        public int ID { get; set; }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
    }
}
