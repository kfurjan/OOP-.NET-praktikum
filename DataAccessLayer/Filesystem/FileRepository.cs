using DataAccessLayer.Repository;
using System.IO;

namespace DataAccessLayer.Filesystem
{
    class FileRepository : IRepository

    {
        private const string Path = @"../../../assets";
        private const string Settings = @"settings.txt";

        public void SaveSettings(string tournamentType, string language)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            File.WriteAllText($"{Path}/{Settings}", $"{tournamentType.ToLower()}|{language.ToLower()}");
        }
        public string LoadSettings()
        {
            return File.ReadAllText($"{Path}/{Settings}");
        }

        public bool SettingsExists()
        {
            return File.Exists($"{Path}/{Settings}");
        }
    }
}
