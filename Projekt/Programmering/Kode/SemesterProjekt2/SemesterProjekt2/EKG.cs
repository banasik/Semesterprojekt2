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
       private Gem_måling gem;
       private Logiklag logik;
       private List<double> liste;
      public EKG(string cprNummer)
      {
         InitializeComponent();
         logik = new Logiklag();

         if (cprNummer != "")
         {
            textBox4.Text = cprNummer;
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
         logik.gemData(liste);
         gem = new Gem_måling();
         gem.ShowDialog();
      }

      private void textBox4_TextChanged(object sender, EventArgs e)
      {

      }
   }
}
