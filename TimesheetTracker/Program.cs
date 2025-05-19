using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimesheetTrackerLibrary.DataAccess;
using TimesheetTrackerLibrary.DataAccess.Dapper;
using TimesheetTrackerLibrary.DataAccess.EFCore;

namespace TimesheetTracker
{
    internal static class Program
    {
        const string OLD_DBNAME = "TimesheetTracker.db";
        const string NEW_DBNAME = "TimesheetTracker_EFCore.db";

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

            using (var prepScope = ServiceProvider.CreateScope())
            {
                using var ctx = prepScope.ServiceProvider.GetRequiredService<TimesheetTrackerDbContext>();
                ctx.Database.Migrate();

                string oldDbPath = SqliteLocationProvider.GetSqlitePath(OLD_DBNAME);
                if (File.Exists(oldDbPath))
                {
                    DapperToEFCoreMigrator.MigrateDapperToEFCore(prepScope.ServiceProvider);
                    File.Delete(oldDbPath);
                }
            }

            using var appScope = ServiceProvider.CreateScope();
            Application.Run(appScope.ServiceProvider.GetRequiredService<DashboardForm>());
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // add services
            var newDbPath = SqliteLocationProvider.GetSqlitePath(NEW_DBNAME);
            services.AddDbContext<TimesheetTrackerDbContext>(options =>
                options.UseSqlite($"Data Source={newDbPath}"));
            var oldDbPath = SqliteLocationProvider.GetSqlitePath(OLD_DBNAME);
            services.AddSingleton<IDataAccess, SQLiteDataAccess>(_ => new SQLiteDataAccess(oldDbPath));
            services.AddTransient<ITimesheetDataAccess, EFCoreTimesheetDataAccess>();

            // add forms
            services.AddScoped<DashboardForm>();
            services.AddTransient<SettingsForm>();
            services.AddTransient<TimesheetViewerForm>();
            services.AddTransient<ProjectManagerForm>();
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