using DataAccessLayer.Repository;
using System;
using System.Windows.Forms;
using WindowsFormsProject.Forms;

namespace WindowsFormsProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var repository = RepositoryFactory.GetRepository();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(repository.SettingsExists() ? new WorldCup() : new Settings() as Form);
        }
    }
}
