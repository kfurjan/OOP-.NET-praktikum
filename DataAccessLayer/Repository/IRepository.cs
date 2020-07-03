namespace DataAccessLayer.Repository
{
    public interface IRepository
    {
        void SaveSettings(string tournamentType, string language);
        void SaveLoadedPicturePath(string playerName, string picturePath);
        void AddSelectedTeamToSettings(string teamName);
        bool SettingsExists();
        string LoadAllSettings();

        bool PictureExists(string controlName);
        string GetPictureLocation(string controlName);

        string GetTeamGender();
        string GetSelectedLanguage();
        string GetSelectedTeam();
    }
}
