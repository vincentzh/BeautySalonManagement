using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customer;
using BeautySalonManagement.Web.Mvc.Controllers.Queries;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using MvcContrib;
using MvcContrib.Pagination;
using MvcContrib.UI.Grid;
using NHibernate;
using SharpArch.Domain.Commands;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.NHibernate.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
	public class CustomerController : Controller
	{
		public readonly ICommandProcessor CommandProcessor;
		public readonly ICustomerQuery CustomerQuery;
		public readonly INHibernateRepository<Customer> CustomerRepository;
		//
		// GET: /Customer/
		public CustomerController(ICustomerQuery customerQuery, ICommandProcessor commandProcessor)
		{
			CustomerQuery = customerQuery;
			CommandProcessor = commandProcessor;
		}

		[Transaction]
		[HttpGet]
		public ActionResult Index(int? page, GridSortOptions sort)
		{
			ViewBag.Sort = sort;
			int pageSize = 2;

			int startRow = pageSize*((page ?? 1) - 1);
			IEnumerable<Customer> customers = CustomerQuery.FindAll(startRow, pageSize, sort);
			IFutureValue<int> count = CustomerQuery.CountAll();

			return View(new CustomPagination<Customer>(customers, page ?? 1, pageSize, count.Value));
		}

		[Transaction]
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[Transaction]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Create(CustomerViewModel customerViewModel)
		{
			if (ModelState.IsValid)
			{
				var addCustomerCommand = new AddCustomerCommand();
				Mapper.CreateMap<CustomerViewModel, AddCustomerCommand>().BeforeMap((s, d) => d.Password = s.ConfirmPassword);
				Mapper.Map(customerViewModel, addCustomerCommand);
				CommandProcessor.Process(addCustomerCommand);
				return this.RedirectToAction(c => c.Index(null, null));
			}
			
				return View();
			
		}
	}
}