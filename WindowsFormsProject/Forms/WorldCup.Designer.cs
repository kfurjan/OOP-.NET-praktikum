﻿namespace WindowsFormsProject.Forms
{
    partial class WorldCup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldCup));
            this.cbTeams = new System.Windows.Forms.ComboBox();
            this.menuStripWorldCup = new System.Windows.Forms.MenuStrip();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePlayers = new System.Windows.Forms.TabPage();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankGoals = new System.Windows.Forms.TabPage();
            this.flpRankedByGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankCards = new System.Windows.Forms.TabPage();
            this.flpRankByYellowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankAttendances = new System.Windows.Forms.TabPage();
            this.flpRankByAttendances = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStripWorldCup.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePlayers.SuspendLayout();
            this.tabPageRankGoals.SuspendLayout();
            this.tabPageRankCards.SuspendLayout();
            this.tabPageRankAttendances.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTeams
            // 
            this.cbTeams.FormattingEnabled = true;
            resources.ApplyResources(this.cbTeams, "cbTeams");
            this.cbTeams.Name = "cbTeams";
            this.cbTeams.SelectionChangeCommitted += new System.EventHandler(this.cbTeams_SelectionChangeCommitted);
            // 
            // menuStripWorldCup
            // 
            this.menuStripWorldCup.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripWorldCup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.settingsToolStripMenuItem});
            resources.ApplyResources(this.menuStripWorldCup, "menuStripWorldCup");
            this.menuStripWorldCup.Name = "menuStripWorldCup";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePlayers);
            this.tabControl.Controls.Add(this.tabPageRankGoals);
            this.tabControl.Controls.Add(this.tabPageRankCards);
            this.tabControl.Controls.Add(this.tabPageRankAttendances);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Tag = "rankCards";
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            this.tabControl.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Deselecting);
            // 
            // tabPagePlayers
            // 
            this.tabPagePlayers.Controls.Add(this.flpFavoritePlayers);
            this.tabPagePlayers.Controls.Add(this.flpAllPlayers);
            resources.ApplyResources(this.tabPagePlayers, "tabPagePlayers");
            this.tabPagePlayers.Name = "tabPagePlayers";
            this.tabPagePlayers.Tag = "players";
            this.tabPagePlayers.UseVisualStyleBackColor = true;
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
            this.flpFavoritePlayers.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragEnter);
            // 
            // flpAllPlayers
            // 
            resources.ApplyResources(this.flpAllPlayers, "flpAllPlayers");
            this.flpAllPlayers.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpAllPlayers.Name = "flpAllPlayers";
            // 
            // tabPageRankGoals
            // 
            this.tabPageRankGoals.Controls.Add(this.flpRankedByGoals);
            resources.ApplyResources(this.tabPageRankGoals, "tabPageRankGoals");
            this.tabPageRankGoals.Name = "tabPageRankGoals";
            this.tabPageRankGoals.Tag = "rankGoals";
            this.tabPageRankGoals.UseVisualStyleBackColor = true;
            // 
            // flpRankedByGoals
            // 
            resources.ApplyResources(this.flpRankedByGoals, "flpRankedByGoals");
            this.flpRankedByGoals.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpRankedByGoals.Name = "flpRankedByGoals";
            // 
            // tabPageRankCards
            // 
            this.tabPageRankCards.Controls.Add(this.flpRankByYellowCards);
            resources.ApplyResources(this.tabPageRankCards, "tabPageRankCards");
            this.tabPageRankCards.Name = "tabPageRankCards";
            this.tabPageRankCards.Tag = "rankCards";
            this.tabPageRankCards.UseVisualStyleBackColor = true;
            // 
            // flpRankByYellowCards
            // 
            resources.ApplyResources(this.flpRankByYellowCards, "flpRankByYellowCards");
            this.flpRankByYellowCards.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpRankByYellowCards.Name = "flpRankByYellowCards";
            // 
            // tabPageRankAttendances
            // 
            this.tabPageRankAttendances.Controls.Add(this.flpRankByAttendances);
            resources.ApplyResources(this.tabPageRankAttendances, "tabPageRankAttendances");
            this.tabPageRankAttendances.Name = "tabPageRankAttendances";
            this.tabPageRankAttendances.Tag = "RankAttendances";
            this.tabPageRankAttendances.UseVisualStyleBackColor = true;
            // 
            // flpRankByAttendances
            // 
            resources.ApplyResources(this.flpRankByAttendances, "flpRankByAttendances");
            this.flpRankByAttendances.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpRankByAttendances.Name = "flpRankByAttendances";
            // 
            // WorldCup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cbTeams);
            this.Controls.Add(this.menuStripWorldCup);
            this.MainMenuStrip = this.menuStripWorldCup;
            this.Name = "WorldCup";
            this.Activated += new System.EventHandler(this.WorldCup_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorldCup_FormClosing);
            this.menuStripWorldCup.ResumeLayout(false);
            this.menuStripWorldCup.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPagePlayers.ResumeLayout(false);
            this.tabPageRankGoals.ResumeLayout(false);
            this.tabPageRankCards.ResumeLayout(false);
            this.tabPageRankAttendances.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTeams;
        private System.Windows.Forms.MenuStrip menuStripWorldCup;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagePlayers;
        private System.Windows.Forms.FlowLayoutPanel flpAllPlayers;
        private System.Windows.Forms.TabPage tabPageRankGoals;
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
        private System.Windows.Forms.TabPage tabPageRankCards;
        private System.Windows.Forms.TabPage tabPageRankAttendances;
        private System.Windows.Forms.FlowLayoutPanel flpRankedByGoals;
        private System.Windows.Forms.FlowLayoutPanel flpRankByYellowCards;
        private System.Windows.Forms.FlowLayoutPanel flpRankByAttendances;
    }
}