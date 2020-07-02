namespace WindowsFormsProject.UserControls
{
    partial class MatchUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchUserControl));
            this.lblLocationText = new System.Windows.Forms.Label();
            this.lblAttendancesText = new System.Windows.Forms.Label();
            this.lblHomeTeamText = new System.Windows.Forms.Label();
            this.lblAwayTeamText = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblAttendances = new System.Windows.Forms.Label();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLocationText
            // 
            resources.ApplyResources(this.lblLocationText, "lblLocationText");
            this.lblLocationText.Name = "lblLocationText";
            // 
            // lblAttendancesText
            // 
            resources.ApplyResources(this.lblAttendancesText, "lblAttendancesText");
            this.lblAttendancesText.Name = "lblAttendancesText";
            // 
            // lblHomeTeamText
            // 
            resources.ApplyResources(this.lblHomeTeamText, "lblHomeTeamText");
            this.lblHomeTeamText.Name = "lblHomeTeamText";
            // 
            // lblAwayTeamText
            // 
            resources.ApplyResources(this.lblAwayTeamText, "lblAwayTeamText");
            this.lblAwayTeamText.Name = "lblAwayTeamText";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // lblAttendances
            // 
            resources.ApplyResources(this.lblAttendances, "lblAttendances");
            this.lblAttendances.Name = "lblAttendances";
            // 
            // lblHomeTeam
            // 
            resources.ApplyResources(this.lblHomeTeam, "lblHomeTeam");
            this.lblHomeTeam.Name = "lblHomeTeam";
            // 
            // lblAwayTeam
            // 
            resources.ApplyResources(this.lblAwayTeam, "lblAwayTeam");
            this.lblAwayTeam.Name = "lblAwayTeam";
            // 
            // MatchUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lblAwayTeam);
            this.Controls.Add(this.lblHomeTeam);
            this.Controls.Add(this.lblAttendances);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblAwayTeamText);
            this.Controls.Add(this.lblHomeTeamText);
            this.Controls.Add(this.lblAttendancesText);
            this.Controls.Add(this.lblLocationText);
            this.Name = "MatchUserControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocationText;
        private System.Windows.Forms.Label lblAttendancesText;
        private System.Windows.Forms.Label lblHomeTeamText;
        private System.Windows.Forms.Label lblAwayTeamText;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblAttendances;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Label lblAwayTeam;
    }
}
