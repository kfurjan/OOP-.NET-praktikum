using DataAccessLayer.Api;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Matches;
using DataAccessLayer.Repository;
using DataAccessLayer.Utils;
using Newtonsoft.Json;
using Syncfusion.WinForms.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsProject.UserControls;

namespace WindowsFormsProject.Forms
{
    public partial class WorldCup : Form
    {
        private readonly IApi _api = ApiFactory.GetApi();
        private readonly IRepository _repository = RepositoryFactory.GetRepository();

        public WorldCup()
        {
            InitializeComponent();
        }

        private void WorldCup_Activated(object sender, EventArgs e)
        {
            LoadComboBoxWithTeamsAsync();
            SetCulture();
        }

        private async void LoadComboBoxWithTeamsAsync()
        {
            cbTeams.Items.Clear();
            try
            {
                cbTeams.Text = Resources.Resources.cbTeamsLoading;

                var teamGender = _repository.LoadSettings().Split('|')[0];
                var endpoint = EndpointBuilder.GetTeamsEndpoint(teamGender);

                var teams = await _api.GetDataAsync<IList<Team>>(endpoint);
                teams.ToList().ForEach(t => cbTeams.Items.Add(t));

                cbTeams.Text = string.Empty;
            }
            catch (Exception ex) when (ex is IOException || ex is JsonSerializationException || ex is JsonReaderException)
            {
                MessageBox.Show(Resources.Resources.couldNotRetrieveData);
            }
        }

        private async void LoadPanelWithPlayersAsync(Team team)
        {
            try
            {
                var busyIndicator = new BusyIndicator();
                busyIndicator.Show(flpAllPlayers);

                var teamGender = _repository.LoadSettings().Split('|')[0];
                var endpoint = EndpointBuilder.GetMatchesEndpoint(teamGender);

                var matches = await _api.GetDataAsync<IList<Match>>(endpoint);
                var match = matches?.FirstOrDefault(m => m.HomeTeamCountry == team?.Country);

                var players = match?.HomeTeamStatistics.StartingEleven.Union(match.HomeTeamStatistics.Substitutes).ToList();

                players?.ForEach(p =>
                {
                    flpAllPlayers.Controls.Add(new PlayerUserControl
                    {
                        PlayerName = p.Name,
                        PlayerNumber = p.ShirtNumber.ToString(),
                        PlayerPosition = p.Position.ToString(),
                        Captain = p.Captain ? Resources.Resources.yes : Resources.Resources.no
                    });
                });

                busyIndicator.Hide();
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentException || ex is JsonReaderException)
            {
                MessageBox.Show(Resources.Resources.dataNotLoaded);
            }
        }

        private void SetCulture()
        {
            var language = _repository.LoadSettings().Split('|')[1];
            CultureSetter.SetFormCulture(language, GetType(), Controls);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void cbTeams_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flpAllPlayers.Controls.Clear();
            LoadPanelWithPlayersAsync((sender as ComboBox)?.SelectedItem as Team);
        }

        private void WorldCup_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                Resources.Resources.formClosingBody,
                Resources.Resources.formColsingTitle,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            e.Cancel = result == DialogResult.Cancel;
        }
    }
}
