using DataAccessLayer.Api;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class Form1 : Form
    {
        private readonly IApi api = ApiFactory.GetApi();
        private const string WOMEN_TEAMS = @"https://worldcup.sfg.io/teams/";
        private const string MEN_TEAMS = @"https://world-cup-json-2018.herokuapp.com/teams/";

        private const string WOMEN_MATCHES = @"https://worldcup.sfg.io/matches/";
        private const string MEN_MATCHES = @"https://world-cup-json-2018.herokuapp.com/matches/";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetTeamsDataAsync();
            GetMatchesDataAsync();
        }

        private async void GetMatchesDataAsync()
        {
            IList<Match> apiData = await api.GetDataAsync<IList<Match>>(MEN_MATCHES);
            apiData.ToList().ForEach(match => cbMatches.Items.Add(match.ToString()));
        }

        private async void GetTeamsDataAsync()
        {
            IList<Team> apiData = await api.GetDataAsync<IList<Team>>(WOMEN_TEAMS);
            apiData.ToList().ForEach(team => comboBox1.Items.Add(team.ToString()));
        }
    }
}
