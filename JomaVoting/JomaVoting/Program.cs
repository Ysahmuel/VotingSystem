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

           
            LoginForm loginform = new LoginForm();
            AdminHomari homari = new AdminHomari();
            Application.Run(loginform);
            Application.Run(homari);
        }
    }
}