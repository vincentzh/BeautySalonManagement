using System;
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
	public class EmployeeTasks : NHibernateQueryTaskBase<Employee>, IEmployeeTasks
	{
		#region IEmployeeTasks Members

		public Employee FindByWithLoginInfo(string specificNo, string password)
		{
			return
					Session.QueryOver<Employee>().Where( 
							x => x.Id== Convert.ToInt32(specificNo) && x.Password == password).SingleOrDefault<Employee>();
		}

		

		#endregion
	}
}