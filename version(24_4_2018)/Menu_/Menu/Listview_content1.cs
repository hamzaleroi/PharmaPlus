using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
   public  class Listview_content1
    {
        public String Nom { get; set; }
        public String nom
        {
            get { return Nom; }
            set { Nom = value; }
        }
        public String Adress { get; set; }
        public String adress
        {
            get { return Adress; }
            set { Adress = value; }
        }
        public String Fax { get; set; }
        public String fax
        {
            get { return Fax; }
            set { Fax = value; }
        }
        public String Degre { get; set; }
        public String degre
        {
            get { return Degre; }
            set { Degre = value; }
        }
    }
}
