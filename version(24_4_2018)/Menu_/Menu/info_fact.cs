using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class info_fact
    {
        public string Nom { get; set; }
        public string nom
        {
            get { return Nom; }
            set { Nom = value; }
        }
        public int Code { get; set; }
        public int code
        {
            get { return Code; }
            set { Code = value; }
        }
        public double Total { get; set; }
        public double total
        {
            get { return Total; }
            set { Total = value; }
        }
        public info_fact (String nom , int code, double total)
        {
            this.code = code;
            this.nom = nom;
            this.total = total;
        }
    }
}
