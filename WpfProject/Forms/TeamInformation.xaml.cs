using System.Windows;

namespace WpfProject.Forms
{
    /// <summary>
    /// Interaction logic for TeamInformation.xaml
    /// </summary>
    public partial class TeamInformation : Window
    {
        public string TeamName { get; set; }
        public string FifaCode { get; set; }
        public string MatchesPlayed { get; set; }
        public string MatchesWon { get; set; }
        public string MatchesLost { get; set; }
        public string MatchesDraw { get; set; }
        public string GoalsScored { get; set; }
        public string GoalsReceived { get; set; }

        public TeamInformation()
        {
            InitializeComponent();
        }
    }
}
