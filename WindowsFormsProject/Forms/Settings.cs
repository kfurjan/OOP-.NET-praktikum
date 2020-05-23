using DataAccessLayer.Repository;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsProject.Forms
{
    public partial class Settings : Form
    {
        private readonly IRepository _repository = RepositoryFactory.GetRepository();
        public Settings()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var tournamentType = gbTournamentType.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

                var language = gbLanguage.Controls.OfType<RadioButton>()
                    .FirstOrDefault(r => r.Checked)?.Text;

                _repository.SaveSettings(tournamentType, language);
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is IOException)
            {
                MessageBox.Show("Unexpected error occured");
            }

            if (Application.OpenForms.Count != 1) return;

            this.Hide();
            new WorldCup().ShowDialog();
            this.Close();
        }
    }
}
