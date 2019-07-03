using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class list_content_cmd_b1_etre
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
        public String Type { get; set; }
        public String type
        {
            get { return Type; }
            set { Type = value; }
        }

        public String Compo { get; set; }
        public String compo
        {
            get { return Compo; }
            set { Compo = value; }
        }

        public int ID { get; set; }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }

    }
}
