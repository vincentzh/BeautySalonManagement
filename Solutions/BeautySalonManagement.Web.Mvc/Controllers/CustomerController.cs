using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customers;
using BeautySalonManagement.Web.Mvc.Base;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.CommandHandlers;
using CommonLib.ControlsExtension;
using MvcContrib;
using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;
using NHibernate;
using SharpArch.Domain.Commands;
using SharpArch.NHibernate.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
	public class CustomerController : CustomControllerBase
	{
		public readonly ICommandProcessor CommandProcessor;
		public readonly ICustomerTasks CustomerTasks;
		//
		// GET: /Customer/
		public CustomerController(ICustomerTasks customerTasks, ICommandProcessor commandProcessor)
		{
			CustomerTasks = customerTasks;
			CommandProcessor = commandProcessor;
		}

		[Transaction]
		[HttpGet]
		public ActionResult Index(int? page=null, GridSortOptions sort=null)
		{
			ViewBag.Sort = sort;
			int pageSize = 10;

			int startRow = pageSize*((page ?? 1) - 1);
			IEnumerable<Customer> customers = CustomerTasks.FindAll(startRow, pageSize,
			                                                        new MvcContributeGridSort
			                                                        	{
			                                                        			Column = sort.Column,
			                                                        			Direction =
			                                                        					(sort.Direction == SortDirection.Ascending
			                                                        					 		? Direction.ASC
			                                                        					 		: Direction.DESC)
			                                                        	});
			IFutureValue<int> count = CustomerTasks.CountAll();

			return View(new CustomPagination<Customer>(customers, page ?? 1, pageSize, count.Value));
		}

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
				CommandProcessor.Process<AddCustomerCommand,CommandResult>(addCustomerCommand,x=>
				{
					if(!x.Success)
					{
						foreach (var errorMessage in x.ErrorMessages)
						{
							ModelState.AddModelError("", errorMessage);
						}
					}
				});
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{

			Customer customer = CustomerTasks.Get(id);
			if(customer!=null)
			{
				Mapper.CreateMap<Customer, CustomerViewModel>().AfterMap((c, m) => { m.ConfirmPassword = c.Password; }).AfterMap((c, m) =>
				{ m.Birthday = c.Birthday == null ? string.Empty : c.Birthday.Value.ToString("yyyy/MM/dd"); });
				CustomerViewModel customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
				return View(customerViewModel);
			}
			return new HttpNotFoundResult();
		}
		[HttpPost]
		[Transaction]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CustomerViewModel customerViewModel)
		{
			if (ModelState.IsValid)
			{
				var editCustomerCommand = new EditCustomerCommand();
				Mapper.CreateMap<CustomerViewModel, EditCustomerCommand>();
				Mapper.Map(customerViewModel, editCustomerCommand);
				CommandProcessor.Process<EditCustomerCommand,CommandResult>(editCustomerCommand,x=>
				{
					if(!x.Success)
					{
						foreach (var errorMessage in x.ErrorMessages)
						{
							ModelState.AddModelError("", errorMessage);
						}
					}
				});
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}
	}
}