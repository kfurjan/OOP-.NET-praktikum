using DataAccessLayer.Api;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Matches;
using DataAccessLayer.Models.Matches.Enums;
using DataAccessLayer.Repository;
using DataAccessLayer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WpfProject.UserControls;

namespace WpfProject.Forms
{
    public partial class WorldCup : Window
    {
        #region Variable declaration

        private readonly IApi _api = ApiFactory.GetApi();
        private readonly IRepository _repository = RepositoryFactory.GetRepository();

        public Team HomeTeam { get; private set; }
        public MatchTeam AwayTeam { get; private set; }

        #endregion

        #region Form initialization

        private void SetCulture()
        {
            try
            {
                var language = _repository.GetSelectedLanguage();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            }
            catch
            {
                /* if exception happens for whatever reason, default language is english */
            }
        }

        public WorldCup()
        {
            SetCulture();
            InitializeComponent();
        }

        #endregion

        #region Event handlers

        private void WorldCup_OnActivated(object sender, EventArgs e)
        {
            LoadComboBoxWithTeamsAsync(CbHomeTeam);
            SetCulture();
        }

        private void CbHomeTeam_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HomeTeam = (sender as ComboBox)?.SelectedItem as Team;
            LoadPanelWithPlayersAsync(HomeTeam, false);
            LoadComboBoxWithOpponentsAsync(CbAwayTeam, HomeTeam);

            PnlHomeTeamGoalie.Children.Clear();
            PnlHomeTeamDefender.Children.Clear();
            PnlHomeTeamMidfield.Children.Clear();
            PnlHomeTeamForward.Children.Clear();
        }

        private void CbAwayTeam_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AwayTeam = (sender as ComboBox)?.SelectedItem as MatchTeam;
            LoadPanelWithPlayersAsync(AwayTeam, true);

            PnlAwayTeamGoalie.Children.Clear();
            PnlAwayTeamDefender.Children.Clear();
            PnlAwayTeamMidfield.Children.Clear();
            PnlAwayTeamForward.Children.Clear();
        }

        #endregion

        #region Helper functions

        private async void LoadComboBoxWithTeamsAsync(ItemsControl control)
        {
            control.Items.Clear();
            try
            {
                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetTeamsEndpoint(teamGender);

                var teams = await _api.GetDataAsync<IList<Team>>(endpoint);
                teams.ToList().ForEach(t => control.Items.Add(t));
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show("Could not retrieve data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadPanelWithPlayersAsync(dynamic team, bool awayTeam)
        {
            try
            {
                Panel panel;
                var country = awayTeam
                    ? (team as MatchTeam)?.Country
                    : team is Team t ? t.Country : team as string;

                // get API data
                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetMatchesEndpoint(teamGender);
                var matches = await _api.GetDataAsync<IList<Match>>(endpoint);

                // find all players for selected team
                var match = matches?.FirstOrDefault(m => m.HomeTeamCountry == country);
                var players = match?.HomeTeamStatistics.StartingEleven.ToList();

                // load all players to FlowLayoutPanel
                players?.ForEach(p =>
                {
                    var playerUserControl = new PlayerUserControl(p.Name, (int)p.ShirtNumber)
                    {
                        MaxHeight = 140,
                        MaxWidth = 120
                    };
                    switch (p.Position)
                    {
                        case Position.Defender:
                            panel = awayTeam ? PnlAwayTeamDefender : PnlHomeTeamDefender;
                            panel.Children.Add(playerUserControl);
                            break;
                        case Position.Forward:
                            panel = awayTeam ? PnlAwayTeamForward : PnlHomeTeamForward;
                            panel.Children.Add(playerUserControl);
                            break;
                        case Position.Goalie:
                            panel = awayTeam ? PnlAwayTeamGoalie : PnlHomeTeamGoalie;
                            panel.Children.Add(playerUserControl);
                            break;
                        case Position.Midfield:
                            panel = awayTeam ? PnlAwayTeamMidfield : PnlHomeTeamMidfield;
                            panel.Children.Add(playerUserControl);
                            break;
                        default:
                            return;
                    }
                });
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                MessageBox.Show("Could not retrieve data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadComboBoxWithOpponentsAsync(ItemsControl control, Team homeTeam)
        {
            try
            {
                control.Items.Clear();

                // get API data
                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetMatchesEndpoint(teamGender);
                var matches = await _api.GetDataAsync<IList<Match>>(endpoint);

                var matchesPlayed = matches.Where(m => m.HomeMatchTeam.Country == homeTeam.Country).ToList();
                matchesPlayed.ToList().ForEach(m => control.Items.Add(m.AwayMatchTeam));
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                MessageBox.Show("Could not retrieve data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
