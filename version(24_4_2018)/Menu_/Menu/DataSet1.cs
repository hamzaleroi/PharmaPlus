namespace Menu
{


    public partial class DataSet1
    {
        partial class cmd_medDataTable
        {
            public string Marque { get; set; }
            public string marque
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
            public string Dci { get; set; }
            public string dci
            {
                get { return Dci; }
                set { Dci = value; }
            }

            public string Forme { get; set; }
            public string forme
            {
                get { return Forme; }
                set { Forme = value; }
            }
        }

        partial class cmd_bien_etreDataTable
        {
            public string Marque { get; set; }
            public string marque
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
            public string Type { get; set; }
            public string type
            {
                get { return Type; }
                set { Type = value; }
            }

            public string Compo { get; set; }
            public string compo
            {
                get { return Compo; }
                set { Compo = value; }
            }
        }

        partial class info_factDataTable
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
        }

        partial class listeDataTable
        {
            public string Marque { get; set; }
            public string marque
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
            public double Prix { get; set; }
            public double prix
            {
                get { return Prix; }
                set { Prix = value; }
            }
            public string Restitue { get; set; }
            public string restitue
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
        }
    }
}
