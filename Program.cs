namespace W2_Terrain_Loader
{
    internal static class Program
    {
        private static Mutex mutex = null;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "CTerrain";
            bool createdNew;
            mutex = new Mutex(true, appName, out createdNew);
            if (!createdNew) {
                return;
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}