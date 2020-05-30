namespace WindowsFormsProject.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.gbTournamentType = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.gbLanguage = new System.Windows.Forms.GroupBox();
            this.rbCroatian = new System.Windows.Forms.RadioButton();
            this.rbEnglish = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gbTournamentType.SuspendLayout();
            this.gbLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMale
            // 
            resources.ApplyResources(this.rbMale, "rbMale");
            this.rbMale.Checked = true;
            this.rbMale.Name = "rbMale";
            this.rbMale.TabStop = true;
            this.rbMale.Tag = "male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // gbTournamentType
            // 
            resources.ApplyResources(this.gbTournamentType, "gbTournamentType");
            this.gbTournamentType.Controls.Add(this.rbFemale);
            this.gbTournamentType.Controls.Add(this.rbMale);
            this.gbTournamentType.Name = "gbTournamentType";
            this.gbTournamentType.TabStop = false;
            // 
            // rbFemale
            // 
            resources.ApplyResources(this.rbFemale, "rbFemale");
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Tag = "female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // gbLanguage
            // 
            resources.ApplyResources(this.gbLanguage, "gbLanguage");
            this.gbLanguage.Controls.Add(this.rbCroatian);
            this.gbLanguage.Controls.Add(this.rbEnglish);
            this.gbLanguage.Name = "gbLanguage";
            this.gbLanguage.TabStop = false;
            // 
            // rbCroatian
            // 
            resources.ApplyResources(this.rbCroatian, "rbCroatian");
            this.rbCroatian.Name = "rbCroatian";
            this.rbCroatian.Tag = "HR";
            this.rbCroatian.UseVisualStyleBackColor = true;
            // 
            // rbEnglish
            // 
            resources.ApplyResources(this.rbEnglish, "rbEnglish");
            this.rbEnglish.Checked = true;
            this.rbEnglish.Name = "rbEnglish";
            this.rbEnglish.TabStop = true;
            this.rbEnglish.Tag = "EN";
            this.rbEnglish.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gbLanguage);
            this.Controls.Add(this.gbTournamentType);
            this.Name = "Settings";
            this.gbTournamentType.ResumeLayout(false);
            this.gbTournamentType.PerformLayout();
            this.gbLanguage.ResumeLayout(false);
            this.gbLanguage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.GroupBox gbTournamentType;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.GroupBox gbLanguage;
        private System.Windows.Forms.RadioButton rbCroatian;
        private System.Windows.Forms.RadioButton rbEnglish;
        private System.Windows.Forms.Button btnSubmit;
    }
}