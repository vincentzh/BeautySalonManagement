using BeautySalonManagement.Domain.Peoples;
using CommonLib.Tasks;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IPersonTasks<T> : ITask<T> where T : People
	{
		T FindByWithLoginInfo(string specificNo, string password);
	}
}