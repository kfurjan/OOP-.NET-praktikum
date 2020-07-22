using DataAccessLayer.Api;
using DataAccessLayer.Models;
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

namespace WpfProject.Forms
{
    public partial class WorldCup : Window
    {
        #region Variable declaration

        private readonly IApi _api = ApiFactory.GetApi();
        private readonly IRepository _repository = RepositoryFactory.GetRepository();

        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }

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
            catch { /* if exception happens for whatever reason, default language is english */ }
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
            LoadComboBoxWithTeamsAsync(CbAwayTeam);
            SetCulture();
        }

        private void CbHomeTeam_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HomeTeam = (sender as ComboBox)?.SelectedItem as Team;
        }

        private void CbAwayTeam_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AwayTeam = (sender as ComboBox)?.SelectedItem as Team;
        }

        #endregion

        #region Helper functions

        private async void LoadComboBoxWithTeamsAsync(ItemsControl comboBox)
        {
            comboBox.Items.Clear();
            try
            {
                var teamGender = _repository.GetTeamGender();
                var endpoint = EndpointBuilder.GetTeamsEndpoint(teamGender);

                var teams = await _api.GetDataAsync<IList<Team>>(endpoint);
                teams.ToList().ForEach(t => comboBox.Items.Add(t));
            }
            catch (Exception ex) when (ex is IOException || ex is JsonReaderException || ex is ArgumentNullException)
            {
                MessageBox.Show("Could not retrieve data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
