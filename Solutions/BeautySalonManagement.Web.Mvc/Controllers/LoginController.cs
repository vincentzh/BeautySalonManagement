using System.Web.Mvc;
using BeautySalonManagement.Domain;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Web.Mvc.Base;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.Util.Authentications;
using MvcContrib;
using NHibernate;
using SharpArch.NHibernate.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
	public class LoginController : CustomControllerBase
	{
		readonly ICustomFormsAuthentication CustomFormsAuthentication;
		readonly IEmployeeTasks _employeeTasks;
		//
		// GET: /Login/
		public LoginController(IEmployeeTasks employeeTasks, ICustomFormsAuthentication customFormsAuthentication)
		{
			_employeeTasks = employeeTasks;
			CustomFormsAuthentication = customFormsAuthentication;
		}

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}


		//
		// POST: /Login/Index

		[Transaction]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Index(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				Employee employee = _employeeTasks.FindByWithLoginInfo(model.EmployeeNo, model.Password);
				if (employee != null)
				{
					DomainSession.Current.People = employee;
					CustomFormsAuthentication.SetAuthCookie(DomainSession.Current.People.Name, false);
					return this.RedirectToAction<HomeController>(x => x.Index());
				}
				ModelState.AddModelError("", "登录失败!");
			}
			return View();
		}
	}
}