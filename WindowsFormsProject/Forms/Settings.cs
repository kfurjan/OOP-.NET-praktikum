using DataAccessLayer.Repository;
using System;
using System.Globalization;
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
                .FirstOrDefault(r => r.Checked)?.Tag.ToString();

                var language = gbLanguage.Controls.OfType<RadioButton>()
                    .FirstOrDefault(r => r.Checked)?.Tag.ToString();

                _repository.SaveSettings(tournamentType, language);

                CultureSetter.SetFormCulture(language, GetType(), Controls);
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is IOException || ex is CultureNotFoundException)
            {
                MessageBox.Show(Resources.Resources.unexpectedErrorOccured);
            }

            if (Application.OpenForms.Count > 1)
            {
                this.Close();
                return;
            }

            this.Hide();
            new WorldCup().ShowDialog();
            this.Close();
        }
    }
}
