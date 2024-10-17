using JomaVoting;

namespace JomaVoting
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AdminHomari formari = new AdminHomari();
            VoterHomari vormari = new VoterHomari();

            Application.Run(vormari);
            Application.Run(formari);
        }
    }
}