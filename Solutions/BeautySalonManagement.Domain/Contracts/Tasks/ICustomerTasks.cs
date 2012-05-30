using BeautySalonManagement.Domain.Peoples;
using CommonLib.Tasks;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface ICustomerTasks : IPersonTasks<Customer>, IPaggingTask<Customer>
	{}
}