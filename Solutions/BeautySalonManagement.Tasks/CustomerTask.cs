using System.Collections.Generic;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using CommonLib.QueryOver;
using MvcContrib.Pagination;
using MvcContrib.UI.Grid;
using NHibernate;
using SharpArch.NHibernate;

namespace BeautySalonManagement.Tasks
{
	public class CustomerTask : NHibernateQuery,ICustomerTask
	{
		public IPagination<Customer> FindAll(int startRow, int pageSize, GridSortOptions sort)
		{
			IEnumerable<Customer> query =
					Session.QueryOver<Customer>().OrderBy(sort).Skip(startRow).Take(pageSize).Future<Customer>();
			IFutureValue<int> count = Session.QueryOver<Customer>().Count().FutureValue<int>();
			return new CustomPagination<Customer>(query, startRow, pageSize, count.Value);
		}
	}
}