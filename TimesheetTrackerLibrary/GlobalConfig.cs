using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTrackerLibrary
{
	public static class GlobalConfig
	{
		public static string GetConnectionString(string name)
		{
			return ConfigurationManager.ConnectionStrings[name].ConnectionString ?? 
				throw new Exception($"No connection string with name {name}");
		}
	}
}
