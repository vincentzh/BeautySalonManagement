#region

using System.Collections.Generic;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Web.Mvc.Controllers;
using BeautySalonManagement.Web.Mvc.Controllers.Queries;
using BeautySalonManagement.Web.Mvc.Controllers.ViewModels;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Machine.Specifications.Mvc;
using MvcContrib.UI.Grid;
using Rhino.Mocks;
using SharpArch.Domain.Commands;

#endregion

namespace MSpecTests.BeautySalonManagement
{
	[Subject(typeof (CustomerController))]
	public class CustomerControllerSpecs : Specification<CustomerController>
	{
		static ICustomerQuery CustomerQuery;
		static IEnumerable<Customer> result;
		static GridSortOptions sort;

		Establish contact = () =>
		{
			CustomerQuery = new CustomerQuery();
			sort = new GridSortOptions();
		};

		Because of = () => result = CustomerQuery.FindAll(0, 2, sort);
		It should_return_not_empty = () => result.ShouldNotBeEmpty();
	}

	[Subject(typeof (CustomerController))]
	public class should_create_customer : Specification<CustomerController>
	{
		static ICustomerQuery CustomerQuery;
		static ICommandProcessor commandProcessor;
		static CustomerController customerController;
		static CustomerViewModel customerViewModel;
		static ActionResult result;

		Establish contact = () =>
		{
			CustomerQuery = DependencyOf<ICustomerQuery>();
			commandProcessor = DependencyOf<ICommandProcessor>();
			customerController = MockRepository.GenerateMock<CustomerController>(CustomerQuery, commandProcessor);
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