using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Peoples;
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
			

		}
		[Test]
		public void GData()
		{
			for (int i = 0; i < 10; i++)
			{
				var customer = new Customer();
				customer.Address = "test";
				customer.Birthday = DateTime.Now;
				customer.CreateDate = DateTime.Now;
				customer.CustomerCardNo = "testCustomerNo";
				customer.MobilePhone = "11111";
				customer.Name = "testName";
				customer.Password = "111";
				customer.Salt = DateTime.Now.ToBinary().ToString();
				productRepository.Save(customer);
				FlushSessionAndEvict(customer);
			}
		}
	}
}
