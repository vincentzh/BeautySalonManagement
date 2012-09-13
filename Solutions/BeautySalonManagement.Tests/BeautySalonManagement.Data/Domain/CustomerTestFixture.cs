using System;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Tasks;
using NUnit.Framework;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.Testing.NUnit.NHibernate;

namespace BeautySalonManagement.Tests.BeautySalonManagement.Data.Domain
{
	[TestFixture]
	public class CustomerTestFixture : RepositoryTestsBase
	{
		#region Setup/Teardown

		protected override void SetUp()
		{
			ServiceLocatorInitializer.Init();
			base.SetUp();
		}

		#endregion

		readonly INHibernateRepository<Customer> productRepository = new NHibernateRepository<Customer>();

		protected override void LoadTestData()
		{
			for (int i = 0; i < 10; i++)
			{
				var customer = new Customer();
				customer.Address = "test";
				customer.Birthday = DateTime.Now;
				customer.CustomerCardNo = "CustomerNo" + i;
				customer.MobilePhone = "11111";
				customer.Name = "testName";
				customer.Password = "111";
				customer.Gender = Gender.Female;
				productRepository.Save(customer);
				FlushSessionAndEvict(customer);
			}
		}

		[Test]
		public void TestCustomerQuery()
		{
			var customerTasks = new CustomerTasks();
			Assert.AreEqual(10, customerTasks.CountAll().Value);
			CollectionAssert.IsNotEmpty(customerTasks.FindAll(0, 2, null));
		}
	}
}