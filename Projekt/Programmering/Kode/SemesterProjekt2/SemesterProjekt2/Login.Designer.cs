﻿namespace SemesterProjekt2
{
   partial class Login
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.button1 = new System.Windows.Forms.Button();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(169, 172);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(96, 21);
         this.button1.TabIndex = 0;
         this.button1.Text = "Login";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click_1);
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(50, 45);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(179, 20);
         this.textBox1.TabIndex = 1;
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(50, 98);
         this.textBox2.MaxLength = 4;
         this.textBox2.Name = "textBox2";
         this.textBox2.PasswordChar = '*';
         this.textBox2.Size = new System.Drawing.Size(179, 20);
         this.textBox2.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(47, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(88, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Indtast username";
         this.label1.Click += new System.EventHandler(this.label1_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(47, 82);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(87, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Indtast password";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(50, 141);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(0, 13);
         this.label3.TabIndex = 5;
         // 
         // Login
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(293, 205);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.textBox2);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.button1);
         this.Name = "Login";
         this.Text = "Login";
         this.Load += new System.EventHandler(this.Login_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
   }
}