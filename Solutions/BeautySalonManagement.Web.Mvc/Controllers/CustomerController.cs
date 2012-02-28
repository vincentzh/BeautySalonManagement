using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Web.Mvc.Controllers.Queries;
using MvcContrib.UI.Grid;

using SharpArch.NHibernate.Web.Mvc;
using MvcContrib.Pagination;
namespace BeautySalonManagement.Web.Mvc.Controllers
{
    public class CustomerController : Controller
    {
		public readonly ICustomerQuery CustomerQuery;

        //
        // GET: /Customer/
		public CustomerController(ICustomerQuery customerQuery)
		{
			CustomerQuery = customerQuery;
		}
		[Transaction]
		[HttpGet]
        public ActionResult Index(int? page,GridSortOptions sort)
		{
			ViewBag.Sort = sort;
			var pageSize = 2;
			
			var startRow = pageSize * ((page ?? 1) - 1);
			var customers = CustomerQuery.FindAll(startRow, pageSize, sort);
			var count = CustomerQuery.CountAll();

			return View(new CustomPagination<Customer>(customers, page ?? 1, pageSize, count.Value));
        }
		// [Transaction]
		// [ValidateAntiForgeryToken]
		//[HttpPost]
		//public ActionResult Create(Customer customer)
		//{
			
		//}
    }
}
