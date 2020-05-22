using DataAccessLayer.Api;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using DataAccessLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsProject.Forms
{
    public partial class WorldCup : Form
    {
        private readonly IApi api = ApiFactory.GetApi();
        private readonly IRepository _repository = RepositoryFactory.GetRepository();
        public WorldCup()
        {
            InitializeComponent();
        }

        private void WorldCup_Load(object sender, EventArgs e)
        {
            LoadAllTeamsAsync();
        }

        private async void LoadAllTeamsAsync()
        {
            var teamGender = _repository.LoadSettings().Split('|')[0];
            var endpoint = EndpointBuilder.GetTeamsEndpoint(teamGender);

            IList<Team> teams = await api.GetDataAsync<IList<Team>>(endpoint);
            teams.ToList().ForEach(t => cbTeams.Items.Add(t));
        }
    }
}
