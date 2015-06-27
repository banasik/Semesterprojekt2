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
   public partial class Login : Form
   {

      private Logiklag logik;
      private CPR_nummer CPR_GUI;

      public Login()
      {
         InitializeComponent();
         logik = new Logiklag();
      }

      
      private void tjekLogin(string navn, int kode)
      {

         if (logik.getKode(navn, kode))
         {
            CPR_GUI = new CPR_nummer();
            Hide();
            CPR_GUI.ShowDialog();
            
         }

         else
         {
            label3.Text = "Fejl i username og/eller password";
         }

      }
             
      private void button1_Click_1(object sender, EventArgs e)
      {
          tjekLogin(textBox1.Text, Convert.ToInt32(textBox2.Text));
      }

      private void Login_Load(object sender, EventArgs e)
      {

      }
   }
}
