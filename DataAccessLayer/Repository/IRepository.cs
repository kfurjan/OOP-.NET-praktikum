namespace DataAccessLayer.Repository
{
    public interface IRepository
    {
        void SaveSettings(string tournamentType, string language);
        void SaveAppSizeSetting(string appSize);
        void SaveLoadedPicturePath(string playerName, string picturePath);

        void AddSelectedTeamToSettings(string teamName);
        bool PictureExists(string controlName);
        bool SettingsExists();
        string LoadAllSettings();

        string GetPictureLocation(string controlName);

        string GetTeamGender();
        string GetSelectedLanguage();
        string GetSelectedTeam();
        string GetAppSizeSelected();
    }
}
