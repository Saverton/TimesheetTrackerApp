using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary.DataAccess
{
    public static class SqliteLocationProvider
    {
        public static string GetSqlitePath(string dbFilename)
        {
            // string exeFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            // string baseDir = Path.GetDirectoryName(exeFullPath)!;
            // string dbTemplatePath = Path.Combine(baseDir, "TimesheetTracker.db");

            // TODO database location config
            string userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
#if DEBUG
            string dbDir = Path.Combine(userDir, "AppData\\Local\\TimesheetTracker\\Debug");
#else
            string dbDir = Path.Combine(userDir, "AppData\\Local\\TimesheetTracker");
#endif
            string dbPath = Path.Combine(dbDir, dbFilename);

            if (!File.Exists(dbPath))
            {
                Directory.CreateDirectory(dbDir);
                // File.Copy(dbTemplatePath, dbPath);
            }

            return dbPath;
        }
    }
}
