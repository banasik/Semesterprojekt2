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
   public partial class Gem_måling : Form
   {
      private EKG ekg;
      public Gem_måling()
      {
         InitializeComponent();
      }

      private void label1_Click(object sender, EventArgs e)
      {

      }

      private void button1_Click(object sender, EventArgs e)
      {
         ekg = new EKG("");
         Hide();
         ekg.ShowDialog();
      }
   }
}
