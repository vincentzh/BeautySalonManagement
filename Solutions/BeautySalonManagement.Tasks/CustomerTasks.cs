using System.Collections.Generic;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using CommonLib.ControlsExtension;
using CommonLib.QueryOver;
using CommonLib.Tasks;
using NHibernate;
using SharpArch.NHibernate;

namespace BeautySalonManagement.Tasks
{
	public class CustomerTasks : NHibernateQueryTaskBase<Customer>, ICustomerTasks
	{


		public Customer FindByWithLoginInfo(string specificNo, string password)
		{
			return
					Session.QueryOver<Customer>().Where(
							customer => customer.CustomerCardNo == specificNo && customer.Password == password).SingleOrDefault<Customer>();
		}

	}
}