using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
namespace SkinMetaConsole
{
    partial class productCatalog
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator5 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.CatalogPanel = new System.Windows.Forms.Panel();
            this.guna2GradientTileButton1 = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.productView = new System.Windows.Forms.Button();
            this.id25cat5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id20cat4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id15cat3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id10cat2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id5cat1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id24cat5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id19cat4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id14cat3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id9cat2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id4cat1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id23cat5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id18cat4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id13cat3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id8cat2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id3cat1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id22cat5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id17cat4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id12cat3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id7cat2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id2cat1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.id21cat5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id16cat4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id11cat3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.id6cat2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.id1cat1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.CatalogPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id25cat5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id20cat4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id15cat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id10cat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id5cat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id24cat5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id19cat4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id14cat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id9cat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id4cat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id23cat5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id18cat4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id13cat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id8cat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id3cat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id22cat5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id17cat4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id12cat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id7cat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id2cat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id21cat5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id16cat4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id11cat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id6cat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id1cat1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "SkinMeta";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(496, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Sunscreens";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(192, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Moisturizers";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(344, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Serums";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(639, 81);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Toners";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(43, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Cleansers";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Black;
            this.guna2Separator1.Location = new System.Drawing.Point(502, 101);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(100, 10);
            this.guna2Separator1.TabIndex = 10;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.Black;
            this.guna2Separator2.Location = new System.Drawing.Point(199, 101);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(100, 10);
            this.guna2Separator2.TabIndex = 11;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.Black;
            this.guna2Separator3.Location = new System.Drawing.Point(361, 101);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(82, 10);
            this.guna2Separator3.TabIndex = 12;
            // 
            // guna2Separator4
            // 
            this.guna2Separator4.FillColor = System.Drawing.Color.Black;
            this.guna2Separator4.Location = new System.Drawing.Point(660, 101);
            this.guna2Separator4.Name = "guna2Separator4";
            this.guna2Separator4.Size = new System.Drawing.Size(75, 10);
            this.guna2Separator4.TabIndex = 13;
            // 
            // guna2Separator5
            // 
            this.guna2Separator5.FillColor = System.Drawing.Color.Black;
            this.guna2Separator5.Location = new System.Drawing.Point(60, 101);
            this.guna2Separator5.Name = "guna2Separator5";
            this.guna2Separator5.Size = new System.Drawing.Size(82, 10);
            this.guna2Separator5.TabIndex = 14;
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.AutoScroll = true;
            this.guna2VScrollBar1.BackColor = System.Drawing.Color.PeachPuff;
            this.guna2VScrollBar1.FillColor = System.Drawing.Color.Linen;
            this.guna2VScrollBar1.InUpdate = false;
            this.guna2VScrollBar1.LargeChange = 10;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(791, 3);
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.ScrollbarSize = 10;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(10, 451);
            this.guna2VScrollBar1.TabIndex = 25;
            this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.LightCoral;
            // 
            // CatalogPanel
            // 
            this.CatalogPanel.AutoScroll = true;
            this.CatalogPanel.BackColor = System.Drawing.Color.MistyRose;
            this.CatalogPanel.Controls.Add(this.guna2GradientTileButton1);
            this.CatalogPanel.Controls.Add(this.productView);
            this.CatalogPanel.Controls.Add(this.id25cat5);
            this.CatalogPanel.Controls.Add(this.id20cat4);
            this.CatalogPanel.Controls.Add(this.id15cat3);
            this.CatalogPanel.Controls.Add(this.id10cat2);
            this.CatalogPanel.Controls.Add(this.id5cat1);
            this.CatalogPanel.Controls.Add(this.id24cat5);
            this.CatalogPanel.Controls.Add(this.id19cat4);
            this.CatalogPanel.Controls.Add(this.id14cat3);
            this.CatalogPanel.Controls.Add(this.id9cat2);
            this.CatalogPanel.Controls.Add(this.id4cat1);
            this.CatalogPanel.Controls.Add(this.id23cat5);
            this.CatalogPanel.Controls.Add(this.id18cat4);
            this.CatalogPanel.Controls.Add(this.id13cat3);
            this.CatalogPanel.Controls.Add(this.id8cat2);
            this.CatalogPanel.Controls.Add(this.id3cat1);
            this.CatalogPanel.Controls.Add(this.id22cat5);
            this.CatalogPanel.Controls.Add(this.id17cat4);
            this.CatalogPanel.Controls.Add(this.id12cat3);
            this.CatalogPanel.Controls.Add(this.id7cat2);
            this.CatalogPanel.Controls.Add(this.id2cat1);
            this.CatalogPanel.Controls.Add(this.guna2CircleButton1);
            this.CatalogPanel.Controls.Add(this.guna2VScrollBar1);
            this.CatalogPanel.Controls.Add(this.id21cat5);
            this.CatalogPanel.Controls.Add(this.id16cat4);
            this.CatalogPanel.Controls.Add(this.id11cat3);
            this.CatalogPanel.Controls.Add(this.id6cat2);
            this.CatalogPanel.Controls.Add(this.guna2Separator5);
            this.CatalogPanel.Controls.Add(this.guna2Separator4);
            this.CatalogPanel.Controls.Add(this.guna2Separator3);
            this.CatalogPanel.Controls.Add(this.guna2Separator2);
            this.CatalogPanel.Controls.Add(this.guna2Separator1);
            this.CatalogPanel.Controls.Add(this.button5);
            this.CatalogPanel.Controls.Add(this.button4);
            this.CatalogPanel.Controls.Add(this.button3);
            this.CatalogPanel.Controls.Add(this.button2);
            this.CatalogPanel.Controls.Add(this.button1);
            this.CatalogPanel.Controls.Add(this.guna2CirclePictureBox2);
            this.CatalogPanel.Controls.Add(this.label1);
            this.CatalogPanel.Controls.Add(this.id1cat1);
            this.CatalogPanel.Location = new System.Drawing.Point(1, 0);
            this.CatalogPanel.Name = "CatalogPanel";
            this.CatalogPanel.Size = new System.Drawing.Size(802, 451);
            this.CatalogPanel.TabIndex = 0;
            this.CatalogPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CatalogPanel_Paint);
            // 
            // guna2GradientTileButton1
            // 
            this.guna2GradientTileButton1.AutoRoundedCorners = true;
            this.guna2GradientTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientTileButton1.BorderRadius = 12;
            this.guna2GradientTileButton1.BorderThickness = 1;
            this.guna2GradientTileButton1.DefaultAutoSize = true;
            this.guna2GradientTileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientTileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientTileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientTileButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientTileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientTileButton1.FillColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2GradientTileButton1.FillColor2 = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2GradientTileButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GradientTileButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientTileButton1.Location = new System.Drawing.Point(657, 30);
            this.guna2GradientTileButton1.Name = "guna2GradientTileButton1";
            this.guna2GradientTileButton1.Size = new System.Drawing.Size(58, 27);
            this.guna2GradientTileButton1.TabIndex = 124;
            this.guna2GradientTileButton1.Text = "SAVE";
            this.guna2GradientTileButton1.UseTransparentBackground = true;
            this.guna2GradientTileButton1.Click += new System.EventHandler(this.guna2GradientTileButton1_Click);
            // 
            // productView
            // 
            this.productView.FlatAppearance.BorderSize = 0;
            this.productView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productView.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productView.ForeColor = System.Drawing.Color.IndianRed;
            this.productView.Location = new System.Drawing.Point(543, 30);
            this.productView.Name = "productView";
            this.productView.Size = new System.Drawing.Size(114, 23);
            this.productView.TabIndex = 122;
            this.productView.Text = "ViewProducts";
            this.productView.UseVisualStyleBackColor = true;
            this.productView.Click += new System.EventHandler(this.productView_Click);
            // 
            // id25cat5
            // 
            this.id25cat5.BorderRadius = 30;
            this.id25cat5.FillColor = System.Drawing.Color.LightCoral;
            this.id25cat5.ImageRotate = 0F;
            this.id25cat5.Location = new System.Drawing.Point(631, 1101);
            this.id25cat5.Name = "id25cat5";
            this.id25cat5.Size = new System.Drawing.Size(125, 172);
            this.id25cat5.TabIndex = 116;
            this.id25cat5.TabStop = false;
            // 
            // id20cat4
            // 
            this.id20cat4.BorderRadius = 30;
            this.id20cat4.FillColor = System.Drawing.Color.LightCoral;
            this.id20cat4.ImageRotate = 0F;
            this.id20cat4.Location = new System.Drawing.Point(488, 1101);
            this.id20cat4.Name = "id20cat4";
            this.id20cat4.Size = new System.Drawing.Size(125, 172);
            this.id20cat4.TabIndex = 115;
            this.id20cat4.TabStop = false;
            // 
            // id15cat3
            // 
            this.id15cat3.BorderRadius = 30;
            this.id15cat3.FillColor = System.Drawing.Color.LightCoral;
            this.id15cat3.ImageRotate = 0F;
            this.id15cat3.Location = new System.Drawing.Point(339, 1101);
            this.id15cat3.Name = "id15cat3";
            this.id15cat3.Size = new System.Drawing.Size(125, 172);
            this.id15cat3.TabIndex = 114;
            this.id15cat3.TabStop = false;
            // 
            // id10cat2
            // 
            this.id10cat2.BorderRadius = 30;
            this.id10cat2.FillColor = System.Drawing.Color.LightCoral;
            this.id10cat2.ImageRotate = 0F;
            this.id10cat2.Location = new System.Drawing.Point(186, 1101);
            this.id10cat2.Name = "id10cat2";
            this.id10cat2.Size = new System.Drawing.Size(125, 172);
            this.id10cat2.TabIndex = 113;
            this.id10cat2.TabStop = false;
            // 
            // id5cat1
            // 
            this.id5cat1.BorderRadius = 30;
            this.id5cat1.FillColor = System.Drawing.Color.LightCoral;
            this.id5cat1.ImageRotate = 0F;
            this.id5cat1.Location = new System.Drawing.Point(39, 1101);
            this.id5cat1.Name = "id5cat1";
            this.id5cat1.Size = new System.Drawing.Size(125, 172);
            this.id5cat1.TabIndex = 112;
            this.id5cat1.TabStop = false;
            // 
            // id24cat5
            // 
            this.id24cat5.BorderRadius = 30;
            this.id24cat5.FillColor = System.Drawing.Color.LightCoral;
            this.id24cat5.ImageRotate = 0F;
            this.id24cat5.Location = new System.Drawing.Point(631, 858);
            this.id24cat5.Name = "id24cat5";
            this.id24cat5.Size = new System.Drawing.Size(125, 172);
            this.id24cat5.TabIndex = 106;
            this.id24cat5.TabStop = false;
            // 
            // id19cat4
            // 
            this.id19cat4.BorderRadius = 30;
            this.id19cat4.FillColor = System.Drawing.Color.LightCoral;
            this.id19cat4.ImageRotate = 0F;
            this.id19cat4.Location = new System.Drawing.Point(488, 858);
            this.id19cat4.Name = "id19cat4";
            this.id19cat4.Size = new System.Drawing.Size(125, 172);
            this.id19cat4.TabIndex = 105;
            this.id19cat4.TabStop = false;
            // 
            // id14cat3
            // 
            this.id14cat3.BorderRadius = 30;
            this.id14cat3.FillColor = System.Drawing.Color.LightCoral;
            this.id14cat3.ImageRotate = 0F;
            this.id14cat3.Location = new System.Drawing.Point(339, 858);
            this.id14cat3.Name = "id14cat3";
            this.id14cat3.Size = new System.Drawing.Size(125, 172);
            this.id14cat3.TabIndex = 104;
            this.id14cat3.TabStop = false;
            // 
            // id9cat2
            // 
            this.id9cat2.BorderRadius = 30;
            this.id9cat2.FillColor = System.Drawing.Color.LightCoral;
            this.id9cat2.ImageRotate = 0F;
            this.id9cat2.Location = new System.Drawing.Point(186, 858);
            this.id9cat2.Name = "id9cat2";
            this.id9cat2.Size = new System.Drawing.Size(125, 172);
            this.id9cat2.TabIndex = 103;
            this.id9cat2.TabStop = false;
            // 
            // id4cat1
            // 
            this.id4cat1.BorderRadius = 30;
            this.id4cat1.FillColor = System.Drawing.Color.LightCoral;
            this.id4cat1.ImageRotate = 0F;
            this.id4cat1.Location = new System.Drawing.Point(39, 858);
            this.id4cat1.Name = "id4cat1";
            this.id4cat1.Size = new System.Drawing.Size(125, 172);
            this.id4cat1.TabIndex = 102;
            this.id4cat1.TabStop = false;
            // 
            // id23cat5
            // 
            this.id23cat5.BorderRadius = 30;
            this.id23cat5.FillColor = System.Drawing.Color.LightCoral;
            this.id23cat5.ImageRotate = 0F;
            this.id23cat5.Location = new System.Drawing.Point(631, 606);
            this.id23cat5.Name = "id23cat5";
            this.id23cat5.Size = new System.Drawing.Size(125, 172);
            this.id23cat5.TabIndex = 96;
            this.id23cat5.TabStop = false;
            // 
            // id18cat4
            // 
            this.id18cat4.BorderRadius = 30;
            this.id18cat4.FillColor = System.Drawing.Color.LightCoral;
            this.id18cat4.ImageRotate = 0F;
            this.id18cat4.Location = new System.Drawing.Point(488, 606);
            this.id18cat4.Name = "id18cat4";
            this.id18cat4.Size = new System.Drawing.Size(125, 172);
            this.id18cat4.TabIndex = 95;
            this.id18cat4.TabStop = false;
            // 
            // id13cat3
            // 
            this.id13cat3.BorderRadius = 30;
            this.id13cat3.FillColor = System.Drawing.Color.LightCoral;
            this.id13cat3.ImageRotate = 0F;
            this.id13cat3.Location = new System.Drawing.Point(339, 606);
            this.id13cat3.Name = "id13cat3";
            this.id13cat3.Size = new System.Drawing.Size(125, 172);
            this.id13cat3.TabIndex = 94;
            this.id13cat3.TabStop = false;
            // 
            // id8cat2
            // 
            this.id8cat2.BorderRadius = 30;
            this.id8cat2.FillColor = System.Drawing.Color.LightCoral;
            this.id8cat2.ImageRotate = 0F;
            this.id8cat2.Location = new System.Drawing.Point(186, 606);
            this.id8cat2.Name = "id8cat2";
            this.id8cat2.Size = new System.Drawing.Size(125, 172);
            this.id8cat2.TabIndex = 93;
            this.id8cat2.TabStop = false;
            // 
            // id3cat1
            // 
            this.id3cat1.BorderRadius = 30;
            this.id3cat1.FillColor = System.Drawing.Color.LightCoral;
            this.id3cat1.ImageRotate = 0F;
            this.id3cat1.Location = new System.Drawing.Point(39, 606);
            this.id3cat1.Name = "id3cat1";
            this.id3cat1.Size = new System.Drawing.Size(125, 172);
            this.id3cat1.TabIndex = 92;
            this.id3cat1.TabStop = false;
            // 
            // id22cat5
            // 
            this.id22cat5.BorderRadius = 30;
            this.id22cat5.FillColor = System.Drawing.Color.LightCoral;
            this.id22cat5.ImageRotate = 0F;
            this.id22cat5.Location = new System.Drawing.Point(631, 358);
            this.id22cat5.Name = "id22cat5";
            this.id22cat5.Size = new System.Drawing.Size(125, 172);
            this.id22cat5.TabIndex = 86;
            this.id22cat5.TabStop = false;
            // 
            // id17cat4
            // 
            this.id17cat4.BorderRadius = 30;
            this.id17cat4.FillColor = System.Drawing.Color.LightCoral;
            this.id17cat4.ImageRotate = 0F;
            this.id17cat4.Location = new System.Drawing.Point(488, 358);
            this.id17cat4.Name = "id17cat4";
            this.id17cat4.Size = new System.Drawing.Size(125, 172);
            this.id17cat4.TabIndex = 85;
            this.id17cat4.TabStop = false;
            // 
            // id12cat3
            // 
            this.id12cat3.BorderRadius = 30;
            this.id12cat3.FillColor = System.Drawing.Color.LightCoral;
            this.id12cat3.ImageRotate = 0F;
            this.id12cat3.Location = new System.Drawing.Point(339, 358);
            this.id12cat3.Name = "id12cat3";
            this.id12cat3.Size = new System.Drawing.Size(125, 172);
            this.id12cat3.TabIndex = 84;
            this.id12cat3.TabStop = false;
            // 
            // id7cat2
            // 
            this.id7cat2.BorderRadius = 30;
            this.id7cat2.FillColor = System.Drawing.Color.LightCoral;
            this.id7cat2.ImageRotate = 0F;
            this.id7cat2.Location = new System.Drawing.Point(186, 358);
            this.id7cat2.Name = "id7cat2";
            this.id7cat2.Size = new System.Drawing.Size(125, 172);
            this.id7cat2.TabIndex = 83;
            this.id7cat2.TabStop = false;
            // 
            // id2cat1
            // 
            this.id2cat1.BorderRadius = 30;
            this.id2cat1.FillColor = System.Drawing.Color.LightCoral;
            this.id2cat1.ImageRotate = 0F;
            this.id2cat1.Location = new System.Drawing.Point(39, 358);
            this.id2cat1.Name = "id2cat1";
            this.id2cat1.Size = new System.Drawing.Size(125, 172);
            this.id2cat1.TabIndex = 82;
            this.id2cat1.TabStop = false;
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
            this.guna2CircleButton1.Location = new System.Drawing.Point(726, 28);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(30, 29);
            this.guna2CircleButton1.TabIndex = 47;
            this.guna2CircleButton1.UseTransparentBackground = true;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // id21cat5
            // 
            this.id21cat5.BorderRadius = 30;
            this.id21cat5.FillColor = System.Drawing.Color.LightCoral;
            this.id21cat5.ImageRotate = 0F;
            this.id21cat5.Location = new System.Drawing.Point(631, 121);
            this.id21cat5.Name = "id21cat5";
            this.id21cat5.Size = new System.Drawing.Size(125, 172);
            this.id21cat5.TabIndex = 18;
            this.id21cat5.TabStop = false;
            // 
            // id16cat4
            // 
            this.id16cat4.BorderRadius = 30;
            this.id16cat4.FillColor = System.Drawing.Color.LightCoral;
            this.id16cat4.ImageRotate = 0F;
            this.id16cat4.Location = new System.Drawing.Point(488, 121);
            this.id16cat4.Name = "id16cat4";
            this.id16cat4.Size = new System.Drawing.Size(125, 172);
            this.id16cat4.TabIndex = 17;
            this.id16cat4.TabStop = false;
            // 
            // id11cat3
            // 
            this.id11cat3.BorderRadius = 30;
            this.id11cat3.FillColor = System.Drawing.Color.LightCoral;
            this.id11cat3.ImageRotate = 0F;
            this.id11cat3.Location = new System.Drawing.Point(339, 121);
            this.id11cat3.Name = "id11cat3";
            this.id11cat3.Size = new System.Drawing.Size(125, 172);
            this.id11cat3.TabIndex = 16;
            this.id11cat3.TabStop = false;
            // 
            // id6cat2
            // 
            this.id6cat2.BorderRadius = 30;
            this.id6cat2.FillColor = System.Drawing.Color.LightCoral;
            this.id6cat2.ImageRotate = 0F;
            this.id6cat2.Location = new System.Drawing.Point(186, 121);
            this.id6cat2.Name = "id6cat2";
            this.id6cat2.Size = new System.Drawing.Size(125, 172);
            this.id6cat2.TabIndex = 15;
            this.id6cat2.TabStop = false;
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.Image = global::SkinMetaConsole.Properties.Resources.SKIN_META_LOGO_png;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(16, 3);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(75, 68);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox2.TabIndex = 3;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // id1cat1
            // 
            this.id1cat1.BorderRadius = 30;
            this.id1cat1.FillColor = System.Drawing.Color.LightCoral;
            this.id1cat1.ImageRotate = 0F;
            this.id1cat1.Location = new System.Drawing.Point(39, 121);
            this.id1cat1.Name = "id1cat1";
            this.id1cat1.Size = new System.Drawing.Size(125, 172);
            this.id1cat1.TabIndex = 4;
            this.id1cat1.TabStop = false;
            // 
            // productCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CatalogPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "productCatalog";
            this.Text = "productCatalog";
            this.CatalogPanel.ResumeLayout(false);
            this.CatalogPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id25cat5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id20cat4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id15cat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id10cat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id5cat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id24cat5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id19cat4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id14cat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id9cat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id4cat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id23cat5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id18cat4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id13cat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id8cat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id3cat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id22cat5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id17cat4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id12cat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id7cat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id2cat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id21cat5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id16cat4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id11cat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id6cat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id1cat1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox id1cat1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator4;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator5;
        private Guna.UI2.WinForms.Guna2PictureBox id6cat2;
        private Guna.UI2.WinForms.Guna2PictureBox id11cat3;
        private Guna.UI2.WinForms.Guna2PictureBox id16cat4;
        private Guna.UI2.WinForms.Guna2PictureBox id21cat5;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private System.Windows.Forms.Panel CatalogPanel;
        private Guna.UI2.WinForms.Guna2PictureBox id23cat5;
        private Guna.UI2.WinForms.Guna2PictureBox id18cat4;
        private Guna.UI2.WinForms.Guna2PictureBox id13cat3;
        private Guna.UI2.WinForms.Guna2PictureBox id8cat2;
        private Guna.UI2.WinForms.Guna2PictureBox id3cat1;
        private Guna.UI2.WinForms.Guna2PictureBox id22cat5;
        private Guna.UI2.WinForms.Guna2PictureBox id17cat4;
        private Guna.UI2.WinForms.Guna2PictureBox id12cat3;
        private Guna.UI2.WinForms.Guna2PictureBox id7cat2;
        private Guna.UI2.WinForms.Guna2PictureBox id2cat1;
        private Guna.UI2.WinForms.Guna2PictureBox id25cat5;
        private Guna.UI2.WinForms.Guna2PictureBox id20cat4;
        private Guna.UI2.WinForms.Guna2PictureBox id15cat3;
        private Guna.UI2.WinForms.Guna2PictureBox id10cat2;
        private Guna.UI2.WinForms.Guna2PictureBox id5cat1;
        private Guna.UI2.WinForms.Guna2PictureBox id24cat5;
        private Guna.UI2.WinForms.Guna2PictureBox id19cat4;
        private Guna.UI2.WinForms.Guna2PictureBox id14cat3;
        private Guna.UI2.WinForms.Guna2PictureBox id9cat2;
        private Guna.UI2.WinForms.Guna2PictureBox id4cat1;
        private System.Windows.Forms.Button productView;
        private Guna.UI2.WinForms.Guna2GradientTileButton guna2GradientTileButton1;
    }
}