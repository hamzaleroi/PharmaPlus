using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Menu
{
    


    namespace DataLibrary
    {
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
        static public class Database
        {

            static string exceptionMessage;
            /// <summary>
            /// Used to store the last exception thrown
            /// When an exception happens in one of the methods using a try-catch, in
            /// the catch hasException is set to true, if you get undesirable results
            /// then check HasExceptions, if true the Exception message can be read
            /// via ExceptionMessage property below.
            /// </summary>
            public static string ExceptionMessage { get { return exceptionMessage; } }
            static bool hasException;
            public static  bool HasException { get { return hasException; } }

            /// <summary>
            /// Determine if a specfic database exists on a known server
            /// </summary>
            /// <param name="pServer">Server name</param>
            /// <param name="pDatabase">Database name</param>
            /// <returns></returns>
            public static bool DatabaseExists(string pServer, string pDatabase)
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

            public static string Cmd_Insert_Med(string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
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
                    if (Rupture != null)
                    {
                        comm += "Rupture ,";
                        commande2 += Convert.ToInt32(Convert.ToBoolean(Rupture)) + "  ,";
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

            public static string Cmd_select_Med(string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
            {
                bool cond = (DCI != null) || (Marque != null) || (Forme != null) || (Dosage != null) || (Categorie != null) || (Effet_Therapeutique != null) || (Remboursement != null) || (Oriente != null) || (Restitue != null) || (Rupture != null);
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
                    if (Rupture != null) commande += " Rupture = " + Convert.ToInt32(Convert.ToBoolean(Rupture)) + "  AND ";
                    if (cond) commande = commande.Remove(commande.Length - 5);
                    else commande = "SELECT * from " + pTableName;
                    return commande;
                }
                catch
                {
                    return null;
                }
            }

            /*********************************************************************************************************************************************************************************/
            public static string Cmd_Delete_Med(string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
            {
                bool cond = (DCI != null) || (Marque != null) || (Forme != null) || (Dosage != null) || (Categorie != null) || (Effet_Therapeutique != null) || (Remboursement != null) || (Oriente != null) || (Restitue != null) || (Rupture != null);
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
                    if (Rupture != null) commande += " Rupture = " + Convert.ToInt32(Convert.ToBoolean(Rupture)) + "  AND ";
                    if (cond) commande = commande.Remove(commande.Length - 6);
                    else commande = "DELETE from " + pTableName;
                    return commande;
                }
                catch
                {
                    return null;
                }
            }
            public static string Cmd_Insert_stock(string pTableName, object DateDeProduction, object DateDePeremption, object Quantite, object Prix, object Tab_medID)
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

            //**********************************************************************************************************************
            public static string Cmd_stat(string pTableName, object Year, object Mois, bool prix)
            {
                /* string commande2 = @"select Year( DateDeVente ) as the_year, MONTH(DateDeVente) as the_month , DAY(DateDeVente) as the_day,  SUM(Quantite * 

     Prix) as interet from view_tab_med where  year(dateDeVente) = 2018  group by Year(DateDeVente),MONTH(DateDeVente),DAY

     (DateDeVente)  order by  Year( DateDeVente ) DESC ,MONTH(DateDeVente)  DESC ,DAY(DateDeVente)  DESC";*/
                string commande2 = "";
                string comm = "";

                bool cond = false;
                string commande = "INSERT INTO " + pTableName;
                if (Year != null)
                {
                    try
                    {
                        comm += " Year( DateDeVente )  , MONTH(DateDeVente)  ,";
                        commande2 += "YEAR(DateDeVente) =" + Convert.ToInt32(Year) + "  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (Mois != null)
                {
                    try
                    {
                        if (Year == null) comm += " MONTH(DateDeVente)  , DAY(DateDeVente)  ,";
                        else comm += " DAY(DateDeVente)  ,";
                        commande2 += "MONTH(DateDeVente) =" + Convert.ToInt32(Mois) + "  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }


                string chaine = (prix) ? "Quantite*Prix" : "Quantite";
                if (cond)
                {
                    commande = "select ";
                    commande += comm;
                    commande += " SUM(" + chaine + ") from " + pTableName + " where ";
                    commande += commande2.Remove(commande2.Length - 3).Replace(",", "AND");
                    commande += " group by " + comm.Remove(comm.Length - 1);
                    commande += " order by " + comm.Remove(comm.Length - 1);

                }
                else return @"select Year( DateDeVente )  , SUM(" + chaine + @" )  from view_tab_med   group by Year(DateDeVente)  order by  Year( DateDeVente ) DESC  ";
                return commande;
            }
             public static string Cmd_stat_restitue(string pTableName, object Year, object Mois, bool prix)
            {
                /* string commande2 = @"select Year( DateDeVente ) as the_year, MONTH(DateDeVente) as the_month , DAY(DateDeVente) as the_day,  SUM(Quantite * 

     Prix) as interet from view_tab_med where  year(dateDeVente) = 2018  group by Year(DateDeVente),MONTH(DateDeVente),DAY

     (DateDeVente)  order by  Year( DateDeVente ) DESC ,MONTH(DateDeVente)  DESC ,DAY(DateDeVente)  DESC";*/
                string commande2 = "";
                string comm = "";

                bool cond = false;
                string commande = "INSERT INTO " + pTableName;
                if (Year != null)
                {
                    try
                    {
                        comm += " Year( DateDeVente )  , MONTH(DateDeVente)  ,";
                        commande2 += "YEAR(DateDeVente) =" + Convert.ToInt32(Year) + "  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }
                if (Mois != null)
                {
                    try
                    {
                        if (Year == null) comm += " MONTH(DateDeVente)  , DAY(DateDeVente)  ,";
                        else comm += " DAY(DateDeVente)  ,";
                        commande2 += "MONTH(DateDeVente) =" + Convert.ToInt32(Mois) + "  , ";
                        cond = true;
                    }
                    catch
                    {
                        return null;
                    }
                }


                string chaine = (prix) ? "Quantite*Prix" : "Quantite";
                if (cond)
                {
                    commande = "select ";
                    commande += comm;
                    commande += " SUM(" + chaine + ") from " + pTableName + " where ";
                    commande += commande2.Remove(commande2.Length - 3).Replace(",", "AND");
                    commande += " group by " + comm.Remove(comm.Length - 1);
                    commande += " order by " + comm.Remove(comm.Length - 1);

                }
                else return @"select Year( DateDeVente )  , SUM(" + chaine + @" )  from view_tab_restitue_med   group by Year(DateDeVente)  order by  Year( DateDeVente ) DESC  ";
                return commande;
            }
           
            /*********************************************************************************************************************************************************************************/
            public static string Cmd_select_stock(string pTableName, object DateDeProduction, object DateDePeremption, object Quantite, object Prix, object Tab_medID)
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
            public static string Cmd_Delete_stock(string pTableName, object DateDeProduction, object DateDePeremption, object Quantite, object Prix, object Tab_medID)
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


            public static void Insertion_Med(string pServer, string pDatabase, string pTableName, string DCI, string Marque, int Forme, float Dosage, int Categorie, int Effet_Therapeutique, int Remboursement, int Oriente, int Restitue, int Rupture)
            {
                SqlDataReader reader = null;

                try
                {
                    SqlConnection cn = new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
                    SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_Insert_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture)  /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                    cn.Open();
                    reader = cmd.ExecuteReader();


                }
                catch (Exception ex)
                {
                    hasException = true;
                    exceptionMessage = ex.Message;
                }



            }
            //**********************************************************************************************************************
            public static SqlDataReader Recherche_Med(SqlConnection cn, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
            {
                SqlDataReader reader = null;

                try
                {

                    SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_select_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                    cn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows) return reader;

                }
                catch (Exception ex)
                {
                    hasException = true;
                    exceptionMessage = ex.Message;

                }


                return reader;
            }
            //**********************************************************************************************************************
            public static bool Delete_Med(SqlConnection cn, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
            {

                try
                {

                    SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = Cmd_Delete_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                    cn.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        Console.WriteLine(reader[1]);
                    if (reader.HasRows) return true;
                    //return cmd.ExecuteNonQuery() > 0;


                }
                catch (Exception ex)
                {
                    hasException = true;
                    exceptionMessage = ex.Message;


                }
                return false;


            }
            //**********************************************************************************************************************

            //**********************************************************************************************************************
            /// <summary>
            /// Determine if a table exist
            /// </summary>
            /// <param name="pServer">An available server</param>
            /// <param name="pDatabase">An existing database</param>
            /// <param name="pTableName">Table name to check if exists or not</param>
            /// <returns></returns>
            public static bool TableExists(string pServer, string pDatabase, string pTableName)
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
            public static SqlDataReader Search()
            {
                return null;
            }
            public static List<string> TableNames(string pServer, string pDatabase)
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
            public static async Task<bool> SqlServerIsAvailable()
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
            public static SqlConnection Connect(string pServer, string pDatabase)
            {
                return new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
            }

            /*********************************************************************************************************************************************************************************/

            public static bool Insert_Med(SqlConnection conn, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
            {
                SqlCommand cmd = new SqlCommand { Connection = conn, CommandText = Cmd_Insert_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                conn.Open();
                //Console.Write(cmd.CommandText);
                try
                {
                    int ligne = cmd.ExecuteNonQuery();
                    Console.WriteLine(ligne);
                    if (ligne != 0) return true;
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

            public static async Task<bool> SqlServerIsAvailable(string pServerName)
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
            public static int Dec_Stock(string pTableName, int ID, int n)
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
                    success = 0;
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
                        success = 0;
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
                                cmd = new SqlCommand(" UPDATE TabRestitue SET Quantite=" + str.Quant + " WHERE ID = " + str.Id, cn);
                                cmd.ExecuteNonQuery();
                            }
                            else //delete
                            {
                                cmd = new SqlCommand(" DELETE From TabRestitue WHERE ID = " + str.Id, cn);
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
                    success = 0;
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
            public static int Incr_Stock(string pTableName, int ID, int n, DateTime DateDeProduction, DateTime DateDePeremption, int Prix)
            {

                int quant = 0;
                int success = 1;
                SqlConnection cn = Connect(".\\SQLEXPRESS", "mydb");
                cn.Open();
                SqlCommand cmd = new SqlCommand(Cmd_select_stock(pTableName, DateDeProduction, DateDePeremption, null, Prix, ID), cn);
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
                        cmd = new SqlCommand(Cmd_Insert_stock(pTableName, DateDeProduction, DateDePeremption, n, Prix, ID), cn);
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
            public static string Former_commande_stat_mois(int year)
            {
                string commande = "";
                commande = @"select  MONTH(DateDeVente) as the_month , DAY(DateDeVente) as the_day,  SUM(Quantite * 

Prix) as interet from view_tab_med where  year(dateDeVente) = " + year.ToString() + @"  group by MONTH(DateDeVente),DAY

(DateDeVente)  order by  MONTH(DateDeVente)  DESC,DAY(DateDeVente)  DESC";
                return commande;

            }
            /*       public string Former_commande_stat_days(int year,int month)
                    {
                        string commande = "";
                        commande = @"select  MONTH(DateDeVente) as the_month , DAY(DateDeVente) as the_day,  SUM(Quantite * 

            Prix) as interet from view_tab_med where  year(dateDeVente) = " + year.ToString() + @"  group by MONTH(DateDeVente),DAY

            (DateDeVente)  order by  MONTH(DateDeVente)  DESC,DAY(DateDeVente)  DESC";
                        return commande;

                    }*/
            public static bool ajout_list_med(SqlConnection cn, List<medID_qunt> lis, int REST, int n, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
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
                if (reader != null) reader.Close();
                if (ID != 0)
                {
                    if (REST == 1)
                    {
                        SqlCommand cmd = new SqlCommand(Cmd_select_stock("TabRestitue", null, null, null, null, ID), cn);
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
                        SqlCommand cmd = new SqlCommand(Cmd_select_stock("Tab_NEW", null, null, null, null, ID), cn);
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
            public static LiveCharts.ChartValues<double> plotlist2(SqlConnection cn, object year, object month, bool day)
            {
                var list = new List<double>();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                double order = 0;
                cmd.CommandText = Cmd_stat("view_tab_med", year, month, day);

                SqlDataReader reader = cmd.ExecuteReader();
                bool cond = ((year != null && month == null) || (year == null && month != null));
                if (reader.HasRows)
                {
                    int s = 2;
                    if (year != null) s++; if (month != null) s++;
                    double first = 0;
                    while (reader.Read())
                    {

                        first = Convert.ToDouble(reader[s - 2]);
                        double second = Convert.ToDouble(reader[s - 1]);
                        while (order < first - 1 && s > 2)
                        {
                            order++;
                            list.Add(0);
                        }
                        list.Add(second);
                        order++;





                    }






                }
                list.Add(50);
                if (cond)
                {
                    while (order < 12)
                    {
                        list.Add(0); order++;

                    }
                }
                if (year != null && month != null) while (order < 31)
                    {
                        list.Add(0); order++;

                    }
                return new LiveCharts.ChartValues<double>(list);
            }
       
            public  static List<OxyPlot.DataPoint> plotlist(SqlConnection cn ,object year , object month,bool day ){
            	var list = new List<OxyPlot.DataPoint>();
            	SqlCommand cmd = new SqlCommand();
            	cmd.Connection = cn;
            	double order=0;
            	cmd.CommandText = Cmd_stat("view_tab_med", year, month, day);

				SqlDataReader reader = cmd.ExecuteReader();
				 bool cond = ((year != null && month == null   ) || (year == null && month != null   ));
                if (reader.HasRows)
                {
                	int s=2;
                	if(year!=null)s++;if(month!=null)s++;
                    double first=0;
                    while (reader.Read())
                    {
                    	
                    	 first = Convert.ToDouble(reader[s-2]);
                    	 while(order<first-1  && s >2  ){
                    	 	order++;
                    	 	list.Add(new OxyPlot.DataPoint(order,0));
                    	}
                       	list.Add(new OxyPlot.DataPoint(first,Convert.ToDouble(reader[s-1])));
                       	order++;
                       	
                       	
                       

                        
                    }
                    
                   
                    
                    	
                   
                    	
                }  
                 if(cond){
                	while(order<12){
                    		list.Add(new OxyPlot.DataPoint(++order,0));
                    		
                    	}
                }
                 if(year != null && month != null ) while(order<31){
                    		list.Add(new OxyPlot.DataPoint(++order,0));
                    		
                    	}
                return list;
            }
            public static List<LiveCharts.Defaults.ObservablePoint> plotlist3(SqlConnection cn, object year, object month, bool day)
            {
                var list = new List<LiveCharts.Defaults.ObservablePoint>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                double order = 0;
                cmd.CommandText = Cmd_stat("view_tab_med", year, month, day);

                SqlDataReader reader = cmd.ExecuteReader();
                bool cond = ((year != null && month == null) || (year == null && month != null));
                if (reader.HasRows)
                {
                    int s = 2;
                    if (year != null) s++; if (month != null) s++;
                    double first = 0;
                    while (reader.Read())
                    {

                        first = Convert.ToDouble(reader[s - 2]);
                        while (order < first - 1 && s > 2)
                        {
                            order++;
                            list.Add(new LiveCharts.Defaults.ObservablePoint(order, 0));
                        }
                        list.Add(new LiveCharts.Defaults.ObservablePoint(first, Convert.ToDouble(reader[s - 1])));
                        order++;





                    }






                }
                if (cond)
                {
                    while (order < 12)
                    {
                        list.Add(new LiveCharts.Defaults.ObservablePoint(++order, 0));

                    }
                }
                if (year != null && month != null) while (order < 31)
                    {
                        list.Add(new LiveCharts.Defaults.ObservablePoint(++order, 0));

                    }
                return list;
            }
            public static List<LiveCharts.Defaults.ObservablePoint> plotlist3_restitue(SqlConnection cn, object year, object month, bool day)
            {
                var list = new List<LiveCharts.Defaults.ObservablePoint>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                double order = 0;
                cmd.CommandText = Cmd_stat_restitue("view_tab_restitue_med", year, month, day);

                SqlDataReader reader = cmd.ExecuteReader();
                bool cond = ((year != null && month == null) || (year == null && month != null));
                if (reader.HasRows)
                {
                    int s = 2;
                    if (year != null) s++; if (month != null) s++;
                    double first = 0;
                    while (reader.Read())
                    {

                        first = Convert.ToDouble(reader[s - 2]);
                        while (order < first - 1 && s > 2)
                        {
                            order++;
                            list.Add(new LiveCharts.Defaults.ObservablePoint(order, 0));
                        }
                        list.Add(new LiveCharts.Defaults.ObservablePoint(first, Convert.ToDouble(reader[s - 1])));
                        order++;





                    }






                }
                if (cond)
                {
                    while (order < 12)
                    {
                        list.Add(new LiveCharts.Defaults.ObservablePoint(++order, 0));

                    }
                }
                if (year != null && month != null) while (order < 31)
                    {
                        list.Add(new LiveCharts.Defaults.ObservablePoint(++order, 0));

                    }
                return list;
            }
            
        }

 /*       public class Program
        {

            public static void Main(string[] args)
            {
                RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                {
                    RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                    if (instanceKey != null)
                    {
                        foreach (var instanceName in instanceKey.GetValueNames())
                        {
                            Console.WriteLine(Environment.MachineName + @"\" + instanceName);
                        }
                    }
                }
                string pServerName = @".\SQLEXPRESS";
                string pDataBase = "mydb";
                string pTableName = "Tab_med";
                Database d = new Database();
                List<medID_qunt> lis = new List<medID_qunt>();
                SqlConnection cn = d.Connect(pServerName, pDataBase);
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"ALTER TRIGGER first_trigger_test4
on Tab_Med
ON  DELETE
AS
insert into Tab_med (Marque,DCI) values ('hello','param');select * from deleted;select * from Tab_med; insert into Tab_med  (select * from deleted ) ", cn);
                SqlDataReader reader = d.Recherche_Med(d.Connect(pServerName, pDataBase), pTableName, null, "hello", null, null, null, null, null, null, null, null);
                Console.WriteLine(reader.HasRows);
                cmd.CommandText = d.Cmd_stat("view_tab_med", null, null, true);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    object[] table;
                    //Console.WriteLine(reader[0]);
                    while (reader.Read())
                    {
                        table = new object[12];
                        reader.GetValues(table);
                        foreach (object o in table)
                        {
                            Console.Write(o);
                            Console.Write("\t");
                        }

                        Console.WriteLine();
                    }
                }
                //Console.WriteLine("list :"+ d.ajout_list_med(cn, lis, 1, 4, "para","gripex",5,12,true,5,false,true,true,true));
                //Console.WriteLine( d.Incr_Stock("TabRestitue",1012,20,Convert.ToDateTime("12/1/2017"),Convert.ToDateTime("12/04/2017"),12));
                //Console.WriteLine(d.Dec_Stock("TabRestitue",1014,2));
                Console.WriteLine(d.Insert_Med(d.Connect(pServerName, pDataBase), pTableName, "paracetamolo", "dije", null, null, null, null, true, false, null, null));
                Console.WriteLine(d.Delete_Med(d.Connect(pServerName, pDataBase), pTableName, "paracetamolo", "dije", null, null, null, null, true, false, null, null));
                Console.ReadKey();
                cn.Close();
            }
        }*/
    }

}
