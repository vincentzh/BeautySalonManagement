using System.Collections.Generic;
using BeautySalonManagement.Domain.Peoples;
using CommonLib.ControlsExtension;
using NHibernate;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IEmployeeTasks : IPersonTasks<Employee>
	{
		IEnumerable<Employee> FindAll(int startRow, int pageSize, MvcContributeGridSort sort);
		IFutureValue<int> CountAll();
	}
}