﻿namespace Union
{
    partial class Message
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Message));
            this.Content = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.Timestamp = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Font = new System.Drawing.Font("Verdana", 9F);
            this.Content.ForeColor = System.Drawing.Color.White;
            this.Content.Location = new System.Drawing.Point(0, 25);
            this.Content.Name = "Content";
            this.Content.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Content.Size = new System.Drawing.Size(315, 68);
            this.Content.TabIndex = 0;
            this.Content.Text = "Content";
            this.Content.UseCompatibleTextRendering = true;
            this.Content.UseMnemonic = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Username);
            this.panel1.Controls.Add(this.Timestamp);
            this.panel1.Controls.Add(this.DeleteBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 25);
            this.panel1.TabIndex = 2;
            // 
            // Username
            // 
            this.Username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Username.Font = new System.Drawing.Font("Open Sans", 10F);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(0, 0);
            this.Username.Name = "Username";
            this.Username.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Username.Size = new System.Drawing.Size(184, 25);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            this.Username.UseMnemonic = false;
            this.Username.Paint += new System.Windows.Forms.PaintEventHandler(this.Username_Paint);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.BackgroundImage")));
            this.DeleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DeleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(290, 0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(25, 25);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Visible = false;
            this.DeleteBtn.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Timestamp
            // 
            this.Timestamp.Dock = System.Windows.Forms.DockStyle.Right;
            this.Timestamp.Font = new System.Drawing.Font("Open Sans", 7F);
            this.Timestamp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Timestamp.Location = new System.Drawing.Point(184, 0);
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Timestamp.Size = new System.Drawing.Size(106, 25);
            this.Timestamp.TabIndex = 4;
            this.Timestamp.Text = "Today at 00:00";
            this.Timestamp.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Timestamp.UseMnemonic = false;
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.Content);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Message";
            this.Size = new System.Drawing.Size(315, 93);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Content;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label Username;
        private System.Windows.Forms.Button DeleteBtn;
        public System.Windows.Forms.Label Timestamp;
    }
}
