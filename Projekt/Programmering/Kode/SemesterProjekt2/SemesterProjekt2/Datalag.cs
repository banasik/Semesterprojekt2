using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SemesterProjekt2
{
    class Datalag
    {
       private SqlConnection conn;
       private SqlDataReader rdr;
       private SqlCommand cmd;
       private const String db = "F15ST2ITS2201405722"; 

       // private List<BS_DTO> bsList;
       // private List<BT_DTO> btList;
       
       public int getKode(string navn)
       {
          int resultat = 0;
          cmd = new SqlCommand("select Kode from Login where Navn ='"+ navn +"'", conn);
          conn.Open();
          rdr = cmd.ExecuteReader();

          if (rdr.Read())
          {
             resultat = rdr.GetInt32(0);
          }

          conn.Close();
          return resultat;
       }
    }
}
