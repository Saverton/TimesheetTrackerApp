using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimesheetTrackerLibrary.DataAccess;
using TimesheetTrackerLibrary.DataAccess.Dapper;

namespace TimesheetTracker
{
	internal static class Program
	{
        // Don't use before host is created.
        public static IServiceProvider ServiceProvider { get; private set; } = null!; 

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

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<DashboardForm>());
		}

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // add services
            services.AddSingleton<IDataAccess, SQLiteDataAccess>();
            services.AddSingleton<ITimesheetDataAccess, DapperTimesheetDataAccess>();

            // add forms
            services.AddSingleton<DashboardForm>();
            services.AddTransient<SettingsForm>();
            services.AddTransient<TimesheetViewerForm>();
            services.AddTransient<ProjectViewerForm>();
            services.AddTransient<ProjectManagerForm>();
            services.AddTransient<ProjectForm>(); // To be replaced by ProjectManagerForm
            services.AddTransient<WorkLogViewerForm>();
            services.AddTransient<EditWorkLogForm>();
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