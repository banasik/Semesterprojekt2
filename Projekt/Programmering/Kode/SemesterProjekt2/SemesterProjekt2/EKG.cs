using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjekt2
{
   public partial class EKG : Form
   {
       private Login Login;         //login objekt bruges til at kunne logge ud
       private Logiklag logik;      //Bruges til at hente metoder fra logiklag
       private List<double> liste;  //liste som bruges til at holde data om måling
       private Gem_måling gem;      //bruges til at hente formen "gem måling"

              
       //"Datamodel"
       private Person p;            //DTO - indeholder info om person
       

      //Variabler til tabellen EKGData i offentlig database
      private int HZ = 250;
      private int interval_sek = 10;
      private string data_format = ",";
      private string bin_eller_tekst = "bin";
      private string maaleformat_type = ",";
      
      //Variabler til tabellen EKGMaelinger i offentlig database
      private int antal_maalinger = 1;
      private string medarbejdernr = "Leder";
      private string organisation = "IHA";

      public EKG(string CPR) //Konstruktor
      {
         InitializeComponent();
         logik = new Logiklag();

         button1.Enabled = false;   //deaktivere knappen "Gem ny måling"
         textBox4.Text = CPR;       //Viser CPR nummer i EKG vinduet


         if (CPR == "")
         {
            p = new Person();       //opretter ny person - men vores program understøtter ikke den funktion
         }
         else
         {
            p = logik.HentPersonMedCPR(CPR);    //henter allerede person
            textBox3.Text = p.navn;             //udfylder tekstboxen "Navn på patienten" - f.eks Sara
         }
      }

      private void button4_Click(object sender, EventArgs e) //"log ud" knap
      {
          Login = new Login();              //atributten login sættes til at være et nyt log in vindue
          Hide();                           //gemmer EKG vindue
          Login.ShowDialog();               //viser log ind vindue
      }

       
       
      private void button3_Click(object sender, EventArgs e) //"Start ny måling" knap
      {
          chart1.Series["EKG"].Points.Clear();          //chart nulstilles
          Cursor.Current = Cursors.WaitCursor;          //cursor viser "tænker"

          button3.Enabled = false;                      //deaktivere knappen "Start ny måling"
         
        

         liste = logik.kørEKG();                        //metoden "kørEKG()" køres
         
         for (int i = 0; i < liste.Count; i++)  //liste løbes igennem
         {
             chart1.Series["EKG"].Points.AddXY((double)i * 0.004, liste[i]);  //tilføjer punkter i grafen -- 0.004 * samples = sekunder
         }

         //logik.analyseSig(); //analyse af EKG signal
         if(logik.analyseSig() == true) //resultatet fra analysen
          {
              textBox5.Text = "Tjek for Atrieflimmer!!"; 
          }
          else
          {
              textBox5.Text = "Sundt EKG"; 
          }

          textBox1.Text = Convert.ToString(logik.getPuls()); //pulsen vises i puls tekstboksen
            

          button3.Enabled = true;  //knappen "Start ny måling" aktiveres
          button1.Enabled = true;  //knappen "Gem ny måling" aktiveres
 
      }

      private void button1_Click_1(object sender, EventArgs e) //knappen "Gem ny måling"
      {
          Cursor.Current = Cursors.WaitCursor;              //cursor viser "tænker"
          liste = logik.datacollector.currentVoltageSeq;    //listen fra DAQ vis ref. ST2Prj2LibNI-DAQ 

          logik.gemMålingPåPerson(p.ID, liste, DateTime.Now);                                                       //måling gemmes i privat db
          logik.GemEKGDATA(liste, HZ , interval_sek, data_format, bin_eller_tekst, maaleformat_type, DateTime.Now); //måling gemmes i offentlig db
          logik.GemEKGMaeling(DateTime.Now, antal_maalinger, medarbejdernr, organisation);                          //måling gemmes i offentlig db

          gem = new Gem_måling();   //atributten gem sættes til at være et nyt gem vindue

          gem.ShowDialog();         //vindue "gem måling" vises
      }

      private void EKG_Load(object sender, EventArgs e)
      {

      }

        

     
   }
}
