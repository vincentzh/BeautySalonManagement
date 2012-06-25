using System.Collections.Generic;

namespace CommonLib.Tasks
{
	public interface ITask<T> where T : class
	{
		T Get(int id);
		IEnumerable<T> FindByAll();
		void Delete(T entity);
	}
}