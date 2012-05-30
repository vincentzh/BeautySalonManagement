using BeautySalonManagement.Domain.Peoples;
using CommonLib.Tasks;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IEmployeeTasks : IPersonTasks<Employee>, IPaggingTask<Employee>
	{}
}