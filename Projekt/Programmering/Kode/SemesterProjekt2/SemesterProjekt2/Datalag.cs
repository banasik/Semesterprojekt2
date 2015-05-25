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
        private SqlConnection conn2;
        private SqlDataReader rdr;
        private SqlCommand cmd;
        private const String db = "F15ST2ITS2201405722";
        private const String db2 = "F15ST2PRJ2OffEKGDatabase";
        private List<string> CPRliste; //bruges ved getCPR()


               

        public Datalag()
        {
            // Opsætning af DB forbindelsen til SQL Server webhotel10.iha.dk og valgt database (db)
            conn = new SqlConnection("Data Source=webhotel10.iha.dk;Initial Catalog=" + db + ";Persist Security Info=True;User ID=" + db + ";Password=" + db + "");
            conn2 = new SqlConnection("Data Source=10.29.0.29;Initial Catalog=" + db2 + ";Persist Security Info=True;User ID=" + db2 + ";Password=" + db2 + "");
            CPRliste = new List<string>();
        }

        public int getKode(string navn) //Slår den indtastet kode op
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

        public List<string> GetCPR() //Slår det indtastet CPR nr op
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
        public Person GetPersonMedCPR(string Cprnummer) //Slår person op på baggrund af CPR nr
        {
           Person p = new Person();
            
            conn.Open();

            cmd = new SqlCommand("select Navn, CPR, PatientID From Patient where CPR = '"+Cprnummer+"'", conn);
           
            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
               p.navn = rdr.GetString(0);
               p.CPR = rdr.GetString(1);
               p.ID = Convert.ToInt32(rdr.GetValue(2));

            }

            conn.Close();
            return p;
        }

        public bool GemMålingPåPerson(int patientID, byte[] måling, DateTime tidForMåling) //Gemmer måling i privat db
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


        public bool GemEKGDATA(byte[] måling, float samplerate_hz, long interval_sek, string data_format, string bin_eller_tekst, string maaleformat_type, DateTime start_tid) // gemmer til offentlig db
        {

           conn2.Open();

           cmd = new SqlCommand("insert into EKGDATA(raa_data, samplerate_hz, interval_sec, data_format, bin_eller_tekst, maaleformat_type, start_tid) values (@raa_data, @samplerate_hz, @interval_sec, @data_format, @bin_eller_tekst, @maaleformat_type, @start_tid)", conn2);

           SqlParameter param1 = new SqlParameter();
           param1.ParameterName = "@raa_data";
           param1.Value = måling;
           cmd.Parameters.Add(param1);

           SqlParameter param2 = new SqlParameter();
           param2.ParameterName = "@samplerate_hz";
           param2.Value = samplerate_hz;
           cmd.Parameters.Add(param2);

           SqlParameter param3 = new SqlParameter();
           param3.ParameterName = "@interval_sec";
           param3.Value = interval_sek;
           cmd.Parameters.Add(param3);

           SqlParameter param4 = new SqlParameter();
           param4.ParameterName = "@data_format";
           param4.Value = "CSV";
           cmd.Parameters.Add(param4);

           SqlParameter param5 = new SqlParameter();
           param5.ParameterName = "@bin_eller_tekst";
           param5.Value = "b";
           cmd.Parameters.Add(param5);

           SqlParameter param6 = new SqlParameter();
           param6.ParameterName = "@maaleformat_type";
           param6.Value = "double";
           cmd.Parameters.Add(param6);

           SqlParameter param7 = new SqlParameter();
           param7.ParameterName = "@start_tid";
           param7.Value = start_tid;
           cmd.Parameters.Add(param7);


           int antalRækkerSatInd = cmd.ExecuteNonQuery();

           conn2.Close();

           if (antalRækkerSatInd > 0)
           { return true; }
           else
           { return false; }
        }

        public bool GemEKGMaeling(DateTime dato, int antalmaalinger, string sfp_ansvrmedarbjnr, string sfp_ans_org) //gemmer til offentlig db
        {
           conn2.Open();

           cmd = new SqlCommand("insert into EKGMAELING(dato, antalmaalinger, sfp_ansvrmedarbjnr, sfp_ans_org) values (@dato, @antalmaalinger, @sfp_ansvrmedarbjnr, @sfp_ans_org)", conn2);

           SqlParameter param1 = new SqlParameter();
           param1.ParameterName = "@dato";
           param1.Value = dato;
           cmd.Parameters.Add(param1);

           SqlParameter param2 = new SqlParameter();
           param2.ParameterName = "@antalmaalinger";
           param2.Value = antalmaalinger;
           cmd.Parameters.Add(param2);

           SqlParameter param3 = new SqlParameter();
           param3.ParameterName = "@sfp_ansvrmedarbjnr";
           param3.Value = sfp_ansvrmedarbjnr;
           cmd.Parameters.Add(param3);

           SqlParameter param4 = new SqlParameter();
           param4.ParameterName = "@sfp_ans_org";
           param4.Value = sfp_ans_org;
           cmd.Parameters.Add(param4);

           int antalRækkerSatInd = cmd.ExecuteNonQuery();
           
           conn2.Close();

           if (antalRækkerSatInd > 0)
           { return true; }
           else
           { return false; }
        }
       

    }
}