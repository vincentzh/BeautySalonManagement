using System.Collections.Generic;
using CommonLib.ControlsExtension;
using NHibernate;

namespace CommonLib.Tasks
{
	public interface IPaggingTask<out T> where T : class
	{
		IEnumerable<T> FindAll(int startRow, int pageSize, MvcContributeGridSort sort);
		IFutureValue<int> CountAll();
	}
}