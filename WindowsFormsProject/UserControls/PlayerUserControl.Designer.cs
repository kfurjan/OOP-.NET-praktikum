﻿namespace WindowsFormsProject.UserControls
{
    partial class PlayerUserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUserControl));
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.lblNameText = new System.Windows.Forms.Label();
            this.lblNumberText = new System.Windows.Forms.Label();
            this.lblPositionText = new System.Windows.Forms.Label();
            this.lblCaptainText = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritePlyaerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPlayer
            // 
            resources.ApplyResources(this.pbPlayer, "pbPlayer");
            this.pbPlayer.BackgroundImage = global::WindowsFormsProject.Properties.Resources.player_placeholder;
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.TabStop = false;
            // 
            // lblNameText
            // 
            resources.ApplyResources(this.lblNameText, "lblNameText");
            this.lblNameText.Name = "lblNameText";
            // 
            // lblNumberText
            // 
            resources.ApplyResources(this.lblNumberText, "lblNumberText");
            this.lblNumberText.Name = "lblNumberText";
            // 
            // lblPositionText
            // 
            resources.ApplyResources(this.lblPositionText, "lblPositionText");
            this.lblPositionText.Name = "lblPositionText";
            // 
            // lblCaptainText
            // 
            resources.ApplyResources(this.lblCaptainText, "lblCaptainText");
            this.lblCaptainText.Name = "lblCaptainText";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblNumber
            // 
            resources.ApplyResources(this.lblNumber, "lblNumber");
            this.lblNumber.Name = "lblNumber";
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // lblCaptain
            // 
            resources.ApplyResources(this.lblCaptain, "lblCaptain");
            this.lblCaptain.Name = "lblCaptain";
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImagesToolStripMenuItem,
            this.favoritePlyaerToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            // 
            // loadImagesToolStripMenuItem
            // 
            resources.ApplyResources(this.loadImagesToolStripMenuItem, "loadImagesToolStripMenuItem");
            this.loadImagesToolStripMenuItem.Name = "loadImagesToolStripMenuItem";
            // 
            // favoritePlyaerToolStripMenuItem
            // 
            resources.ApplyResources(this.favoritePlyaerToolStripMenuItem, "favoritePlyaerToolStripMenuItem");
            this.favoritePlyaerToolStripMenuItem.Name = "favoritePlyaerToolStripMenuItem";
            // 
            // PlayerUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCaptainText);
            this.Controls.Add(this.lblPositionText);
            this.Controls.Add(this.lblNumberText);
            this.Controls.Add(this.lblNameText);
            this.Controls.Add(this.pbPlayer);
            this.Name = "PlayerUserControl";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerUserControl_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Label lblNameText;
        private System.Windows.Forms.Label lblNumberText;
        private System.Windows.Forms.Label lblPositionText;
        private System.Windows.Forms.Label lblCaptainText;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoritePlyaerToolStripMenuItem;
    }
}
