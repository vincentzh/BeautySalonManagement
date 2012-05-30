#region

using System.Web.Mvc;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Web.Mvc.Controllers;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Machine.Specifications.Mvc;
using Rhino.Mocks;
using SharpArch.Domain.Commands;

#endregion

namespace MSpecTests.BeautySalonManagement
{
	[Subject(typeof (CustomerController))]
	public class should_create_customer : Specification<CustomerController>
	{
		static ICustomerTasks CustomerTasks;
		static ICommandProcessor commandProcessor;
		static CustomerController customerController;
		static CustomerViewModel customerViewModel;
		static ActionResult result;

		Establish contact = () =>
		{
			CustomerTasks = DependencyOf<ICustomerTasks>();
			commandProcessor = DependencyOf<ICommandProcessor>();
			customerController = MockRepository.GenerateMock<CustomerController>(CustomerTasks, commandProcessor);
			customerViewModel = new CustomerViewModel
			                    	{
			                    			Address = "test",
			                    			Birthday = null,
			                    			CustomerCardNo = "test",
			                    			MobilePhone = "test",
			                    			Name = "test",
			                    			Password = "test"
			                    	};
		};

		Because of = () => result = customerController.Create(customerViewModel);
		It should_redirect_to_index = () => result.ShouldRedirectToAction<CustomerController>(x => x.Index(null, null));
		
	}
}