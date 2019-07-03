using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using DataLibrary;

namespace facture
{
    class Tab_Med
    {
        private int Tab_MedID;
        public int tab_MedID
        {
            get { return Tab_MedID; }
            set { Tab_MedID = value; }
        }
        private String DCI;
        public String dci
        {
            get { return DCI; }
            set { DCI = value; }
        }
        private String Marque;
        public String marque
        {
            get { return Marque; }
            set { Marque = value; }
        }
        private Object forme;
        public Object Forme
        {
            get { return forme; }
            set { forme = value; }
        }
        private Object dosage;
        public Object Dosage
        {
            get { return dosage; }
            set { dosage = value; }
        }
        private Object categorie;
        public Object Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
        private Object Effet_Therapeutique;
        public Object effet_Therapeutique
        {
            get { return Effet_Therapeutique; }
            set { Effet_Therapeutique = value; }
        }
        private Object Remboursement;
        public Object remboursement
        {
            get { return Remboursement; }
            set { Remboursement = value; }
        }
        private Object Oriente;
        public Object oriente
        {
            get { return Oriente; }
            set { Oriente = value; }
        }
        private Boolean Restitue;
        public Boolean restitue
        {
            get { return Restitue; }
            set { Restitue = value; }
        }
        private Object Rupture;
        public Object rupture
        {
            get { return Rupture; }
            set { Rupture = value; }
        }



        string exceptionMessage;
        public string ExceptionMessage { get { return exceptionMessage; } }
        bool hasException;
        public bool HasException { get { return hasException; } }
        Database datab = new Database();


        public void Insertion_Med(SqlConnection cn, string pTableName)
        {
            SqlDataReader reader = null;

            try
            {

                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = datab.Cmd_Insert_Med(pTableName, DCI, Marque, forme, dosage, categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, rupture) };
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
        public SqlDataReader Recherche_Med(SqlConnection cn, string pTableName)
        {
            SqlDataReader reader = null;

            try
            {
                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = datab.Cmd_select_Med(pTableName, DCI, Marque, forme, dosage, categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) };
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
        public void Delete_Med(SqlConnection cn, string pTableName)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = datab.Cmd_Delete_Med(pTableName, DCI, Marque, forme, dosage, categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, rupture) };
                cn.Open();
                reader = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                hasException = true;
                exceptionMessage = ex.Message;

            }

        }
        public void Delete_Medi(SqlConnection cn, string pServer, string pDatabase, string pTableName, string DCI, string Marque, object Forme, object Dosage, object Categorie, object Effet_Therapeutique, object Remboursement, object Oriente, object Restitue, object Rupture)
        {

            SqlDataReader reader = null;
            try
            {
                cn = new SqlConnection { ConnectionString = ("Data Source=" + (pServer + ";Initial Catalog=" + pDatabase + ";Integrated Security=True;")) };
                SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = datab.Cmd_Delete_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ };
                cn.Open();
                Console.WriteLine(datab.Cmd_Delete_Med(pTableName, DCI, Marque, Forme, Dosage, Categorie, Effet_Therapeutique, Remboursement, Oriente, Restitue, Rupture) /*("select * from Tab_med where DCI ='hamza'" /* where name='" + (pDatabase + "'")*/ );
                reader = cmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                hasException = true;
                Console.WriteLine("erreur");
                exceptionMessage = ex.Message;

            }



        }




    }
}
