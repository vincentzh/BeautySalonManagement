#region

using BeautySalonManagement.Domain.Permissions;
using BeautySalonManagement.Tests.BeautySalonManagement.Data.NHibernateMaps;
using NUnit.Framework;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.Testing.NUnit.NHibernate;

#endregion

namespace BeautySalonManagement.Tests.BeautySalonManagement.Data.Domain
{
	[TestFixture]
	public class PermissionTestFixture : RepositoryTestsBase
	{
		readonly INHibernateRepository<PermissionItem> productRepository = new NHibernateRepository<PermissionItem>();
		PermissionItem p1;
		PermissionItem p2;
		protected override void SetUp()
		{
			ServiceLocatorInitializer.Init();
			base.SetUp();
		}
		[Test]
		public void TestSave()
		{
			
			this.productRepository.Save(p1);
			this.productRepository.Save(p2);
		
			Assert.IsNotNull(productRepository.Get(p1.Id));
			Assert.IsNotNull(productRepository.Get(p2.Id));
		}

		protected override void LoadTestData()
		{
			 p1 = new PermissionItem(PermissionDescription.Employee, PermissionBehavior.View);
			 p2 = new PermissionItem(PermissionDescription.Employee, PermissionBehavior.View);
			
		}
	}
}