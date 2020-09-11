using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccessLayer.Filesystem
{
    internal class FileRepository : IRepository
    {
        private const string DefaultGender = @"female";
        private const string DefaultLanguage = @"EN";

        private const string Folder = @"../../../assets";
        private const string Settings = @"settings.txt";
        private const string Pictures = @"pictures.txt";
        private const string WpfAppSize = @"wpf_app_size.txt";
        private const string FavoritePlayers = @"favorite_players.txt";

        private static readonly string SettingsPath = $@"{Folder}/{Settings}";
        private static readonly string PicturesPath = $@"{Folder}/{Pictures}";
        private static readonly string WpfAppSizePath = $@"{Folder}/{WpfAppSize}";
        private static readonly string FavoritePlayersPath = $@"{Folder}/{FavoritePlayers}";

        public void SaveSettings(string tournamentType, string language)
        {
            if (!Directory.Exists(Folder)) { Directory.CreateDirectory(Folder); }

            File.WriteAllText(SettingsPath, $"{tournamentType}|{language}");
        }

        public void SaveAppSizeSetting(string appSize)
        {
            if (!Directory.Exists(Folder)) { Directory.CreateDirectory(Folder); }

            File.WriteAllText(WpfAppSizePath, $"{appSize}");
        }

        public void SaveLoadedPicturePath(string playerName, string picturePath)
        {
            if (!Directory.Exists(Folder)) { Directory.CreateDirectory(Folder); }

            File.AppendAllText(PicturesPath, $@"{playerName}|{picturePath}{Environment.NewLine}");
        }

        public void AddSelectedTeamToSettings(string teamName)
        {
            if (!File.Exists(SettingsPath)) { throw new IOException($@"{Settings} file does not exist"); }

            var teamGender = GetTeamGender();
            var language = GetSelectedLanguage();

            File.WriteAllText(SettingsPath, $@"{teamGender}|{language}|{teamName}");
        }

        public string LoadAllSettings() => File.ReadAllText(SettingsPath);

        public string GetPictureLocation(string controlName)
        {
            try
            {
                foreach (var line in File.ReadAllLines(PicturesPath))
                {
                    if (line.Split('|').ElementAtOrDefault(0) == controlName) { return line.Split('|')[1]; }
                }

                return string.Empty;
            }
            catch { return string.Empty; }
        }
        public string GetTeamGender() => LoadAllSettings().Split('|').ElementAtOrDefault(0)?.Trim() ?? DefaultGender;
        public string GetSelectedLanguage() => LoadAllSettings().Split('|').ElementAtOrDefault(1)?.Trim() ?? DefaultLanguage;
        public string GetSelectedTeam() => LoadAllSettings().Split('|').ElementAtOrDefault(2)?.Trim() ?? string.Empty;

        public string GetAppSizeSelected()
        {
            try
            {
                if (!File.Exists(WpfAppSizePath)) { File.Create(WpfAppSizePath); }
                return File.ReadAllText(WpfAppSizePath);
            }
            catch { return string.Empty; }
        }
        public void SaveFavoritePlayers(IEnumerable<string> controlNames)
        {
            if (!Directory.Exists(Folder)) { Directory.CreateDirectory(Folder); }
            if (File.Exists(FavoritePlayersPath)) { File.Delete(FavoritePlayersPath); }

            File.AppendAllLines(FavoritePlayersPath, controlNames);
        }

        public IEnumerable<string> GetFavoritePlayers()
        {
            try
            {
                if (!File.Exists(FavoritePlayersPath)) { File.Create(FavoritePlayersPath); }
                return File.ReadLines(FavoritePlayersPath);
            }
            catch { return new List<string>(); }
        }

        public bool PictureExists(string controlName)
        {
            try
            {
                if (!File.Exists(PicturesPath)) { File.Create(PicturesPath); }

                return File.ReadAllLines(PicturesPath)
                    .Any(line => line.Split('|').ElementAtOrDefault(0)?.ToString() == controlName);
            }
            catch { return false; }
        }
        public bool SettingsExists() => File.Exists(SettingsPath);
    }
}
