using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facture
{
    public class list_content_cmd
    {
        public String Marque { get; set; }
        public String marque
        {
            get { return Marque; }
            set { Marque = value; }
        }
        public int Quant { get; set; }
        public int quant
        {
            get { return Quant; }
            set { Quant = value; }
        }
        public double Dosage { get; set; }
        public double dosage
        {
            get { return Dosage; }
            set { Dosage = value; }
        }
        public String Dci { get; set; }
        public String dci
        {
            get { return Dci; }
            set { Dci = value; }
        }

        public String Forme { get; set; }
        public String forme
        {
            get { return Forme; }
            set { Forme = value; }
        }

        public int ID { get; set; }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }

    }
}
