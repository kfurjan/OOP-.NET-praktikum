using DataAccessLayer.Api;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using DataAccessLayer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

        private async void LoadAllTeamsAsync()
        {
            cbTeams.Items.Clear();
            try
            {
                var teamGender = _repository.LoadSettings().Split('|')[0];
                var endpoint = EndpointBuilder.GetTeamsEndpoint(teamGender);

                var teams = await _api.GetDataAsync<IList<Team>>(endpoint);
                teams.ToList().ForEach(t => cbTeams.Items.Add(t));
            }
            catch (Exception ex) when (ex is IOException
                                       || ex is JsonSerializationException
                                       || ex is JsonReaderException)
            {
                MessageBox.Show("Could not retrive data");
            }
        }

        private void WorldCup_Activated(object sender, EventArgs e)
        {
            LoadAllTeamsAsync();
        }
    }
}
