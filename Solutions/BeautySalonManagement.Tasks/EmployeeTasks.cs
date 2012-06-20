using System;
using System.Collections.Generic;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using CommonLib.ControlsExtension;
using CommonLib.QueryOver;
using NHibernate;
using SharpArch.NHibernate;

namespace BeautySalonManagement.Tasks
{
	public class EmployeeTasks : NHibernateQuery, IEmployeeTasks
	{
		#region IEmployeeTasks Members

		public Employee FindByWithLoginInfo(string specificNo, string password)
		{
			return
					Session.QueryOver<Employee>().Where( 
							x => x.Id== Convert.ToInt32(specificNo) && x.Password == password).SingleOrDefault<Employee>();
		}

		public Employee Get(int id)
		{
			return Session.Get<Employee>(id);
		}

		public IEnumerable<Employee> FindAll(int startRow, int pageSize, MvcContributeGridSort sort)
		{
			return Session.QueryOver<Employee>().OrderBy(sort).Skip(startRow).Take(pageSize).Future<Employee>();
		}

		public IFutureValue<int> CountAll()
		{
			return Session.QueryOver<Employee>().Count().FutureValue<int>();
		}

		#endregion
	}
}