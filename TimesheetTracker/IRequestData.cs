using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetTracker
{
	public interface IRequestData<T>
	{
		public void ReceiveData(T data);
	}
}
