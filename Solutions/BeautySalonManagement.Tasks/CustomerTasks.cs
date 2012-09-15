using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using CommonLib.Tasks;

namespace BeautySalonManagement.Tasks
{
	public class CustomerTasks : NHibernateQueryTaskBase<Customer>, ICustomerTasks
	{
		#region ICustomerTasks Members

		public Customer FindByWithLoginInfo(string specificNo, string password)
		{
			return
					Session.QueryOver<Customer>().Where(
							customer => customer.CustomerCardNo == specificNo && customer.Password == password).SingleOrDefault<Customer>();
		}

		#endregion
	}
}