using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsProject.UserControls
{
    public partial class PlayerUserControl : UserControl
    {
        #region Properties

        private string _playerName;
        [Category("PlayerUserControl")]
        public string PlayerName
        {
            get => _playerName;
            set => lblName.Text = value;
        }

        private string _playerNumber;
        [Category("PlayerUserControl")]
        public string PlayerNumber
        {
            get => _playerNumber;
            set => lblNumber.Text = value;
        }

        private string _playerPosition;
        [Category("PlayerUserControl")]
        public string PlayerPosition
        {
            get => _playerPosition;
            set => lblPosition.Text = value;
        }

        private string _captain;
        [Category("PlayerUserControl")]
        public string Captain
        {
            get => _captain;
            set => lblCaptain.Text = value;
        }

        private Image _image;
        [Category("PlayerUserControl")]
        public Image Image
        {
            get => _image;
            set => pbPlayer.Image = value;
        }

        #endregion
        public PlayerUserControl()
        {
            InitializeComponent();
        }
    }
}
