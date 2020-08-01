using DataAccessLayer.Api;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Matches;
using DataAccessLayer.Models.Matches.Enums;
using DataAccessLayer.Repository;
using DataAccessLayer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        private void WorldCup_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadComboBoxWithTeamsAsync(CbHomeTeam);
            // SetCulture();
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

        private void BtnHomeTeamInformation_OnClick(object sender, RoutedEventArgs e) => GetTeamsResultsAsync(CbHomeTeam.SelectionBoxItem as Team);

        private void BtnAwayTeamInformation_OnClick(object sender, RoutedEventArgs e) => GetTeamsResultsAsync(CbAwayTeam.SelectionBoxItem as MatchTeam);

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
                        MaxWidth = 120,
                        BtnUserControl = { ClickMode = ClickMode.Press }
                    };
                    playerUserControl.BtnUserControl.Click += OnUserControlClick;

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

                var matchesPlayed = matches.Where(m => m.HomeMatchTeam.Country == homeTeam.Country);
                matchesPlayed.ToList().ForEach(m => control.Items.Add(m.AwayMatchTeam));
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                MessageBox.Show("Could not retrieve data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void GetTeamsResultsAsync(dynamic team)
        {
            try
            {
                if (team is null) { return; }

                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetTeamResultsEndpoint(teamGender);
                var allTeamResults = await _api.GetDataAsync<IList<TeamStats>>(endpoint);
                var teamResult = allTeamResults.FirstOrDefault(tr => tr.Country == team.Country);

                new TeamInformation(
                    teamResult?.Country,
                    teamResult?.FifaCode,
                    teamResult?.GamesPlayed.ToString(),
                    teamResult?.Wins.ToString(),
                    teamResult?.Losses.ToString(),
                    teamResult?.Draws.ToString(),
                    teamResult?.GoalsFor.ToString(),
                    teamResult?.GoalsAgainst.ToString())
                    .ShowDialog();
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                MessageBox.Show("Could not retrieve data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void OnUserControlClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(CbHomeTeam.SelectionBoxItem is Team homeTeam) ||
            !(CbAwayTeam.SelectionBoxItem is MatchTeam awayTeam)) { return; }

                // get API data
                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetMatchesEndpoint(teamGender);
                var matches = await _api.GetDataAsync<IList<Match>>(endpoint);

                // get match data with selected teams
                var selectedMatch = matches.FirstOrDefault(m =>
                    m.HomeTeamCountry == homeTeam.Country &&
                    m.AwayTeamCountry == awayTeam.Country);

                // get all data needed for selected player
                var userControlButton = sender as Button;
                var userControlPanel = userControlButton?.Content as StackPanel;
                var playerName = (userControlPanel?.Children[0] as Label)?.Content.ToString();

                var playerInformation =
                    selectedMatch?.HomeTeamStatistics.StartingEleven
                        .Union(selectedMatch.AwayTeamStatistics.StartingEleven)
                        .FirstOrDefault(p => p.Name == playerName);

                int goalsScored = 0, yellowCards = 0;
                selectedMatch?.HomeTeamEvents
                    .Union(selectedMatch?.AwayTeamEvents)
                    .Where(ev => ev.Player == playerName)
                    .ToList().ForEach(ev =>
                    {
                        switch (ev.TypeOfEvent)
                        {
                            case TypeOfEvent.Goal:
                                goalsScored++;
                                break;
                            case TypeOfEvent.GoalOwn:
                                goalsScored++;
                                break;
                            case TypeOfEvent.YellowCard:
                                yellowCards++;
                                break;
                            case TypeOfEvent.YellowCardSecond:
                                yellowCards++;
                                break;
                        }
                    });

                new PlayerInformation(
                    playerName,
                    playerInformation?.ShirtNumber.ToString(),
                    playerInformation?.Position.ToString(),
                    playerInformation?.Captain.ToString().FirstCharToUpper(),
                    goalsScored.ToString(),
                    yellowCards.ToString())
                    .ShowDialog();
            }
            catch
            {
                MessageBox.Show("Could not retrieve data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
