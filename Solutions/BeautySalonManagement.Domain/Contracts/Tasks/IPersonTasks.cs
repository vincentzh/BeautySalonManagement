using BeautySalonManagement.Domain.Peoples;
using NHibernate;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IPersonTasks<T> where T : People
	{
		IFutureValue<T> FindByWithLoginInfo(string specificNo, string password);
		T Get(int id);
	}
}