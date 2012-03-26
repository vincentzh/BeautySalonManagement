using BeautySalonManagement.Domain.Peoples;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomerMap
{
	public class PeopleMap : IAutoMappingOverride<People>
	{
		#region IAutoMappingOverride<People> Members

		public void Override(AutoMapping<People> mapping)
		{
			mapping.Map(x => x.Name).Not.Nullable();
			mapping.Map(x => x.Password).Access.CamelCaseField().Not.Nullable();
			mapping.Map(x => x.Salt).Not.Nullable();
			mapping.Map(x => x.Gender).Not.Nullable();
			mapping.Map(x => x.MobilePhone).Not.Nullable();
		}

		#endregion
	}
}