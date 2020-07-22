using DataAccessLayer.Repository;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace WpfProject.Forms
{
    public partial class Settings : Window
    {
        #region Variable declaration

        private readonly IRepository _repository = RepositoryFactory.GetRepository();

        #endregion

        #region Form initialization

        private void SetCulture()
        {
            try
            {
                var language = _repository.GetSelectedLanguage();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            }
            catch { /* on first load there won't be any language selected and in that case default is english */ }
        }
        public Settings()
        {
            SetCulture();
            InitializeComponent();
        }

        #endregion

        #region Event handlers

        private void BtnSettingsSave_OnClick(object sender, RoutedEventArgs e)
        {
            var confirmResult = MessageBox.Show("Confirm selected language and tournament type", "Settings", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (confirmResult != MessageBoxResult.OK) return;

            try
            {
                var tournamentType = PnlTournamentType.Children.OfType<RadioButton>()
                    .FirstOrDefault(r => r.IsChecked != null && (bool)r.IsChecked)?.Tag.ToString();

                var language = PnlLanguage.Children.OfType<RadioButton>()
                    .FirstOrDefault(r => r.IsChecked != null && (bool)r.IsChecked)?.Tag.ToString();

                var appSize = PnlAppSize.Children.OfType<RadioButton>()
                    .FirstOrDefault(r => r.IsChecked != null && (bool)r.IsChecked)?.Tag.ToString();

                _repository.SaveSettings(tournamentType, language);
                _repository.SaveAppSizeSetting(appSize);
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is IOException || ex is CultureNotFoundException)
            {
                MessageBox.Show("Unexpected error occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Hide();
            new WorldCup().ShowDialog();
            Close();
        }

        #endregion
    }
}
