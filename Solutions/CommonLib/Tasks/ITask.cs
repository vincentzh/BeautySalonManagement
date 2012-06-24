using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib.Tasks
{
	public interface ITask<T> where T:class
	{
		T Get(int id);
		IEnumerable<T> FindByAll();
	}

}
