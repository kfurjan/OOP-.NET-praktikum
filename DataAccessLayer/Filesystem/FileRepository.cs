using DataAccessLayer.Repository;
using System.IO;

namespace DataAccessLayer.Filesystem
{
    class FileRepository : IRepository

    {
        private const string PATH = @"../../../assets/";
        private const string SETTINGS = "settings.txt";

        public void SaveSettings(string tournamentType, string language)
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }

            File.WriteAllText($"{PATH}{SETTINGS}", $"{tournamentType.ToLower()}|{language.ToLower()}");
        }
        public string LoadSettings()
        {
            return File.ReadAllText($"{PATH}{SETTINGS}");
        }

        public bool SettingsExists()
        {
            return File.Exists($"{PATH}{SETTINGS}");
        }
    }
}
