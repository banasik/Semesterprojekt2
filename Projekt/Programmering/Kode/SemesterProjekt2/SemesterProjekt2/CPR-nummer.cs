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
   public partial class CPR_nummer : Form
   {

       private Logiklag logik;
       private EKG EKG;

      public CPR_nummer()
      {
         InitializeComponent();
         logik = new Logiklag();
      }

       private void tjekCPR(string CPR)
      {
          if (logik.checkCPR(CPR))
          {
              EKG = new EKG(CPR);
              Hide();
              EKG.ShowDialog();
              Show();
          }

          else
          {
              label2.Text = "Ugyldigt CPR-nummer - indtast nyt";
          }
      }

      private void label1_Click(object sender, EventArgs e)
      {

      }

      private void button1_Click(object sender, EventArgs e)
      {
          tjekCPR(textBox1.Text);
      }
   }
}
