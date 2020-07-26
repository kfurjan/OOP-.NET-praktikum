using DataAccessLayer.Repository;
using System.Windows.Controls;

namespace WpfProject.UserControls
{
    public partial class PlayerUserControl : UserControl
    {
        private readonly IRepository _repository = RepositoryFactory.GetRepository();
        private const string DefaultImagePath = @"../../ImageSource/player_placeholder.png";

        public string PlayerName { get; set; }
        public int ShirtNumber { get; set; }

        public string PlayerImagePath =>
                _repository.PictureExists(PlayerName)
                ? _repository.GetPictureLocation(PlayerName)
                : DefaultImagePath;

        public PlayerUserControl(string playerName, int shirtNumber)
        {
            PlayerName = playerName;
            ShirtNumber = shirtNumber;
            InitializeComponent();
        }
    }
}
