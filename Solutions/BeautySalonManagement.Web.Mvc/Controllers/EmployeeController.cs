using System.Web.Mvc;
using AutoMapper;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks.Commands.Customers;
using BeautySalonManagement.Tasks.Commands.Employees;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.CommandHandlers;
using CommonLib.Util;
using MvcContrib;
using MvcContrib.UI.Grid;
using SharpArch.Domain.Commands;
using SharpArch.NHibernate.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
    public class EmployeeController : Controller
    {
    	ICommandProcessor CommandProcessor;
    	IEmployeeTasks EmployeeTasks;
		public EmployeeController(ICommandProcessor commandProcessor,IEmployeeTasks employeeTasks)
		{
			CommandProcessor = commandProcessor;
			EmployeeTasks = employeeTasks;
		}
        //
        // GET: /Employee/


		[HttpGet]
		public ActionResult Index(int? pageIndex, GridSortOptions sort)
		{
			ViewBag.Sort = sort;


			return View(new CustomPaginationHelper<Employee>(EmployeeTasks).Pagination(pageIndex, sort));
		}

     

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[Transaction]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Create(EmployeeViewModel employeeViewModel)
		{
			if (ModelState.IsValid)
			{
				var addEmployeeCommand = new AddEmployeeCommand();
				Mapper.CreateMap<EmployeeViewModel, AddEmployeeCommand>().BeforeMap((s, d) => d.Password = s.ConfirmPassword);
				Mapper.Map(employeeViewModel, addEmployeeCommand);

				CommandProcessor.Process<AddEmployeeCommand, CommandResult>(addEmployeeCommand, ModelState);
				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var employee = EmployeeTasks.Get(id);
			if (employee != null)
			{
				Mapper.CreateMap<Employee, EmployeeViewModel>().AfterMap((c, m) => { m.ConfirmPassword = c.Password; }).AfterMap(
						(c, m) => { m.Birthday = c.Birthday == null ? string.Empty : c.Birthday.Value.ToString("yyyy/MM/dd"); });
				EmployeeViewModel employeeViewModel = Mapper.Map<Employee, EmployeeViewModel>(employee);
				return View(employeeViewModel);
			}
			return new HttpNotFoundResult();
		}

		[HttpPost]
		[Transaction]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EmployeeViewModel employeeViewModel)
		{
			if (ModelState.IsValid)
			{
				var editEmployeeCommand = new EditEmployeeCommand();
				Mapper.CreateMap<EmployeeViewModel, EditEmployeeCommand>();
				Mapper.Map(employeeViewModel, editEmployeeCommand);
				CommandProcessor.Process<EditEmployeeCommand, CommandResult>(editEmployeeCommand, ModelState);

				if (!ModelState.IsValid)
					return View();
				return this.RedirectToAction(c => c.Index(null, null));
			}

			return View();
		}
    }
}
