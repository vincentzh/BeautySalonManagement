using BeautySalonManagement.Domain.Peoples;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IPersonTasks<T> where T : People
	{
		T FindByWithLoginInfo(string specificNo, string password);
		T Get(int id);
	}
}