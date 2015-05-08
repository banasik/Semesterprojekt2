using System;
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

            cmd = new SqlCommand("select CPR From Patient", conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            { 
               CPR = rdr.GetString(0);
               CPRliste.Add(CPR); 
            }
            conn.Close();
            return CPRliste;
        }
        public Person GetPersonMedCPR(string Cprnummer)
        {
           Person p = new Person();
            //Validering om CPRnummer er korrekt?
            
            conn.Open();

            cmd = new SqlCommand("select Navn, CPR, PatientID From Patient where CPR = '"+Cprnummer+"'", conn);
           
            //SqlParameter param = new SqlParameter();
            //param.ParameterName = "@cprNummer_in";
            //param.Value = Cprnummer;


            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
               p.navn = rdr.GetString(0);
               p.CPR = rdr.GetString(1);
               p.ID = Convert.ToInt32(rdr.GetValue(2));

               //p.PatientsMålinger = HentMålingerFraPatientID(p.ID);
            }

            conn.Close();
            return p;
        }

        public bool GemMålingPåPerson(int patientID, byte[] måling, DateTime tidForMåling)
        {
           conn.Open();

           cmd = new SqlCommand("insert into måling(Målinger, PatientId, Dato) values (@Måling_in, @PatientID_in, @Dato_in)", conn);

           SqlParameter param1 = new SqlParameter(); //Pakker ind og gemmer blok, uden at pakke ud.
           param1.ParameterName = "@Måling_in";
           param1.Value = måling;
           cmd.Parameters.Add(param1);

           SqlParameter param2 = new SqlParameter();
           param2.ParameterName = "@PatientID_in";
           param2.Value = patientID;
           cmd.Parameters.Add(param2);

           SqlParameter param3 = new SqlParameter();
           param3.ParameterName = "@Dato_in";
           param3.Value = tidForMåling;
           cmd.Parameters.Add(param3);

           int antalRækkerSatInd = cmd.ExecuteNonQuery();
           
           conn.Close();

           if (antalRækkerSatInd > 0)
           { return true; }
           else
           { return false; }
        }

       /*public Målinger HentMålingerFraPatientID(int ID_in)
       {
          //
       }*/

       /*public bool FlytTilSQL()
       {
          byte[] målinger = new byte[3000];
          using (SqlConnection connection = new SqlConnection("ConnectionString")) 
          { 
             SqlParameter param;
                        
                connection.Open(); 
                using(SqlCommand cmd = new SqlCommand("INSERT INTO Patient(CPR, Måling, Navn, Dato) VALUES (@CPR, @Måling, @Navn, @Dato)", conn)) 
                { 
                        
                     param = new SqlParameter();
                     param.DbType = System.Data.DbType.String;
                     param.ParameterName = "@CPR";
                     param.Value = "1111111-1111";
                     cmd.Parameters.Add(param);

                     param = new SqlParameter();
                     param.DbType = System.Data.DbType.Byte;
                     param.ParameterName = "@Måling";
                     param.Value = målinger;
                     cmd.Parameters.Add(param);

                     //cmd.Parameters.Add("@CPR", sqlDbType.Nvarvhar) Value =; 
                     //cmd.Parameters.Add("@Måling", SqlDbType.VarBinary).Value = ByteArray; 
                     //cmd.Parameters.Add("@Navn", SqlDbType.NVarchar).Value = "Any text Description"; 
                     cmd.ExecuteNonQuery();
               } 
         }

          return true;
      }*/

    }
}