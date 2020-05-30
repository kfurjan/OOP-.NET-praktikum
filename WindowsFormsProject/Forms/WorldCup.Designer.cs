namespace WindowsFormsProject.Forms
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
            this.rankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankByToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rankMatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStripWorldCup.SuspendLayout();
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
            this.menuStripWorldCup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rankToolStripMenuItem,
            this.printToolStripMenuItem,
            this.settingsToolStripMenuItem});
            resources.ApplyResources(this.menuStripWorldCup, "menuStripWorldCup");
            this.menuStripWorldCup.Name = "menuStripWorldCup";
            // 
            // rankToolStripMenuItem
            // 
            this.rankToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rankByToolStripMenuItem,
            this.rankByToolStripMenuItem1,
            this.rankMatchesToolStripMenuItem});
            this.rankToolStripMenuItem.Name = "rankToolStripMenuItem";
            resources.ApplyResources(this.rankToolStripMenuItem, "rankToolStripMenuItem");
            // 
            // rankByToolStripMenuItem
            // 
            this.rankByToolStripMenuItem.Name = "rankByToolStripMenuItem";
            resources.ApplyResources(this.rankByToolStripMenuItem, "rankByToolStripMenuItem");
            // 
            // rankByToolStripMenuItem1
            // 
            this.rankByToolStripMenuItem1.Name = "rankByToolStripMenuItem1";
            resources.ApplyResources(this.rankByToolStripMenuItem1, "rankByToolStripMenuItem1");
            // 
            // rankMatchesToolStripMenuItem
            // 
            this.rankMatchesToolStripMenuItem.Name = "rankMatchesToolStripMenuItem";
            resources.ApplyResources(this.rankMatchesToolStripMenuItem, "rankMatchesToolStripMenuItem");
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
            // flpAllPlayers
            // 
            resources.ApplyResources(this.flpAllPlayers, "flpAllPlayers");
            this.flpAllPlayers.Name = "flpAllPlayers";
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            // 
            // WorldCup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpFavoritePlayers);
            this.Controls.Add(this.flpAllPlayers);
            this.Controls.Add(this.cbTeams);
            this.Controls.Add(this.menuStripWorldCup);
            this.MainMenuStrip = this.menuStripWorldCup;
            this.Name = "WorldCup";
            this.Activated += new System.EventHandler(this.WorldCup_Activated);
            this.menuStripWorldCup.ResumeLayout(false);
            this.menuStripWorldCup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTeams;
        private System.Windows.Forms.MenuStrip menuStripWorldCup;
        private System.Windows.Forms.ToolStripMenuItem rankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankByToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rankMatchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
    }
}