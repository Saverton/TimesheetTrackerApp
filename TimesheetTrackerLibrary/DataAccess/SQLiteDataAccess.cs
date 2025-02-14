using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TimesheetTrackerLibrary.DataAccess
{
	public class SQLiteDataAccess : IDataAccess
	{
		private readonly string _connectionString;

		public SQLiteDataAccess()
		{
            string exeFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string baseDir = Path.GetDirectoryName(exeFullPath)!;
            string dbTemplatePath = Path.Combine(baseDir, "TimesheetTracker.db");

            string userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string dbDir = Path.Combine(userDir, "AppData\\Local\\TimesheetTracker");
            string dbPath = Path.Combine(dbDir, "TimesheetTracker.db");

            if (!File.Exists(dbPath))
            {
                Directory.CreateDirectory(dbDir);
                File.Copy(dbTemplatePath, dbPath);
            }

			_connectionString = $"Data Source={dbPath};Version=3;";
		}

		public List<T> LoadData<T, U>(string sql, U parameters)
		{
			using IDbConnection connection = new SQLiteConnection(_connectionString);

			var output = connection.Query<T>(sql, parameters);
			return output.ToList();
		}

		public void SaveData<T>(string sql, T parameters)
		{
			using IDbConnection connection = new SQLiteConnection(_connectionString);

			connection.Execute(sql, parameters);
		}
	}
}
