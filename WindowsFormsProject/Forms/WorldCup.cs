using DataAccessLayer.Api;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Matches;
using DataAccessLayer.Models.Matches.Enums;
using DataAccessLayer.Repository;
using DataAccessLayer.Utils;
using Newtonsoft.Json;
using Syncfusion.WinForms.Core.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsProject.UserControls;

namespace WindowsFormsProject.Forms
{
    public partial class WorldCup : Form
    {
        #region Variable declaration

        private bool _formFirstTimeShown = true;

        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();

        private readonly IList<Control> _draggables = new List<Control>();

        private readonly IDictionary<string, int> _goals = new Dictionary<string, int>();
        private readonly IDictionary<string, int> _yellowCards = new Dictionary<string, int>();

        private readonly IApi _api = ApiFactory.GetApi();
        private readonly IRepository _repository = RepositoryFactory.GetRepository();

        #endregion

        #region Form initialization 

        private void InitializeCulture()
        {
            var language = _repository.GetSelectedLanguage();
            CultureSetter.SetFormCulture(language, GetType(), Controls);
        }

        private void InitializeDragAndDrop()
        {
            flpAllPlayers.AllowDrop = true;
            flpFavoritePlayers.AllowDrop = true;
        }

        private void InitializeOpenFileDialog()
        {
            _openFileDialog.Filter = @"Pictures|*.jpeg;*.jpg;*.png;|All files|*.*";
            _openFileDialog.Multiselect = false;
            _openFileDialog.Title = Resources.Resources.loadPicture;
        }

        public WorldCup()
        {
            InitializeCulture();
            InitializeComponent();
            InitializeDragAndDrop();
            InitializeOpenFileDialog();
        }

        #endregion

        #region Event handlers

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) => new Settings().ShowDialog();

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
            InitializeCulture();
        }

        private void cbTeams_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var selectedTeam = (sender as ComboBox)?.SelectedItem as Team;
                flpAllPlayers.Controls.Clear();
                flpFavoritePlayers.Controls.Clear();

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

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            var controlName = e.Data.GetData(typeof(string)) as string;
            var userControl = Controls.Find(controlName, true).FirstOrDefault();
            if (userControl != null && ((PlayerUserControl)userControl).IsSelected)
            {
                userControl.Parent.Controls.Remove(userControl);
                ((FlowLayoutPanel)sender).Controls.Add(userControl);
                ((PlayerUserControl)userControl).IsSelected = false;
                ((PlayerUserControl)userControl).StarVisible = true;
            }
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

        private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            flpRankedByGoals.Controls.Clear();
            flpRankByYellowCards.Controls.Clear();
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            _goals.OrderByDescending(kvp => kvp.Value).ToList().ForEach(kvp =>
            {
                var playerUserControl = new PlayerUserControl
                {
                    PlayerName = kvp.Key,
                    PlayerNumber = kvp.Value.ToString(),
                    PositionVisible = false,
                    CaptainVisible = false,
                    CustomText = Resources.Resources.goals,
                    Name = $@"{kvp.Key}"
                };
                flpRankedByGoals.Controls.Add(playerUserControl);
                LoadPictureIfPreviouslySelected(playerUserControl);
            });

            _yellowCards.OrderByDescending(kvp => kvp.Value).ToList().ForEach(kvp =>
            {
                var playerUserControl = new PlayerUserControl
                {
                    PlayerName = kvp.Key,
                    PlayerNumber = kvp.Value.ToString(),
                    PositionVisible = false,
                    CaptainVisible = false,
                    CustomText = Resources.Resources.cards,
                    Name = $@"{kvp.Key}"
                };
                flpRankByYellowCards.Controls.Add(playerUserControl);
                LoadPictureIfPreviouslySelected(playerUserControl);
            });
        }

        #endregion

        #region Custom event handlers

        private void PlayerUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender as Control is PlayerUserControl puc)
            {
                var control = (Control)sender;

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        puc.IsSelected = true;
                        _draggables.Add(control);
                        MakeControlsDraggable(_draggables);
                        break;
                    case MouseButtons.Middle:
                        puc.IsSelected = false;
                        _draggables.Remove(control);
                        break;
                    case MouseButtons.Right:
                        if (((Control)sender).Parent.Name == "flpAllPlayers") { FlpAllPlayersContextMenu(puc); }
                        else { FlpFavoritePlayersContextMenu(puc); }
                        contextMenuStrip.Show(puc, new Point(e.X, e.Y));
                        break;
                }
            }
        }

        #endregion

        #region Helper functions

        private void FlpAllPlayersContextMenu(PlayerUserControl puc)
        {
            contextMenuStrip.Items.Clear();

            var loadImageItem = new ToolStripMenuItem { Text = Resources.Resources.loadPicture, Name = "loadImageItem" };
            loadImageItem.Click += (s, e) => LoadPicture(puc);
            contextMenuStrip.Items.Add(loadImageItem);

            var favoritePlayerItem = new ToolStripMenuItem { Text = Resources.Resources.favoritePlayerItem, Name = "favoritePlayerItem" };
            favoritePlayerItem.Click += (s, e) =>
            {
                puc.StarVisible = true;
                flpFavoritePlayers.Controls.Add(puc);
            };
            contextMenuStrip.Items.Add(favoritePlayerItem);
        }

        private void FlpFavoritePlayersContextMenu(PlayerUserControl puc)
        {
            contextMenuStrip.Items.Clear();

            var favoritePlayerItem = new ToolStripMenuItem { Text = Resources.Resources.removeFavoritePlayer, Name = "removeFavoritePlayer" };
            favoritePlayerItem.Click += (s, e) =>
            {
                puc.StarVisible = false;
                flpAllPlayers.Controls.Add(puc);
            };
            contextMenuStrip.Items.Add(favoritePlayerItem);
        }

        private void LoadPicture(PlayerUserControl playerUserControl)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = _openFileDialog.FileName;
                _repository.SaveLoadedPicturePath(playerUserControl.Name.Trim(), filePath.Trim());
                playerUserControl.Image = Image.FromFile(filePath);
            }
        }

        private void LoadPictureIfPreviouslySelected(PlayerUserControl control)
        {
            if (_repository.PictureExists(control.Name))
            {
                control.Image = Image.FromFile(_repository.GetPictureLocation(control.Name));
            }
        }

        private static void MakeControlsDraggable(IEnumerable<Control> controls)
        {
            controls.ToList().ForEach(c => c.DoDragDrop(c.Name, DragDropEffects.Move));
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
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                MessageBox.Show(Resources.Resources.couldNotRetrieveData, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadPanelWithPlayersAsync(dynamic team)
        {
            try
            {
                _goals.Clear();
                _yellowCards.Clear();
                flpRankByAttendances.Controls.Clear();

                var country = team is Team t ? t.Country : team as string;

                // show loading animation
                var busyIndicator = new BusyIndicator();
                busyIndicator.Show(flpAllPlayers);

                // get API data
                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetMatchesEndpoint(teamGender);
                var matches = await _api.GetDataAsync<IList<Match>>(endpoint);

                // find all players for selected team
                var match = matches?.FirstOrDefault(m => m.HomeTeamCountry == country);
                var players = match?.HomeTeamStatistics.StartingEleven.Union(match.HomeTeamStatistics.Substitutes).ToList();

                // load all players to FlowLayoutPanel
                players?.ForEach(p =>
                {
                    var playerUserControl = new PlayerUserControl
                    {
                        PlayerName = p.Name,
                        PlayerNumber = p.ShirtNumber.ToString(),
                        PlayerPosition = p.Position.ToString(),
                        Captain = p.Captain ? Resources.Resources.yes : Resources.Resources.no,
                        Name = $"{p.Name}"
                    };
                    LoadPictureIfPreviouslySelected(playerUserControl);

                    flpAllPlayers.Controls.Add(playerUserControl);
                    playerUserControl.MouseDown += PlayerUserControl_MouseDown;

                    _goals.Add(p.Name, 0);
                    _yellowCards.Add(p.Name, 0);
                });

                // Get goals and yellow cards per each player
                matches?
                    .Where(m => m.HomeTeamCountry == match?.HomeTeamCountry)
                    .ToList()
                    .ForEach(m =>
                    {
                        m.HomeTeamEvents.ToList().ForEach(te =>
                        {
                            switch (te.TypeOfEvent)
                            {
                                case TypeOfEvent.Goal:
                                    _goals[te.Player] += 1;
                                    break;
                                case TypeOfEvent.YellowCard:
                                    _yellowCards[te.Player] += 1;
                                    break;
                                case TypeOfEvent.YellowCardSecond:
                                    _yellowCards[te.Player] += 1;
                                    break;
                            }
                        });
                    });

                // Get all matches for selected country ordered by attendance
                matches?
                    .Where(m => m.HomeTeamCountry == match?.HomeTeamCountry || m.AwayTeamCountry == match?.HomeTeamCountry)
                    .OrderByDescending(m => m.Attendance)
                    .ToList()
                    .ForEach(m =>
                    {
                        flpRankByAttendances.Controls.Add(new MatchUserControl
                        {
                            Location = m.Location,
                            Attendances = m.Attendance.ToString(),
                            HomeTeam = m.HomeTeamCountry,
                            AwayTeam = m.AwayTeamCountry
                        });
                    });

                busyIndicator.Hide();
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentNullException || ex is JsonReaderException)
            {
                MessageBox.Show(Resources.Resources.dataNotLoaded, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
