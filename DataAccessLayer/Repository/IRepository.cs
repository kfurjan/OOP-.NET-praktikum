namespace DataAccessLayer.Repository
{
    public interface IRepository
    {
        void SaveSettings(string tournamentType, string language);
        string LoadSettings();
        bool SettingsExists();
    }
}
