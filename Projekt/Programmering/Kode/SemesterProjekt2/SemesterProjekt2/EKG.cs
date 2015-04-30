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
       private Login Login;
       private Logiklag logik;
      public EKG()
      {
         InitializeComponent();
         logik = new Logiklag(); 
      }

      private void button4_Click(object sender, EventArgs e)
      {
          Login = new Login();
          Hide();
          Login.ShowDialog();
      }

      private void button3_Click(object sender, EventArgs e) //"Start ny måling"
      {
<<<<<<< HEAD
         liste = logik.kørEKG();
          chart1.Series["EKG"].Points.DataBindY(liste);
      }


      private void button1_Click(object sender, EventArgs e)
      {
         liste = new List<double>();

         for (int i = 0; i < 3000; i++)
         {
            liste.Add(3.01);
         }

         logik.gemMålingPåPerson(2, liste, DateTime.Now);
         
         gem = new Gem_måling();
         
         gem.ShowDialog();
      }

      private void textBox4_TextChanged(object sender, EventArgs e)
      {

=======
          chart1.Series["EKG"].Points.DataBindY(logik.kørEKG());
>>>>>>> origin/Programmering
      }
   }
}
