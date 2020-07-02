using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsProject.UserControls
{
    public partial class MatchUserControl : UserControl
    {
        #region Properties
        private readonly string _location;
        [Category("MatchUserControl")]
        public string Location
        {
            get => _location;
            set => lblLocation.Text = value;
        }

        private readonly string _attendances;
        [Category("MatchUserControl")]
        public string Attendances
        {
            get => _attendances;
            set => lblAttendances.Text = value;
        }

        private readonly string _homeTeam;
        [Category("MatchUserControl")]
        public string HomeTeam
        {
            get => _homeTeam;
            set => lblHomeTeam.Text = value;
        }

        private readonly string _awayTeam;
        [Category("MatchUserControl")]
        public string AwayTeam
        {
            get => _awayTeam;
            set => lblAwayTeam.Text = value;
        }
        #endregion

        public MatchUserControl()
        {
            InitializeComponent();
        }
    }
}
