using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Web.Mvc.Controllers;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using CommonLib.Util.Authentications;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Machine.Specifications.Mvc;
using NHibernate;
using Rhino.Mocks;

namespace MSpecTests.BeautySalonManagement
{
	[Subject(typeof(LoginController))]
	public class when_login:Specification<LoginController>
	{
		static IEmployeeTasks EmployeeTasks;
		static ICustomFormsAuthentication CustomerFormsAuthentication;
		static LoginController LoginController;
		static LoginViewModel LoginViewModel;
		static ActionResult result;
		static Employee employee;
		Establish contact = () =>
		{
			EmployeeTasks = DependencyOf<IEmployeeTasks>();
			CustomerFormsAuthentication = DependencyOf<ICustomFormsAuthentication>();
			LoginController = MockRepository.GenerateMock<LoginController>(EmployeeTasks, CustomerFormsAuthentication);
			employee = MockRepository.GenerateMock<Employee>();
			
			LoginViewModel = new LoginViewModel()
			                 	{
			                 			EmployeeNo = "test",
			                 			Password = "test"
			                 	};
			EmployeeTasks.Stub(x => x.FindByWithLoginInfo(LoginViewModel.EmployeeNo, LoginViewModel.Password)).Return(employee);
		};

		Because of = () => result=LoginController.Index(LoginViewModel);
		It should_redirect_to_Home = () => result.ShouldRedirectToAction<HomeController>(x => x.Index());


	}
}
