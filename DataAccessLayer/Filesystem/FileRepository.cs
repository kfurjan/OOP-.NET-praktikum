using DataAccessLayer.Repository;
using System.IO;

namespace DataAccessLayer.Filesystem
{
    internal class FileRepository : IRepository

    {
        private const string Folder = @"../../../assets";
        private const string Settings = @"settings.txt";
        private static readonly string Path = $"{Folder}/{Settings}";

        public void SaveSettings(string tournamentType, string language)
        {
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }

            File.WriteAllText(Path, $"{tournamentType}|{language}");
        }

        public void AddSelectedTeamToSettings(string teamName)
        {
            if (!File.Exists(Path))
            {
                throw new IOException("Settings file does not exist");
            }

            var teamGender = GetTeamGender();
            var language = GetSelectedLanguage();

            File.WriteAllText(Path, $@"{teamGender}|{language}|{teamName}");
        }

        public string LoadAllSettings() => File.ReadAllText(Path);
        public string GetTeamGender() => File.ReadAllText(Path).Split('|')[0].Trim();
        public string GetSelectedLanguage() => File.ReadAllText(Path).Split('|')[1].Trim();
        public string GetSelectedTeam() => File.ReadAllText(Path).Split('|')[2].Trim();
        public bool SettingsExists() => File.Exists(Path);
    }
}
