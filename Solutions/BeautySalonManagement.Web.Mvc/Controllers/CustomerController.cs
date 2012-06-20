#region

using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customers;
using BeautySalonManagement.Web.Mvc.Base;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.CommandHandlers;
using CommonLib.Util;
using MvcContrib;
using MvcContrib.UI.Grid;
using SharpArch.Domain.Commands;
using SharpArch.NHibernate.Web.Mvc;

#endregion

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


		[HttpGet]
		public ActionResult Index(int? pageIndex, GridSortOptions sort)
		{
			ViewBag.Sort = sort;


			return View(new CustomPaginationHelper<Customer>(CustomerTasks).Pagination(pageIndex, sort));
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
			
				CommandProcessor.Process<AddCustomerCommand, CommandResult>(addCustomerCommand, ModelState);
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
			if (customer != null)
			{
				Mapper.CreateMap<Customer, CustomerViewModel>().AfterMap((c, m) => { m.ConfirmPassword = c.Password; }).AfterMap(
						(c, m) => { m.Birthday = c.Birthday == null ? string.Empty : c.Birthday.Value.ToString("yyyy/MM/dd"); });
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
				CommandProcessor.Process<EditCustomerCommand, CommandResult>(editCustomerCommand, ModelState);
				
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}
	}
}