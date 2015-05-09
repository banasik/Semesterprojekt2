﻿using System;
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
       private Login Login;
       private Logiklag logik;
       private List<double> liste;
       private Gem_måling gem;

              
       //"Datamodel"
       private Person p;
       
       

      public EKG(string CPR)
      {
         InitializeComponent();
         logik = new Logiklag();
         

         textBox4.Text = CPR;    //Viser CPR nummer i EKG vinduet


         if (CPR == "")
         {
            //CPR er tom, skal måske tilbage til "angiv CPR"-skærm
            p = new Person();
         }
         else
         {
            p = logik.HentPersonMedCPR(CPR);
            textBox3.Text = p.navn;
         }
      }

      private void button4_Click(object sender, EventArgs e)
      {
          Login = new Login();
          Hide();
          Login.ShowDialog();
      }

      private void button3_Click(object sender, EventArgs e) //"Start ny måling"
      {
         liste = logik.kørEKG();
         chart1.Series["EKG"].Points.DataBindY(liste);
      }


      private void button1_Click(object sender, EventArgs e)
      {
         
      }

      private void textBox4_TextChanged(object sender, EventArgs e)
      {
          
          chart1.Series["EKG"].Points.DataBindY(logik.kørEKG());
      }

      private void button1_Click_1(object sender, EventArgs e)
      {
          liste = logik.datacollector.currentVoltageSeq;
          //patientID = 

          logik.gemMålingPåPerson(p.ID, liste, DateTime.Now);

          gem = new Gem_måling();

          gem.ShowDialog();
      }

      private void button2_Click(object sender, EventArgs e)
      {

      }

      private void textBox4_TextChanged_1(object sender, EventArgs e)
      {

      }

      private void chart1_Click(object sender, EventArgs e)
      {

      }

      private void textBox3_TextChanged(object sender, EventArgs e)
      {

      }
   }
}
