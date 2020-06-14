namespace DataAccessLayer.Repository
{
    public interface IRepository
    {
        void SaveSettings(string tournamentType, string language);
        void AddSelectedTeamToSettings(string teamName);

        string LoadAllSettings();
        string GetTeamGender();
        string GetSelectedLanguage();
        string GetSelectedTeam();

        bool SettingsExists();
    }
}
