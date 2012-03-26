using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Web.Mvc.Controllers.Queries;
using NUnit.Framework;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.Testing.NUnit.NHibernate;

namespace BeautySalonManagement.Tests.BeautySalonManagement.Data.Domain
{
	[TestFixture]
	public class CustomerTestFixture: RepositoryTestsBase
	{
		readonly INHibernateRepository<Customer> productRepository = new NHibernateRepository<Customer>();
		protected override void SetUp()
		{
			ServiceLocatorInitializer.Init();
			base.SetUp();
		}
		protected override void LoadTestData()
		{

			for (int i = 0; i < 10; i++)
			{
				var customer = new Customer();
				customer.Address = "test";
				customer.Birthday = DateTime.Now;
				customer.CustomerCardNo = "CustomerNo"+i;
				customer.MobilePhone = "11111";
				customer.Name = "testName";
				customer.Password = "111";
				productRepository.Save(customer);
				FlushSessionAndEvict(customer);
			}
		}
		
		[Test]
		public void TestCustomerQuery()
		{
			ICustomerQuery customerQuery=new CustomerQuery();
			Assert.AreEqual(10,customerQuery.CountAll().Value);
			CollectionAssert.IsNotEmpty(customerQuery.FindAll(0,2,null));

		}

	}
}
