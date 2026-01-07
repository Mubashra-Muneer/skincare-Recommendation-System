using System;
using System.Windows.Forms;
using System.Drawing;
namespace SkinMetaConsole
{
    partial class Consultation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // Declare UI components that will be referenced in Consultation.cs
        private Panel chatContainer;
        private Panel bottomPanel;
        private TextBox messageInput;
        private Button sendButton;
        private Button homeButton; // Keep homeButton declaration here only

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "SkinMeta Consultation";
            this.BackColor = System.Drawing.Color.White;

            // Create chat container panel
            chatContainer = new Panel();
            chatContainer.Dock = DockStyle.Fill;
            chatContainer.AutoScroll = true;
            chatContainer.Padding = new Padding(10);
            chatContainer.BackColor = Color.MistyRose;
            this.Controls.Add(chatContainer);

            // Create bottom panel for input controls
            bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 60;
            bottomPanel.BackColor = Color.White;
            bottomPanel.Padding = new Padding(10);
            this.Controls.Add(bottomPanel);

            // Create message input textbox
            messageInput = new TextBox();
            messageInput.Dock = DockStyle.Fill;
            messageInput.Font = new Font("Segoe UI", 10F);
            messageInput.BorderStyle = BorderStyle.FixedSingle;
            bottomPanel.Controls.Add(messageInput);

            // Create send button
            sendButton = new Button();
            sendButton.Size = new Size(40, 40);
            sendButton.Dock = DockStyle.Right;
            sendButton.Margin = new Padding(5, 0, 0, 0);
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.Text = "➤";
            sendButton.BackColor = Color.IndianRed;
            sendButton.ForeColor = Color.White;
            bottomPanel.Controls.Add(sendButton);

            // Create home button
            homeButton = new Button();
            homeButton.Text = "Home";
            homeButton.Size = new Size(80, 30);
            homeButton.Location = new Point(10, 10);
            homeButton.BackColor = Color.IndianRed;
            homeButton.ForeColor = Color.White;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.FlatAppearance.BorderSize = 1;
            homeButton.FlatAppearance.BorderColor = Color.White;
            homeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.Controls.Add(homeButton);

            // Set tab order
            this.bottomPanel.TabIndex = 0;
            this.messageInput.TabIndex = 0;
            this.sendButton.TabIndex = 1;
            this.chatContainer.TabIndex = 2;
            this.homeButton.TabIndex = 3;
        }
        #endregion
    }
}