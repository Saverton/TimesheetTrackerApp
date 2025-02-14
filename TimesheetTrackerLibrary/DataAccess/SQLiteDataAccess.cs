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
            string dbPath = Path.Combine(baseDir, "TimesheetTracker.db");

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
