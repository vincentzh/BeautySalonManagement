using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.Contracts.Tasks;
using CommonLib.Tasks;

namespace BeautySalonManagement.Tasks
{
	public class ServiceTasks : NHibernateQueryTaskBase<Service>, IServiceTasks
	{}
}