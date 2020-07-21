using DataAccessLayer.Repository;
using System;
using System.Windows;

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IRepository _repository = RepositoryFactory.GetRepository();

        private const string FormsFolder = @"Forms/";
        private const string SettingsWindow = @"Settings.xaml";
        private const string WorldCupWindow = @"WorldCup.xaml";

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var uriString = _repository.SettingsExists()
                ? $"{FormsFolder}{WorldCupWindow}"
                : $"{FormsFolder}{SettingsWindow}";

            StartupUri = new Uri(uriString, UriKind.Relative);
        }
    }
}
