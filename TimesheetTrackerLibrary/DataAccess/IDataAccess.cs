using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary.DataAccess
{
	public interface IDataAccess
	{
		public List<T> LoadData<T, U>(string sql, U parameters);

		public void SaveData<T>(string sql, T parameters);
	}
}
