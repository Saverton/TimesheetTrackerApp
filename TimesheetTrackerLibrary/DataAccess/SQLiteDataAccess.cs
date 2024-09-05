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

		public SQLiteDataAccess(string connectionString)
		{
			_connectionString = connectionString;
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
