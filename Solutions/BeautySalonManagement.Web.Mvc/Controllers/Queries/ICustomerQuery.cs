using System.Collections.Generic;
using BeautySalonManagement.Domain.Peoples;
using MvcContrib.UI.Grid;
using NHibernate;

namespace BeautySalonManagement.Web.Mvc.Controllers.Queries
{
	public interface ICustomerQuery
	{
		IEnumerable<Customer> FindAll(int startRow, int pageSize, GridSortOptions sort);
		IFutureValue<int> CountAll();
	}
}