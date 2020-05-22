using DataAccessLayer.Repository;
using System;
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
            var tournamentType = gbTournamentType.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

            var language = gbLanguage.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

            try
            {
                _repository.SaveSettings(tournamentType, language);
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }

            this.Hide();
            new WorldCup().ShowDialog();
            this.Close();
        }
    }
}
