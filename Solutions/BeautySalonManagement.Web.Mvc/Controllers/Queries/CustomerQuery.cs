using System.Collections.Generic;
using BeautySalonManagement.Domain.Peoples;
using CommonLib.QueryOver;
using MvcContrib.UI.Grid;
using NHibernate;
using SharpArch.NHibernate;

namespace BeautySalonManagement.Web.Mvc.Controllers.Queries
{
	public class CustomerQuery : NHibernateQuery, ICustomerQuery
	{
		public IEnumerable<Customer> FindAll(int startRow, int pageSize, GridSortOptions sort)
		{
			return Session.QueryOver<Customer>().OrderBy(sort).Skip(startRow).Take(pageSize).Future<Customer>();
		}

		public IFutureValue<int> CountAll()
		{
			return Session.QueryOver<Customer>().Count().FutureValue<int>();
		}
	}
}