using System;
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
            set => pbPlayer.Image = value;
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

        #endregion
        public PlayerUserControl()
        {
            InitializeComponent();
        }

        private void PlayerUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    IsSelected = true;
                    var control = sender as Control;
                    DoDragDrop(control?.Name, DragDropEffects.Move);
                    break;
                case MouseButtons.Middle:
                    IsSelected = false;
                    break;
                case MouseButtons.Right:
                    contextMenuStrip.Show(this, new Point(e.X, e.Y));
                    break;
                default:
                    break;
            }
        }
    }
}
