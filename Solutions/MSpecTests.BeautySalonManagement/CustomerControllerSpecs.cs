#region

using System.Collections.Generic;
using System.Linq;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Web.Mvc.Controllers;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.Domain.Specifications;
using SharpArch.NHibernate;

#endregion

namespace MSpecTests.BeautySalonManagement
{
	[Subject(typeof (CustomerController))]
	public class CustomerControllerSpecs : Specification<CustomerController>
	{
		static ILinqRepository<Customer> CustomerRepository;
		static IQueryable<Customer> result ;
		
		Establish contact = () =>
		{
			CustomerRepository = new LinqRepository<Customer>();
		};

		Because of = () => result = CustomerRepository.FindAll();

	}
}