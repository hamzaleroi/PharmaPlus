using DataLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{

    public class bien_etre
    {
        public String Marque { get; set; }
        public String marque
        {
            get { return Marque; }
            set { Marque = value; }
        }
        public int Quantite { get; set; }
        public int quantite
        {
            get { return Quantite; }
            set { Quantite = value; }
        }
        public double Prix { get; set; }
        public double prix
        {
            get { return Prix; }
            set { Prix = value; }
        }
        public String Type { get; set; }
        public String type
        {
            get { return Type; }
            set { Type = value; }
        }
        public int ID { get; set; }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public String Gout { get; set; }
        public String gout
        {
            get { return Gout; }
            set { Gout = value; }
        }
        public object DateDeProduction { get; set; }
        public object dateDeProduction
        {
            get { return DateDeProduction; }
            set { DateDeProduction = value; }
        }
        public object DateDePeremption { get; set; }
        public object dateDePeremption
        {
            get { return DateDePeremption; }
            set { DateDePeremption = value; }
        }
        Database datab = new Database();
        string exceptionMessage;
        public string ExceptionMessage { get { return exceptionMessage; } }
        bool hasException;
        public bool HasException { get { return hasException; } }

        public bien_etre()
        {

        }
        public bien_etre(object DateDeProduction, object DateDePeremption, object Quantite, object Prix, string Marque, string Type, string gout, int id)
        {
            this.quantite = Convert.ToInt32(Quantite);
            this.Prix = Convert.ToInt32(Prix);
            this.marque = Marque;
            this.type = Type;
            this.gout = gout;
            this.id = id;
            if (DateDePeremption != null) this.dateDePeremption = Convert.ToDateTime(DateDePeremption);
            if (DateDeProduction != null) this.DateDeProduction = Convert.ToDateTime(DateDeProduction);

        }

        public Boolean inserer()
        {
            SqlConnection cn = new SqlConnection(@"Data source =.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true; ");
            SqlDataReader reader = null;
            try
            {
                Boolean existe = false;
                cn.Open();
                int qunt = 0;
                SqlCommand cmd;
                if ((DateDeProduction != null) && (DateDePeremption != null))
                {

                    cmd = new SqlCommand { Connection = cn, CommandText = datab.Cmd_select_bien_etre(DateDeProduction, DateDePeremption, Quantite, Prix, Marque, Type, gout) };
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        existe = true;
                        id = Convert.ToInt32(reader[0].ToString());
                        qunt = Convert.ToInt32(reader["Quantite"].ToString());
                    }
                    reader.Close();
                    if (existe)
                    {
                        cmd = new SqlCommand { Connection = cn, CommandText = " UPDATE Bien_etre SET Quantite=" + (qunt + quantite) + " WHERE ID = " + id };
                    }
                    else
                    {
                        cmd = new SqlCommand { Connection = cn, CommandText = datab.Cmd_insert_bien_etre(DateDeProduction, DateDePeremption, Quantite, Prix, Marque, Type, gout) };
                    }
                }
                else
                {
                    cmd = new SqlCommand { Connection = cn, CommandText = datab.Cmd_insert_bien_etre(DateDeProduction, DateDePeremption, Quantite, Prix, Marque, Type, gout) };
                }
                if (cmd.ExecuteNonQuery() > 0) return (true);
                else return (false);
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                return (false);
            }
            finally
            {
                cn.Close();
            }
        }
        //**********************************************************************************************************************
        
        //**********************************************************************************************************************




        //**********************************************************************************************************************
        //**********************************************************************************************************************



    }

}
