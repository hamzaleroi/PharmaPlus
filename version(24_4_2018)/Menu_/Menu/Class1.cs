using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;

namespace DataLibrary
{

    public class restitue
    {
        public const String rest = "Restitué";
        public String Rest
        {
            get { return rest; }
        }
        public const String non_rest = "Non_Restitué";
        public String Non_rest
        {
            get { return non_rest; }
        }
        public const String none = "Non définie";
        public String None
        {
            get { return none; }
        }
    }
    //**********************************************************************************************************************
    public class Up_Del
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int quant;
        public int Quant
        {
            get { return quant; }
            set { quant = value; }
        }
        private bool upd;
        public bool Upd
        {
            get { return upd; }
            set { upd = value; }
        }
        public Up_Del(int id, int quant, bool upd)
        {
            this.id = id;
            this.quant = quant;
            this.upd = upd;
        }
    }
    // *********************************************************************************************************************
    public class Up_Del_bien
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int quant;
        public int Quant
        {
            get { return quant; }
            set { quant = value; }
        }
        private bool upd;
        public bool Upd
        {
            get { return upd; }
            set { upd = value; }
        }
        public Up_Del_bien(int id, int quant, bool upd)
        {
            this.id = id;
            this.quant = quant;
            this.upd = upd;
        }
    }

    public class medID_qunt
    {
        public String DCI { get; set; }
        public String Marque { get; set; }
        public String Forme { get; set; }
        public Double Dosage { get; set; }
        public String Effet_therapeutique { get; set; }
        public Boolean Remboursable { get; set; }
        public Boolean Restitue { get; set; }
        private int medID;
        public int MedID
        {
            get { return medID; }
            set { medID = value; }
        }
        private int qu;
        public int Quant
        {
            get { return qu; }
            set { qu = value; }
        }
        private int rest;
        public int Rest
        {
            get { return rest; }
            set { rest = value; }
        }
    }
    //**********************************************************************************************************************
    public class End_listException : Exception
    {
        public End_listException()
            : base("Quantite insuffisante !!")
        {
            this.HelpLink = "";
        }
    }
    public class Database
    {

        string exceptionMessage;
        /// <summary>
        /// Used to store the last exception thrown
        /// When an exception happens in one of the methods using a try-catch, in
        /// the catch hasException is set to true, if you get undesirable results
        /// then check HasExceptions, if true the Exception message can be read
        /// via ExceptionMessage property below.
        /// </summary>
        public string ExceptionMessage { get { return exceptionMessage; } }
        bool hasException;
        public bool HasException { get { return hasException; } }

        /// <summary>
        /// Determine if a specfic database exists on a known server
        /// </summary>
        /// <param name="pServer">Server name</param>
        /// <param name="pDatabase">Database name</param>
        /// <returns></returns>
        public bool DatabaseExists(string pServer, string pDatabase)
        {
            bool success = false;

            try
            {
                using (SqlConnection cn = new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=master;Integrated Security=True;")) })
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = ("select * from master.dbo.sysdatabases where name='" + (pDatabase + "'")) })
                    {
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        success = reader.HasRows;
                    }
                }
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
            }

            return success;

        }
        /*********************************************************************************************************************************************************************************/

        public string Cmd_Insert_Med(string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object rupture)
        {
            string commande2 = "";
            string comm = "";
            bool cond = false;
            string commande = "INSERT INTO " + pTableName;
            try
            {
                if (DCI != null)
                {
                    comm += "DCI ,";
                    commande2 += "'" + DCI + "' , ";
                    cond = true;
                }
                if (Marque != null)
                {
                    comm += "Marque ,";
                    cond = true;
                    commande2 += "'" + Marque + "' , ";
                }
                if (Forme != null)
                {
                    comm += "Forme ,";
                    commande2 += Convert.ToInt32(Forme) + "  , ";
                    cond = true;
                }
                if (Dosage != null)
                {
                    comm += "Dosage ,";
                    commande2 += Convert.ToSingle(Dosage).ToString(new CultureInfo("en-US")) + "  , ";
                    cond = true;
                }
                if (Categorie != null)
                {
                    comm += "Categorie ,";
                    commande2 += Convert.ToInt32(Categorie) + "  ,";
                    cond = true;
                }
                if (Effet_Therapeutique != null)
                {
                    comm += "Effet_Therapeutique ,";
                    commande2 += Convert.ToInt32(Effet_Therapeutique) + "  , ";
                    cond = true;
                }
                if (Remboursement != null)
                {
                    comm += "Remboursement ,";
                    commande2 += Convert.ToInt32(Convert.ToBoolean(Remboursement)) + "  ,";
                    cond = true;
                }
                if (Oriente != null)
                {
                    comm += "Oriente ,";
                    commande2 += Convert.ToInt32(Convert.ToBoolean(Oriente)) + "  ,";
                    cond = true;
                }
                if (Restitue != null)
                {
                    comm += "Restitue ,";
                    commande2 += Convert.ToInt32(Convert.ToBoolean(Restitue)) + "  ,";
                    cond = true;
                }
                if (rupture != null)
                {
                    comm += "Rupture ,";
                    commande2 += Convert.ToInt32(Convert.ToBoolean(rupture)) + "  ,";
                    cond = true;
                }
                if (cond)
                {
                    commande += " ( ";
                    commande += comm.Remove(comm.Length - 1);
                    commande += ")  VALUES (";
                    commande += commande2.Remove(commande2.Length - 3);
                    commande += ")";
                    // commande = commande.Remove(commande.Length - 6);
                }
                else return null;
                return commande;
            }
            catch
            {
                return null;
            }
        }
        /*********************************************************************************************************************************************************************************/

        public string Cmd_select_Med(string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object rupture)
        {
            bool cond = (DCI != null) || (Marque != null) || (Forme != null) || (Dosage != null) || (Categorie != null) || (Effet_Therapeutique != null) || (Remboursement != null) || (Oriente != null) || (Restitue != null) || (rupture != null);
            string commande = "SELECT * FROM " + pTableName;
            if (cond) commande += " WHERE ";
            try
            {

                if (DCI != null) commande += " DCI = '" + DCI + "' AND ";
                if (Marque != null) commande += " Marque = '" + Marque + "' AND ";
                if (Forme != null) commande += " Forme = " + Convert.ToInt32(Forme) + "  AND ";
                if (Dosage != null) commande += " Dosage = " + Convert.ToSingle(Dosage).ToString(new CultureInfo("en-US")) + "  AND ";
                if (Categorie != null) commande += " Categorie = " + Convert.ToInt32(Convert.ToBoolean(Categorie)) + "  AND ";
                if (Effet_Therapeutique != null) commande += " Effet_Therapeutique = " + Convert.ToInt32(Effet_Therapeutique) + "  AND ";
                if (Remboursement != null) commande += " Remboursement = " + Convert.ToInt32(Convert.ToBoolean(Remboursement)) + "  AND ";
                if (Oriente != null) commande += " Oriente = " + Convert.ToInt32(Convert.ToBoolean(Oriente)) + "  AND ";
                if (Restitue != null) commande += " Restitue = " + Convert.ToInt32(Convert.ToBoolean(Restitue)) + "  AND ";
                if (rupture != null) commande += " rupture = " + Convert.ToInt32(Convert.ToBoolean(rupture)) + "  AND ";
                if (cond) commande = commande.Remove(commande.Length - 6);
                else commande = "SELECT * from " + pTableName;
                return commande;
            }
            catch
            {
                return null;
            }
        }

        /*********************************************************************************************************************************************************************************/
        public string Cmd_Delete_Med(string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object rupture)
        {
            bool cond = (DCI != null) || (Marque != null) || (Forme != null) || (Dosage != null) || (Categorie != null) || (Effet_Therapeutique != null) || (Remboursement != null) || (Oriente != null) || (Restitue != null) || (rupture != null);
            string commande = "DELETE FROM " + pTableName;
            if (cond) commande += " WHERE ";
            try
            {

                if (DCI != null) commande += " DCI = '" + DCI + "' AND ";
                if (Marque != null) commande += " Marque = '" + Marque + "' AND ";
                if (Forme != null) commande += " Forme = " + Convert.ToInt32(Forme) + "  AND ";
                if (Dosage != null) commande += " Dosage = " + Convert.ToSingle(Dosage).ToString(new CultureInfo("en-US")) + "  AND ";
                if (Categorie != null) commande += " Categorie = " + Convert.ToInt32(Convert.ToBoolean(Categorie)) + "  AND ";
                if (Effet_Therapeutique != null) commande += " Effet_Therapeutique = " + Convert.ToInt32(Effet_Therapeutique) + "  AND ";
                if (Remboursement != null) commande += " Remboursement = " + Convert.ToInt32(Convert.ToBoolean(Remboursement)) + "  AND ";
                if (Oriente != null) commande += " Oriente = " + Convert.ToInt32(Convert.ToBoolean(Oriente)) + "  AND ";
                if (Restitue != null) commande += " Restitue = " + Convert.ToInt32(Convert.ToBoolean(Restitue)) + "  AND ";
                if (rupture != null) commande += " rupture = " + Convert.ToInt32(Convert.ToBoolean(rupture)) + "  AND ";
                if (cond) commande = commande.Remove(commande.Length - 6);
                else commande = "DELETE from " + pTableName;
                return commande;
            }
            catch
            {
                return null;
            }
        }

        //**********************************************************************************************************************
        public string Cmd_Insert_stock(string pTableName, object DateDeProduction, object DateDePeremption, object Quantite, object Prix, object Tab_medID, object lot)
        {
            string commande2 = "";
            string comm = "";
            bool cond = false;
            string commande = "INSERT INTO " + pTableName;
            if (DateDeProduction != null)
            {
                try
                {
                    comm += " DateDeProduction ,";
                    commande2 += "'" + Convert.ToDateTime(DateDeProduction) + "'  , ";
                    cond = true;
                }
                catch
                {
                    return null;
                }
            }
            if (DateDePeremption != null)
            {
                try
                {
                    comm += " DateDePeremption ,";
                    commande2 += "'" + Convert.ToDateTime(DateDePeremption) + "'  , ";
                    cond = true;
                }
                catch
                {
                    return null;
                }
            }
            if (Quantite != null)
            {
                try
                {
                    comm += " Quantite ,";
                    commande2 += "'" + Quantite + "'  , ";
                    cond = true;
                }
                catch
                {
                    return null;
                }
            }
            if (Prix != null)
            {
                try
                {
                    comm += " Prix ,";
                    commande2 += "'" + Prix + "'  , ";
                    cond = true;
                }
                catch
                {
                    return null;
                }
            }
            if (Tab_medID != null)
            {
                try
                {
                    comm += " Tab_medID ,";
                    commande2 += "'" + Tab_medID + "'  ,";
                    cond = true;
                }
                catch
                {
                    return null;
                }
            }
            if (lot != null)
            {
                try
                {
                    comm += " lot ,";
                    commande2 += "'" + lot + "'  , ";
                    cond = true;
                }
                catch
                {
                    return null;
                }
            }
            if (cond)
            {
                commande += " ( ";
                commande += comm.Remove(comm.Length - 1);
                commande += ")  VALUES (";
                commande += commande2.Remove(commande2.Length - 3);
                commande += ")";
            }
            else return null;
            return commande;
        }
        /*********************************************************************************************************************************************************************************/
        public string Cmd_select_stock(string pTableName, object DateDeProduction, object DateDePeremption, object Quantite, object Prix, object Tab_medID, object lot)
        {
            bool cond = (DateDeProduction != null) || (DateDePeremption != null) || (Quantite != null) || (Prix != null) || (Tab_medID != null);
            string commande = "SELECT * FROM " + pTableName;
            if (cond) commande += " WHERE ";
            try
            {

                if (DateDeProduction != null) commande += " DateDeProduction = '" + Convert.ToDateTime(DateDeProduction) + "' AND ";
                if (DateDePeremption != null) commande += " DateDePeremption = '" + Convert.ToDateTime(DateDePeremption) + "' AND ";
                if (Quantite != null) commande += " Quantite = " + Convert.ToInt32(Quantite) + "  AND ";
                if (Prix != null) commande += " Prix = " + Convert.ToSingle(Prix).ToString(new CultureInfo("en-US")) + "  AND ";
                if (Tab_medID != null) commande += " Tab_medID = " + Convert.ToInt32(Tab_medID) + "  AND ";
                if (lot != null) commande += " lot = " + Convert.ToInt32(Quantite) + "  AND ";

                if (cond) commande = commande.Remove(commande.Length - 6);
                else commande = "SELECT * from " + pTableName;
                return commande;
            }
            catch
            {
                return null;
            }
        }

        //**********************************************************************************************************************

        public string Cmd_insert_bien_etre(object DateDeProduction, object DateDePeremption, object Quantite, object Prix, string Marque, string Type, string gout)
        {
            try
            {
                string commande2 = "";
                string comm = "";
                bool cond = false;
                string commande = "INSERT INTO Bien_etre ";
                if (DateDeProduction != null)
                {
                    try
                    {
                        comm += " DateDeProduction ,";
                        commande2 += " '" + Convert.ToDateTime(DateDeProduction).ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture) + "'  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (DateDePeremption != null)
                {
                    try
                    {
                        comm += " DateDePeremption ,";
                        commande2 += "'" + Convert.ToDateTime(DateDePeremption).ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture) + "'  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (Quantite != null)
                {
                    try
                    {
                        comm += " Quantite ,";
                        commande2 += "'" + Quantite + "'  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (Prix != null)
                {
                    try
                    {
                        comm += " Prix ,";
                        commande2 += "'" + Prix + "'  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (Marque != null)
                {
                    try
                    {
                        comm += " Marque ,";
                        commande2 += "'" + Marque + "'  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (Type != null)
                {
                    try
                    {
                        comm += " Type ,";
                        commande2 += "'" + Type + "'  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (gout != null)
                {
                    try
                    {
                        comm += " Gout ,";
                        commande2 += "'" + gout + "'  ,";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (cond)
                {
                    commande += " ( ";
                    commande += comm.Remove(comm.Length - 1);
                    commande += ")  VALUES (";
                    commande += commande2.Remove(commande2.Length - 3);
                    commande += ")";
                }
                else return null;
                return commande;
            }
            catch
            {
                return null;
            }

        }
        //**********************************************************************************************************************

        public string Cmd_select_bien_etre(object DateDeProduction, object DateDePeremption, object Quantite, object Prix, string Marque, string Type, string gout)
        {
            bool cond = (DateDeProduction != null) || (DateDePeremption != null) || (Quantite != null) || (Prix != null) || (Marque != null) || (Type != null) || (gout != null);
            string commande = "SELECT * FROM Bien_etre ";
            if (cond) commande += " WHERE ";
            try
            {
                if ((gout != null)) commande += " gout = '" + (gout) + "'  AND ";
                if (DateDeProduction != null) commande += " DateDeProduction = '" + Convert.ToDateTime(DateDeProduction) + "' AND ";
                if (DateDePeremption != null) commande += " DateDePeremption = '" + Convert.ToDateTime(DateDePeremption) + "' AND ";
                if (Quantite != null) commande += " Quantite = " + Convert.ToInt32(Quantite) + "  AND ";
                if (Prix != null) commande += " Prix = " + Convert.ToSingle(Prix).ToString(new CultureInfo("en-US")) + "  AND ";
                if (Marque != null) commande += " Marque = '" + (Marque) + "'  AND ";
                if (Type != null) commande += " Type = '" + (Type) + "'  AND ";
                if (cond) commande = commande.Remove(commande.Length - 6);
                else commande = "SELECT * from Bien_etre";
                return commande;
            }
            catch
            {
                return null;
            }
        }
        /*********************************************************************************************************************************************************************************/
        public string Cmd_Delete_stock(string pTableName, object DateDeProduction, object DateDePeremption, object Quantite, object Prix, object Tab_medID, object lot)
        {
            bool cond = (DateDeProduction != null) || (DateDePeremption != null) || (Quantite != null) || (Prix != null) || (Tab_medID != null);
            string commande = "DELETE FROM " + pTableName;
            if (cond) commande += " WHERE ";
            try
            {
                if (DateDeProduction != null) commande += " DateDeProduction = '" + Convert.ToDateTime(DateDeProduction) + "' AND ";
                if (DateDePeremption != null) commande += " DateDePeremption = '" + Convert.ToDateTime(DateDePeremption) + "' AND ";
                if (Quantite != null) commande += " Quantite = " + Convert.ToInt32(Quantite) + "  AND ";
                if (Prix != null) commande += " Prix = " + Convert.ToSingle(Prix).ToString(new CultureInfo("en-US")) + "  AND ";
                if (Tab_medID != null) commande += " Tab_medID = " + Convert.ToInt32(Tab_medID) + "  AND ";
                if (lot != null) commande += " lot = " + Convert.ToInt32(Quantite) + "  AND ";

                if (cond) commande = commande.Remove(commande.Length - 6);
                else commande = "DELETE from " + pTableName;
                return commande;
            }
            catch
            {
                return null;
            }
        }
        //**********************************************************************************************************************


        public void Insertion_Med(string pServer, string pDatabase, string pTableName, string DCI, string Marque, int Forme, float Dosage, int Categorie, int Effet_Therapeutique, int Remboursement, int Oriente, int Restitue, int rupture)
        {
            SqlDataReader reader = null;

            try
            {
                SqlConnection cn = new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_Insert_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, rupture)  /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                cn.Open();
                Console.WriteLine(Cmd_Insert_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ );
                reader = cmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                hasException = true;
                Console.WriteLine("erreur");
                exceptionMessage = ex.Message;
            }



        }
        //**********************************************************************************************************************
        public SqlDataReader Recherche_Med(SqlConnection cn, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object rupture)
        {
            SqlDataReader reader = null;

            try
            {

                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_select_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                cn.Open();

                reader = cmd.ExecuteReader();
                if (reader.HasRows) return reader;

            }
            catch (Exception ex)
            {
                hasException = true;
                Console.WriteLine("erreur");
                exceptionMessage = ex.Message;

            }
            finally
            {
                cn.Close();
            }

            return reader;
        }
        //**********************************************************************************************************************
        public bool Delete_Med(SqlConnection cn, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
        {

            try
            {

                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_Delete_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                cn.Open();
                Console.WriteLine(Cmd_Delete_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ );
                return cmd.ExecuteNonQuery() > 0;


            }
            catch (Exception ex)
            {
                hasException = true;
                Console.WriteLine("erreur");
                exceptionMessage = ex.Message;

            }
            return false;


        }
        //2eme delete
        public void Delete_Medi(SqlConnection cn, string pServer, string pDatabase, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
        {

            SqlDataReader reader = null;
            try
            {
                cn = new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_Delete_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                cn.Open();
                Console.WriteLine(Cmd_Delete_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ );
                reader = cmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                hasException = true;
                Console.WriteLine("erreur");
                exceptionMessage = ex.Message;

            }



        }

        //**********************************************************************************************************************
        /*    public Tab_medTableAdapter Insert_Adapter(string pServer, string pDataBase, string pTableName)
            {
                if (SqlServerIsAvailable().Result)
                {
                    if (DatabaseExists(pServer, pDataBase) && TableExists(pServer,pDataBase,pTableName))
                    {

                        var adapter = new WpfApp2.mydbDataSetTableAdapters.Tab_medTableAdapter();
                        return adapter;
                    }

                }
                return null;


            }*/
        //**********************************************************************************************************************
        /// <summary>
        /// Determine if a table exist
        /// </summary>
        /// <param name="pServer">An available server</param>
        /// <param name="pDatabase">An existing database</param>
        /// <param name="pTableName">Table name to check if exists or not</param>
        /// <returns></returns>
        public bool TableExists(string pServer, string pDatabase, string pTableName)
        {
            bool success = false;
            var _ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;"));

            try
            {
                using (SqlConnection cn = new SqlConnection { ConnectionString = _ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = cn })
                    {
                        cmd.CommandText = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='" + pTableName + "') SELECT 1 ELSE SELECT 0";
                        cn.Open();
                        var result = Convert.ToInt32(cmd.ExecuteScalar());
                        success = result == 1;
                        Console.WriteLine("hello");
                    }
                }
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;

            }

            return success;

        }
        //**********************************************************************************************************************
        /// <summary>
        /// Get table names for a database that exists on an available SQL-Server
        /// </summary>
        /// <param name="pServer">Server name</param>
        /// <param name="pDatabase">Database name</param>
        /// <returns></returns>
        public SqlDataReader Search()
        {
            return null;
        }
        public List<string> TableNames(string pServer, string pDatabase)
        {
            var tableNames = new List<string>();
            var _ConnectionString = "Data Source={pServer};Initial Catalog={pDatabase};Integrated Security=True";

            using (SqlConnection cn = new SqlConnection { ConnectionString = _ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText =
                            @"SELECT s.name, o.name
                              FROM sys.objects o WITH(NOLOCK)
                              JOIN sys.schemas s WITH(NOLOCK)
                              ON o.schema_id = s.schema_id
                              WHERE o.is_ms_shipped = 0 AND RTRIM(o.type) = 'U'
                              ORDER BY s.name ASC, o.name ASC";

                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            string tableName = reader.GetString(1);
                            if (!tableName.Contains("sysdiagrams"))
                            {
                                tableNames.Add(tableName);
                            }

                        }

                    }
                }
            }

            return tableNames;
        }

        /*********************************************************************************************************************************************************************************/

        /// <summary>
        /// Determine if SQL-Server is available
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SqlServerIsAvailable()
        {
            bool success = false;
            try
            {
                await Task.Run(() =>
                {
                    SqlDataSourceEnumerator sqlDataSourceEnumeratorInstance = SqlDataSourceEnumerator.Instance;
                    DataTable dt = sqlDataSourceEnumeratorInstance.GetDataSources();
                    if (dt != null)
                    {
                        success = true;
                    }
                });
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
            }

            return success;
        }
        public SqlConnection Connect(string pServer, string pDatabase)
        {
            return new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
        }

        /*********************************************************************************************************************************************************************************/

        public bool Insert_Med(SqlConnection conn, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object lot)
        {
            SqlCommand cmd = new SqlCommand { Connection = conn, CommandText = Cmd_Insert_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, lot) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
            conn.Open();
            try
            {
                if (cmd.ExecuteNonQuery() != 0) return true;
                else return false;
            }
            catch
            {
                return false; // this code here need checking 
            }
        }
        //**********************************************************************************************************************
        /// <summary>
        /// Determine if a specific SQL-Server is available
        /// </summary>
        /// <param name="pServerName"></param>
        /// <returns></returns>

        public async Task<bool> SqlServerIsAvailable(string pServerName)
        {
            bool success = false;

            try
            {
                await Task.Run(() =>
                {
                    SqlDataSourceEnumerator sqlDataSourceEnumeratorInstance = SqlDataSourceEnumerator.Instance;
                    DataTable dt = sqlDataSourceEnumeratorInstance.GetDataSources();
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<string>("ServerName") == pServerName.ToUpper());
                            success = row != null;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
            }

            return success;
        }

        //**********************************************************************************************************************
        /// <summary>
        /// Incrementer le stock s'il existe deja sinon il va creer un nouveau stock dans le tableau pTableName
        /// </summary>
        /// <param name="pTableName">nom de tableau</param>
        /// <param name="ID">ID de médicament concerné</param>
        /// <param name="n">la valeur à ajouter à la quantité</param>
        /// <param name="DateDeProduction">la date de production de médicament</param>
        /// <param name="DateDePeremption">la date de peremption de médicament</param>
        /// <param name="Prix">le prix de médicament</param>
        /// <returns>un entier s'il était à 0 donc il y avait un erreur (quantité de stock insuffisante ou il n'y a pas de stock de ce médicament) sinon tout a passé bien</returns>
        /// 
        public int Dec_Stock_med(string pTableName, int ID, int n)
        {
            int i = 0;
            int success = 1;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID , Quantite FROM " + pTableName + " WHERE Tab_medID=" + ID + " ORDER BY DateDePeremption ASC", cn);
            SqlDataReader dr;
            bool stop = false;
            List<Up_Del> lis = new List<Up_Del>();
            dr = cmd.ExecuteReader();

            Up_Del str;

            try
            {
                while (dr.Read() && (!stop))
                {
                    if (Convert.ToInt32(dr[1]) == n)
                    {
                        str = new Up_Del(Convert.ToInt32(dr[0]), 0, false);
                        lis.Add(str);
                        n = 0;
                        stop = true;
                    }
                    else
                    {
                        if (Convert.ToInt32(dr[1]) > n)
                        {
                            str = new Up_Del(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]) - n, true);
                            lis.Add(str);
                            n = 0;
                            stop = true;
                        }
                        else
                        {
                            str = new Up_Del(Convert.ToInt32(dr[0]), 0, false);
                            lis.Add(str);
                            n = n - Convert.ToInt32(dr[1]);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                dr.Close();
            }

            try
            {

                if (n > 0)
                {
                    //quantité de stock insuffisante ou il n'y a pas de stock de médicament
                    success = -1;
                    throw new End_listException();
                }
                else
                {
                    i = 0;
                    while (i < lis.Count)
                    {
                        str = lis[i];
                        if (str.Upd == true)//Update
                        {
                            cmd = new SqlCommand(" UPDATE " + pTableName + " SET Quantite=" + str.Quant + " WHERE ID = " + str.Id, cn);
                            cmd.ExecuteNonQuery();
                        }
                        else //delete
                        {
                            cmd = new SqlCommand(" DELETE From " + pTableName + " WHERE ID = " + str.Id, cn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;

                    }
                }
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                cn.Close();
            }
            return (success);
        }

        public int Dec_Stock_bien_etre(string pTableName, int ID, int n, string marque, string type, string comp)
        {
            int i = 0;
            int success = 1;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID , Quantite FROM Bien_etre  where Marque='" + marque + "'  and type='" + type + "' and Gout='" + comp + "' ORDER BY DateDePeremption ASC", cn);
            SqlDataReader dr;
            bool stop = false;
            List<Up_Del> lis = new List<Up_Del>();
            dr = cmd.ExecuteReader();

            Up_Del str;

            try
            {
                while (dr.Read() && (!stop))
                {
                    if (Convert.ToInt32(dr[1]) == n)
                    {
                        str = new Up_Del(Convert.ToInt32(dr[0]), 0, false);
                        lis.Add(str);
                        n = 0;
                        stop = true;
                    }
                    else
                    {
                        if (Convert.ToInt32(dr[1]) > n)
                        {
                            str = new Up_Del(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]) - n, true);
                            lis.Add(str);
                            n = 0;
                            stop = true;
                        }
                        else
                        {
                            str = new Up_Del(Convert.ToInt32(dr[0]), 0, false);
                            lis.Add(str);
                            n = n - Convert.ToInt32(dr[1]);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                dr.Close();
            }

            try
            {

                if (n > 0)
                {
                    //quantité de stock insuffisante ou il n'y a pas de stock de médicament
                    success = -1;
                    throw new End_listException();
                }
                else
                {
                    i = 0;
                    while (i < lis.Count)
                    {
                        str = lis[i];
                        if (str.Upd == true)//Update
                        {
                            cmd = new SqlCommand(" UPDATE " + pTableName + " SET Quantite=" + str.Quant + " WHERE ID = " + str.Id, cn);
                            cmd.ExecuteNonQuery();
                        }
                        else //delete
                        {
                            cmd = new SqlCommand(" DELETE From " + pTableName + " WHERE ID = " + str.Id, cn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;

                    }
                }
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                cn.Close();
            }
            return (success);
        }



        public double Stock_suffi(string pTableName, int ID, int n)
        {
            double prix = 0;
            double success = 0;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Prix , Quantite FROM " + pTableName + " WHERE Tab_medID=" + ID + " ORDER BY DateDePeremption ASC", cn);
            SqlDataReader dr;
            bool stop = false;
            dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() && (!stop))
                {
                    if (Convert.ToInt32(dr[1]) == n)
                    {
                        prix = Convert.ToDouble(dr[0]);
                        n = 0;
                        stop = true;
                    }
                    else
                    {
                        if (Convert.ToInt32(dr[1]) > n)
                        {
                            prix = Convert.ToDouble(dr[0]);

                            n = 0;
                            stop = true;
                        }
                        else
                        {
                            prix = Convert.ToDouble(dr[0]);
                            n = n - Convert.ToInt32(dr[1]);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                dr.Close();
            }

            try
            {

                if (n > 0)
                {
                    //quantité de stock insuffisante ou il n'y a pas de stock de médicament
                    success = -1;
                    throw new End_listException();
                }
                else
                {
                    return (prix);
                }
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                cn.Close();
            }
            return (success);
        }

        /******************************************************************************************************/
        public double Stock_suffi_bien(string Marque, String Type, String gout, int n)
        {
            double prix = 0;
            double success = 0;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Prix , Quantite FROM Bien_etre WHERE Marque='" + Marque + "' AND Type='" + Type + "' AND Gout='" + gout + "' ORDER BY DateDePeremption ASC", cn);
            SqlDataReader dr;
            bool stop = false;
            dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() && (!stop))
                {
                    if (Convert.ToInt32(dr[1]) == n)
                    {
                        prix = Convert.ToDouble(dr[0]);
                        n = 0;
                        stop = true;
                    }
                    else
                    {
                        if (Convert.ToInt32(dr[1]) > n)
                        {
                            prix = Convert.ToDouble(dr[0]);

                            n = 0;
                            stop = true;
                        }
                        else
                        {
                            prix = Convert.ToDouble(dr[0]);
                            n = n - Convert.ToInt32(dr[1]);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                dr.Close();
            }

            try
            {

                if (n > 0)
                {
                    //quantité de stock insuffisante ou il n'y a pas de stock de médicament
                    success = -1;
                    throw new End_listException();
                }
                else
                {
                    return (prix);
                }
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = -1;
            }
            finally
            {
                cn.Close();
            }
            return (success);
        }


        //**********************************************************************************************************************
        /// <summary>
        /// Incrementer le stock s'il existe deja sinon il va creer un nouveau stock dans le tableau pTableName
        /// </summary>
        /// <param name="pTableName">nom de tableau</param>
        /// <param name="ID">ID de médicament concerné</param>
        /// <param name="n">la valeur à ajouter à la quantité</param>
        /// <param name="DateDeProduction">la date de production de médicament</param>
        /// <param name="DateDePeremption">la date de peremption de médicament</param>
        /// <param name="Prix">le prix de médicament</param>
        /// <returns>un entier s'il était à 0 donc il y avait un erreur et la quantité n'a pas était incrémenté sinon tout a passé bien</returns>
        public int Incr_Stock(string pTableName, int ID, int n, DateTime DateDeProduction, DateTime DateDePeremption, double Prix, object lot)
        {

            int quant = 0;
            int success = 1;
            SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
            cn.Open();
            SqlCommand cmd = new SqlCommand(Cmd_select_stock(pTableName, DateDeProduction, DateDePeremption, null, Prix, ID, lot), cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int res_id = 0;
            bool stop = false;
            try
            {
                if (dr.Read() && (!stop))
                {
                    res_id = Convert.ToInt32(dr[0].ToString());
                    quant = (Convert.ToInt32(dr[3].ToString()) + n);
                    stop = true;
                }
            }
            catch
            {
            }
            finally
            {
                dr.Close();
            }
            try
            {
                if (stop == true)
                {
                    cmd = new SqlCommand("UPDATE " + pTableName + " SET   Quantite= '" + quant + "' WHERE ID = '" + res_id + "'", cn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand(Cmd_Insert_stock(pTableName, DateDeProduction, DateDePeremption, n, Prix, ID, lot), cn);
                    cmd.ExecuteNonQuery();
                }
                success = 1;
            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;
                success = 0;
            }
            finally
            {
                cn.Close();
            }
            return (success);
        }


        public bool ajout_list_med(SqlConnection cn, List<medID_qunt> lis, int REST, int n, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
        {
            SqlDataReader reader = Recherche_Med(cn, "Tab_med", DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture);
            int ID = 0;
            int qunt_total = 0;
            try
            {
                if (reader.Read())
                {
                    ID = Convert.ToInt32(reader[0].ToString());
                }
            }
            catch
            {

            }
            reader.Close();
            if (ID != 0)
            {
                if (REST == 1)
                {
                    SqlCommand cmd = new SqlCommand(Cmd_select_stock("TabRestitue", null, null, null, null, ID, null), cn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        qunt_total = qunt_total + Convert.ToInt32(reader[3].ToString());
                    }
                    if (qunt_total >= n)
                    {
                        medID_qunt elem = new medID_qunt();
                        elem.MedID = ID;
                        elem.Quant = n;
                        elem.Rest = 1;
                        lis.Add(elem);
                    }
                    reader.Close();
                }
                if (REST == 0)
                {
                    SqlCommand cmd = new SqlCommand(Cmd_select_stock("Tab_NEW", null, null, null, null, ID, null), cn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        qunt_total = qunt_total + Convert.ToInt32(reader[3].ToString());
                    }
                    if (qunt_total >= n)
                    {
                        medID_qunt elem = new medID_qunt();
                        elem.MedID = ID;
                        elem.Quant = n;
                        elem.Rest = 1;
                        lis.Add(elem);
                    }
                    reader.Close();
                }
                return (qunt_total >= n);
            }
            else
                return (false);

        }
    }


}
