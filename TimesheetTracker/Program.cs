using System.Text;

namespace TimesheetTracker
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new DashboardForm());
		}

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            // dump to file
            var wd = AppDomain.CurrentDomain.BaseDirectory;
            var dir = Path.Combine(wd, "Logs"); 
            var filename = $"TimesheetTracker_CrashLog_{DateTime.Now:yyyyMMdd%THHmmss}.log";

            try
            {
                Directory.CreateDirectory(dir);
                File.WriteAllText(Path.Combine(dir, filename), e.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to dump the error message... Wow; " + ex);
            }
        }
    }
}