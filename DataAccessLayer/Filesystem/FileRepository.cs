using DataAccessLayer.Repository;
using System;
using System.IO;
using System.Linq;

namespace DataAccessLayer.Filesystem
{
    internal class FileRepository : IRepository

    {
        private const string Folder = @"../../../assets";
        private const string Settings = @"settings.txt";
        private const string Pictures = @"pictures.txt";

        private static readonly string SettingsPath = $@"{Folder}/{Settings}";
        private static readonly string PicturesPath = $@"{Folder}/{Pictures}";

        public void SaveSettings(string tournamentType, string language)
        {
            if (!Directory.Exists(Folder)) { Directory.CreateDirectory(Folder); }

            File.WriteAllText(SettingsPath, $"{tournamentType}|{language}");
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

        public bool PictureExists(string controlName)
        {
            if (!File.Exists(PicturesPath)) { File.Create(PicturesPath); }

            return File.ReadAllLines(PicturesPath)
                .Any(line => line.Split('|')[0].ToString() == controlName);
        }

        public string GetPictureLocation(string controlName)
        {
            foreach (var line in File.ReadAllLines(PicturesPath))
            {
                if (line.Split('|')[0] == controlName) { return line.Split('|')[1]; }
            }

            return string.Empty;
        }

        public string GetTeamGender() => LoadAllSettings().Split('|')[0].Trim();
        public string GetSelectedLanguage() => LoadAllSettings().Split('|')[1].Trim();
        public string GetSelectedTeam() => LoadAllSettings().Split('|')[2].Trim();
        public bool SettingsExists() => File.Exists(SettingsPath);
    }
}
