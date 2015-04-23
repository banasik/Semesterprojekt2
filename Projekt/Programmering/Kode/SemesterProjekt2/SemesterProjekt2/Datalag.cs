﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;   //SQL forbindelse

namespace SemesterProjekt2
{
    class Datalag
    {
        private SqlConnection conn;
        private SqlDataReader rdr;
        private SqlCommand cmd;
        private const String db = "F15ST2ITS2201405722";
        private List<string> CPRliste;  
               

        public Datalag()
        {
            // Opsætning af DB forbindelsen til SQL Server webhotel10.iha.dk og valgt database (db)
            conn = new SqlConnection("Data Source=webhotel10.iha.dk;Initial Catalog=" + db + ";Persist Security Info=True;User ID=" + db + ";Password=" + db + "");
            CPRliste = new List<string>();
        }

        public int getKode(string navn)
        {
            int resultat = 0;
            cmd = new SqlCommand("select Kode from Login where Navn ='" + navn + "'", conn);
            conn.Open();
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                resultat = rdr.GetInt32(0);
            }

            conn.Close();
            return resultat;
        }


        public List<string> GetCPR()
        {
            string CPR = "00";
            conn.Open();

            cmd = new SqlCommand("select * From CPR", conn);
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            { 
               CPR = rdr.GetString(0);
               CPRliste.Add(CPR); 
            }
            conn.Close();
            return CPRliste;
        }

       public bool FlytTilSQL()
       {
          using (SqlConnection connection = new SqlConnection("ConnectionString")) 
               { 
                     connection.Open(); 
                     using(SqlCommand cmd = new SqlCommand("INSERT INTO Patient(CPR, Måling, Navn, Dato) VALUES (@CPR, @Måling, @Navn, @Dato)", conn)) 
                { 

                     cmd.Parameters.Add("@CPR", sqlDbType.string) Value =; 
                     cmd.Parameters.Add("@Måling", SqlDbType.VarBinary).Value = ByteArray; 
                     cmd.Parameters.Add("@Navn", SqlDbType.NVarchar).Value = "Any text Description"; 
                     cmd.ExecuteNonQuery();
    } 
}   
       }

    }
}