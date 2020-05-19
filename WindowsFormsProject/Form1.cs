using DataAccessLayer.Api;
using DataAccessLayer.Models;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetApiDataAsync();
        }

        private async void GetApiDataAsync()
        {
            IList<Team> apiData = await api.GetData<IList<Team>>(WOMEN_TEAMS);
            apiData.ToList().ForEach(team => comboBox1.Items.Add(team.ToString()));
        }
    }
}
