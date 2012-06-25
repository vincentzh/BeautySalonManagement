using BeautySalonManagement.Domain.Peoples;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class CustomerMap : IAutoMappingOverride<Customer>
	{
		#region IAutoMappingOverride<Customer> Members

		public void Override(AutoMapping<Customer> mapping)
		{
			mapping.Table("tblCustomers");
			mapping.UseUnionSubclassForInheritanceMapping();
			mapping.Map(x => x.CustomerCardNo).UniqueKey("CustomerCardNo").Not.Nullable();
		}

		#endregion
	}
}