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
        private bool _formFirstTimeShown = true;

        private readonly IApi _api = ApiFactory.GetApi();
        private readonly IRepository _repository = RepositoryFactory.GetRepository();

        public WorldCup()
        {
            SetCulture();
            InitializeComponent();
            InitializeDragAndDrop();
        }

        private void InitializeDragAndDrop()
        {
            flpAllPlayers.AllowDrop = true;
            flpFavoritePlayers.AllowDrop = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void WorldCup_Activated(object sender, EventArgs e)
        {
            // try loading last selected team saved in settings
            try
            {
                if (_formFirstTimeShown)
                {
                    LoadPanelWithPlayersAsync(_repository.GetSelectedTeam());
                    _formFirstTimeShown = false;
                }
            }
            catch { /* pass */ }

            LoadComboBoxWithTeamsAsync();
            SetCulture();
        }

        private void cbTeams_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var selectedTeam = (sender as ComboBox)?.SelectedItem as Team;
                flpAllPlayers.Controls.Clear();

                LoadPanelWithPlayersAsync(selectedTeam);
                _repository.AddSelectedTeamToSettings(selectedTeam?.Country);
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentNullException)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WorldCup_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                Resources.Resources.formClosingBody,
                Resources.Resources.formColsingTitle,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            e.Cancel = result == DialogResult.Cancel;
        }

        private void SetCulture()
        {
            var language = _repository.GetSelectedLanguage();
            CultureSetter.SetFormCulture(language, GetType(), Controls);
        }

        private async void LoadComboBoxWithTeamsAsync()
        {
            cbTeams.Items.Clear();
            try
            {
                cbTeams.Text = Resources.Resources.cbTeamsLoading;

                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetTeamsEndpoint(teamGender);

                var teams = await _api.GetDataAsync<IList<Team>>(endpoint);
                teams.ToList().ForEach(t => cbTeams.Items.Add(t));

                cbTeams.Text = string.Empty;
            }
            catch (Exception ex) when (ex is IOException
                                       || ex is JsonReaderException
                                       || ex is ArgumentNullException)
            {
                MessageBox.Show(Resources.Resources.couldNotRetrieveData, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadPanelWithPlayersAsync(dynamic team)
        {
            try
            {
                var country = team is Team t ? t.Country : team as string;

                // loading animations
                var busyIndicator = new BusyIndicator();
                busyIndicator.Show(flpAllPlayers);

                // get API data
                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetMatchesEndpoint(teamGender);
                var matches = await _api.GetDataAsync<IList<Match>>(endpoint);

                // find all players for selected team
                var match = matches?.FirstOrDefault(m => m.HomeTeamCountry == country);
                var players = match?.HomeTeamStatistics.StartingEleven.Union(match.HomeTeamStatistics.Substitutes).ToList();

                // load all players to Flow Layout Panel
                players?.ForEach(p =>
                {
                    flpAllPlayers.Controls.Add(new PlayerUserControl
                    {
                        PlayerName = p.Name,
                        PlayerNumber = p.ShirtNumber.ToString(),
                        PlayerPosition = p.Position.ToString(),
                        Captain = p.Captain ? Resources.Resources.yes : Resources.Resources.no,
                        Name = $"{p.Name} {p.ShirtNumber.ToString()}"
                    });
                });

                busyIndicator.Hide();
            }
            catch (Exception ex) when (ex is IOException
                                       || ex is ArgumentNullException
                                       || ex is JsonReaderException)
            {
                MessageBox.Show(Resources.Resources.dataNotLoaded, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            var controlName = e.Data.GetData(typeof(string)) as string;
            var userControl = Controls.Find(controlName, true).FirstOrDefault();
            if (userControl != null && ((PlayerUserControl)userControl).IsSelected)
            {
                userControl.Parent.Controls.Remove(userControl);
                ((FlowLayoutPanel)sender).Controls.Add(userControl);
                ((PlayerUserControl)userControl).IsSelected = false;
            }
            cbTeams.Text = flpAllPlayers.Controls.OfType<PlayerUserControl>().Count(c => c.IsSelected).ToString();
        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            var controlName = e.Data.GetData(typeof(string)) as string;
            var userControl = Controls.Find(controlName, true).FirstOrDefault();
            if (userControl != null && ((PlayerUserControl)userControl).IsSelected)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
    }
}
