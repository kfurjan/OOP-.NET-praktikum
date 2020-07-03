using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsProject.UserControls
{
    public partial class PlayerUserControl : UserControl
    {
        #region Properties

        private readonly string _playerName;
        [Category("PlayerUserControl")]
        public string PlayerName
        {
            get => _playerName;
            set => lblName.Text = value;
        }

        private readonly string _playerNumber;
        [Category("PlayerUserControl")]
        public string PlayerNumber
        {
            get => _playerNumber;
            set => lblNumber.Text = value;
        }

        private readonly string _playerPosition;
        [Category("PlayerUserControl")]
        public string PlayerPosition
        {
            get => _playerPosition;
            set => lblPosition.Text = value;
        }

        private readonly string _captain;
        [Category("PlayerUserControl")]
        public string Captain
        {
            get => _captain;
            set => lblCaptain.Text = value;
        }

        private readonly Image _image;
        [Category("PlayerUserControl")]
        public Image Image
        {
            get => _image;
            set
            {
                pbPlayer.Image = value;
                pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private bool _isSelected;
        [Category("PlayerUserControl")]
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                BackColor = IsSelected ? Color.Blue : Color.Gainsboro;
            }
        }

        private bool _positionVisible;
        [Category("PlayerUserControl")]
        public bool PositionVisible
        {
            get => _positionVisible;
            set
            {
                _positionVisible = value;
                lblPositionText.Visible = PositionVisible;
            }
        }

        private bool _captainVisible;
        [Category("PlayerUserControl")]
        public bool CaptainVisible
        {
            get => _captainVisible;
            set
            {
                _captainVisible = value;
                lblCaptainText.Visible = CaptainVisible;
            }
        }

        private string _customText;
        [Category("PlayerUserControl")]
        public string CustomText
        {
            get => _customText;
            set
            {
                _customText = value;
                lblNumberText.Text = CustomText;
            }
        }

        #endregion

        public PlayerUserControl()
        {
            InitializeComponent();
        }
    }
}
