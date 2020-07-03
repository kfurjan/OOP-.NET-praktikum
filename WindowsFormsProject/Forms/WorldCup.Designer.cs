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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldCup));
            this.cbTeams = new System.Windows.Forms.ComboBox();
            this.menuStripWorldCup = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePlayers = new System.Windows.Forms.TabPage();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankGoals = new System.Windows.Forms.TabPage();
            this.btnTabGoalsPrint = new System.Windows.Forms.Button();
            this.flpRankedByGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankCards = new System.Windows.Forms.TabPage();
            this.btnTabCardPrint = new System.Windows.Forms.Button();
            this.flpRankByYellowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankAttendances = new System.Windows.Forms.TabPage();
            this.btnTabAttendancesPrint = new System.Windows.Forms.Button();
            this.flpRankByAttendances = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoritePlyaerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripWorldCup.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPagePlayers.SuspendLayout();
            this.tabPageRankGoals.SuspendLayout();
            this.tabPageRankCards.SuspendLayout();
            this.tabPageRankAttendances.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
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
            this.settingsToolStripMenuItem});
            resources.ApplyResources(this.menuStripWorldCup, "menuStripWorldCup");
            this.menuStripWorldCup.Name = "menuStripWorldCup";
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
            this.tabPageRankGoals.Controls.Add(this.btnTabGoalsPrint);
            this.tabPageRankGoals.Controls.Add(this.flpRankedByGoals);
            resources.ApplyResources(this.tabPageRankGoals, "tabPageRankGoals");
            this.tabPageRankGoals.Name = "tabPageRankGoals";
            this.tabPageRankGoals.Tag = "rankGoals";
            this.tabPageRankGoals.UseVisualStyleBackColor = true;
            // 
            // btnTabGoalsPrint
            // 
            resources.ApplyResources(this.btnTabGoalsPrint, "btnTabGoalsPrint");
            this.btnTabGoalsPrint.Name = "btnTabGoalsPrint";
            this.btnTabGoalsPrint.UseVisualStyleBackColor = true;
            // 
            // flpRankedByGoals
            // 
            resources.ApplyResources(this.flpRankedByGoals, "flpRankedByGoals");
            this.flpRankedByGoals.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpRankedByGoals.Name = "flpRankedByGoals";
            // 
            // tabPageRankCards
            // 
            this.tabPageRankCards.Controls.Add(this.btnTabCardPrint);
            this.tabPageRankCards.Controls.Add(this.flpRankByYellowCards);
            resources.ApplyResources(this.tabPageRankCards, "tabPageRankCards");
            this.tabPageRankCards.Name = "tabPageRankCards";
            this.tabPageRankCards.Tag = "rankCards";
            this.tabPageRankCards.UseVisualStyleBackColor = true;
            // 
            // btnTabCardPrint
            // 
            resources.ApplyResources(this.btnTabCardPrint, "btnTabCardPrint");
            this.btnTabCardPrint.Name = "btnTabCardPrint";
            this.btnTabCardPrint.UseVisualStyleBackColor = true;
            // 
            // flpRankByYellowCards
            // 
            resources.ApplyResources(this.flpRankByYellowCards, "flpRankByYellowCards");
            this.flpRankByYellowCards.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpRankByYellowCards.Name = "flpRankByYellowCards";
            // 
            // tabPageRankAttendances
            // 
            this.tabPageRankAttendances.Controls.Add(this.btnTabAttendancesPrint);
            this.tabPageRankAttendances.Controls.Add(this.flpRankByAttendances);
            resources.ApplyResources(this.tabPageRankAttendances, "tabPageRankAttendances");
            this.tabPageRankAttendances.Name = "tabPageRankAttendances";
            this.tabPageRankAttendances.Tag = "RankAttendances";
            this.tabPageRankAttendances.UseVisualStyleBackColor = true;
            // 
            // btnTabAttendancesPrint
            // 
            resources.ApplyResources(this.btnTabAttendancesPrint, "btnTabAttendancesPrint");
            this.btnTabAttendancesPrint.Name = "btnTabAttendancesPrint";
            this.btnTabAttendancesPrint.UseVisualStyleBackColor = true;
            // 
            // flpRankByAttendances
            // 
            resources.ApplyResources(this.flpRankByAttendances, "flpRankByAttendances");
            this.flpRankByAttendances.BackColor = System.Drawing.Color.PaleTurquoise;
            this.flpRankByAttendances.Name = "flpRankByAttendances";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImagesToolStripMenuItem,
            this.favoritePlyaerToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // loadImagesToolStripMenuItem
            // 
            this.loadImagesToolStripMenuItem.Name = "loadImagesToolStripMenuItem";
            resources.ApplyResources(this.loadImagesToolStripMenuItem, "loadImagesToolStripMenuItem");
            // 
            // favoritePlyaerToolStripMenuItem
            // 
            this.favoritePlyaerToolStripMenuItem.Name = "favoritePlyaerToolStripMenuItem";
            resources.ApplyResources(this.favoritePlyaerToolStripMenuItem, "favoritePlyaerToolStripMenuItem");
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
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTeams;
        private System.Windows.Forms.MenuStrip menuStripWorldCup;
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
        private System.Windows.Forms.Button btnTabGoalsPrint;
        private System.Windows.Forms.Button btnTabCardPrint;
        private System.Windows.Forms.Button btnTabAttendancesPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoritePlyaerToolStripMenuItem;
    }
}