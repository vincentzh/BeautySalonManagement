using BeautySalonManagement.Domain.Peoples;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomerMap
{
	public class CustomerMap : IAutoMappingOverride<Customer>
	{
		#region IAutoMappingOverride<Customer> Members

		public void Override(AutoMapping<Customer> mapping)
		{
			mapping.Table("tblCustomers");
		}

		#endregion
	}
}