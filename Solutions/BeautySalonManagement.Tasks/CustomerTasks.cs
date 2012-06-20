using System.Collections.Generic;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using CommonLib.ControlsExtension;
using CommonLib.QueryOver;
using NHibernate;
using SharpArch.NHibernate;

namespace BeautySalonManagement.Tasks
{
	public class CustomerTasks : NHibernateQuery, ICustomerTasks
	{
		public IEnumerable<Customer> FindAll(int startRow, int pageSize, MvcContributeGridSort sort)
		{
			return Session.QueryOver<Customer>().OrderBy(sort).Skip(startRow).Take(pageSize).Future<Customer>();
		}

		public IFutureValue<int> CountAll()
		{
			return Session.QueryOver<Customer>().Count().FutureValue<int>();
		}

		public Customer FindByWithLoginInfo(string specificNo, string password)
		{
			return
					Session.QueryOver<Customer>().Where(
							customer => customer.CustomerCardNo == specificNo && customer.Password == password).SingleOrDefault<Customer>();
		}

		public Customer Get(int id)
		{
			return Session.Get<Customer>(id);
		}
	}
}