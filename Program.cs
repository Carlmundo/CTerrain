using System.Reflection;
using System.Runtime.Loader;

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

            AssemblyLoadContext.Default.Resolving += (context, assemblyName) =>
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\CTerrain", assemblyName.Name + ".dll");
                if (File.Exists(path)) {
                    return context.LoadFromAssemblyPath(path);
                }
                return null;
            };

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}