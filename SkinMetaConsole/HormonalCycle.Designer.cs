using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Web.UI.WebControls;
using Guna.UI2.WinForms;
using System.Collections.Generic;

namespace SkinMetaConsole
{
    partial class HormonalCycle
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.labelMenstruation = new Guna.UI2.WinForms.Guna2CircleButton();
            this.labelOvulation = new Guna.UI2.WinForms.Guna2CircleButton();
            this.labelLuteal = new Guna.UI2.WinForms.Guna2CircleButton();
            this.labelFollicular = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel1.SuspendLayout();
            this.guna2CircleProgressBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.LightPink;
            this.guna2Panel1.Controls.Add(this.guna2CircleButton1);
            this.guna2Panel1.Controls.Add(this.guna2DateTimePicker1);
            this.guna2Panel1.Controls.Add(this.guna2TextBox1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.monthCalendar1);
            this.guna2Panel1.Controls.Add(this.guna2CircleProgressBar1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(802, 451);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.BorderThickness = 50;
            this.guna2CircleButton1.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.SeaShell;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Image = global::SkinMetaConsole.Properties.Resources.InShot_20250417_190932744;
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(26, 26);
            this.guna2CircleButton1.Location = new System.Drawing.Point(746, 9);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(30, 29);
            this.guna2CircleButton1.TabIndex = 47;
            this.guna2CircleButton1.UseTransparentBackground = true;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.LightCoral;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(506, 221);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(227, 36);
            this.guna2DateTimePicker1.TabIndex = 19;
            this.guna2DateTimePicker1.Value = new System.DateTime(2025, 5, 3, 14, 40, 27, 793);
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(475, 274);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(285, 152);
            this.guna2TextBox1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "OF THE MONTH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightPink;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 44);
            this.label3.TabIndex = 16;
            this.label3.Text = "HORMONAL PHASE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.PeachPuff;
            this.monthCalendar1.Location = new System.Drawing.Point(506, 47);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.Controls.Add(this.labelMenstruation);
            this.guna2CircleProgressBar1.Controls.Add(this.labelOvulation);
            this.guna2CircleProgressBar1.Controls.Add(this.labelLuteal);
            this.guna2CircleProgressBar1.Controls.Add(this.labelFollicular);
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.FloralWhite;
            this.guna2CircleProgressBar1.FillThickness = 10;
            this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(69, 69);
            this.guna2CircleProgressBar1.Minimum = 0;
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(360, 360);
            this.guna2CircleProgressBar1.TabIndex = 3;
            this.guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // labelMenstruation
            // 
            this.labelMenstruation.BackColor = System.Drawing.Color.Transparent;
            this.labelMenstruation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.labelMenstruation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.labelMenstruation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.labelMenstruation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.labelMenstruation.FillColor = System.Drawing.Color.Bisque;
            this.labelMenstruation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelMenstruation.ForeColor = System.Drawing.Color.Black;
            this.labelMenstruation.Location = new System.Drawing.Point(216, 3);
            this.labelMenstruation.Name = "labelMenstruation";
            this.labelMenstruation.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.labelMenstruation.Size = new System.Drawing.Size(118, 122);
            this.labelMenstruation.TabIndex = 4;
            this.labelMenstruation.Text = "Menstruation Phase";
            this.labelMenstruation.UseTransparentBackground = true;
            // 
            // labelOvulation
            // 
            this.labelOvulation.BackColor = System.Drawing.Color.Transparent;
            this.labelOvulation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.labelOvulation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.labelOvulation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.labelOvulation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.labelOvulation.FillColor = System.Drawing.Color.Bisque;
            this.labelOvulation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelOvulation.ForeColor = System.Drawing.Color.Black;
            this.labelOvulation.Location = new System.Drawing.Point(21, 242);
            this.labelOvulation.Name = "labelOvulation";
            this.labelOvulation.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.labelOvulation.Size = new System.Drawing.Size(118, 115);
            this.labelOvulation.TabIndex = 1;
            this.labelOvulation.Text = " Ovulation   Phase";
            this.labelOvulation.UseTransparentBackground = true;
            // 
            // labelLuteal
            // 
            this.labelLuteal.BackColor = System.Drawing.Color.Transparent;
            this.labelLuteal.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.labelLuteal.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.labelLuteal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.labelLuteal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.labelLuteal.FillColor = System.Drawing.Color.Bisque;
            this.labelLuteal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelLuteal.ForeColor = System.Drawing.Color.Black;
            this.labelLuteal.Location = new System.Drawing.Point(3, 39);
            this.labelLuteal.Name = "labelLuteal";
            this.labelLuteal.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.labelLuteal.Size = new System.Drawing.Size(111, 111);
            this.labelLuteal.TabIndex = 0;
            this.labelLuteal.Text = "Luteal Phase";
            this.labelLuteal.UseTransparentBackground = true;
            // 
            // labelFollicular
            // 
            this.labelFollicular.BackColor = System.Drawing.Color.Transparent;
            this.labelFollicular.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.labelFollicular.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.labelFollicular.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.labelFollicular.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.labelFollicular.FillColor = System.Drawing.Color.Bisque;
            this.labelFollicular.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelFollicular.ForeColor = System.Drawing.Color.Black;
            this.labelFollicular.Location = new System.Drawing.Point(240, 216);
            this.labelFollicular.Name = "labelFollicular";
            this.labelFollicular.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.labelFollicular.Size = new System.Drawing.Size(117, 116);
            this.labelFollicular.TabIndex = 3;
            this.labelFollicular.Text = "Follicular  Phase";
            this.labelFollicular.UseTransparentBackground = true;
            // 
            // HormonalCycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "HormonalCycle";
            this.Text = "HormonalCycle";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2CircleProgressBar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private Guna.UI2.WinForms.Guna2CircleButton labelMenstruation;
        private Guna.UI2.WinForms.Guna2CircleButton labelOvulation;
        private Guna.UI2.WinForms.Guna2CircleButton labelLuteal;
        private Guna.UI2.WinForms.Guna2CircleButton labelFollicular;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
    }
}