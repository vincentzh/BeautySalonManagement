using BeautySalonManagement.Domain.Articles;
using CommonLib.Tasks;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IItemTasks : IPaggingTask<Item>, ITask<Item> 
	{
		
	}
}