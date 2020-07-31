using DataAccessLayer.Repository;
using System.Windows;

namespace WpfProject.Forms
{
    /// <summary>
    /// Interaction logic for PlayerInformation.xaml
    /// </summary>
    public partial class PlayerInformation : Window
    {
        private readonly IRepository _repository = RepositoryFactory.GetRepository();
        private const string DefaultImagePath = @"../../ImageSource/player_placeholder.png";

        public string PlayerImagePath => _repository.PictureExists(PlayerName)
                ? _repository.GetPictureLocation(PlayerName)
                : DefaultImagePath;

        public string PlayerName { get; set; }
        public string ShirtNumber { get; set; }
        public string Position { get; set; }
        public string Captain { get; set; }
        public string GoalsScored { get; set; }
        public string YellowCardsReceived { get; set; }

        public PlayerInformation(string playerName, string shirtNumber, string position,
                                 string captain, string goalsScored, string yellowCardsReceived)
        {
            PlayerName = playerName;
            ShirtNumber = shirtNumber;
            Position = position;
            Captain = captain;
            GoalsScored = goalsScored;
            YellowCardsReceived = yellowCardsReceived;
            InitializeComponent();
        }
    }
}
