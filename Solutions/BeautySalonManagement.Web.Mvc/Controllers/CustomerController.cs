using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks;
using MvcContrib.UI.Grid;

using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.NHibernate.Web.Mvc;
using MvcContrib.Pagination;
namespace BeautySalonManagement.Web.Mvc.Controllers
{
    public class CustomerController : Controller
    {
    	public readonly CustomerTask CustomerTask;
        //
        // GET: /Customer/
		public CustomerController(CustomerTask customerRepository)
		{
			CustomerTask = customerRepository;
		}
		[Transaction]
		[HttpGet]
        public ActionResult Index(int? startRow,GridSortOptions sort)
		{
			ViewBag.Sort = sort;
			var customers = CustomerTask.FindAll(startRow??1,2,sort);
			return View(customers);
        }
		// [Transaction]
		// [ValidateAntiForgeryToken]
		//[HttpPost]
		//public ActionResult Create(Customer customer)
		//{
			
		//}
    }
}
