using BeautySalonManagement.Domain.Services;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class ServiceMap : IAutoMappingOverride<Service>
	{
		#region IAutoMappingOverride<Service> Members

		public void Override(AutoMapping<Service> mapping)
		{
			mapping.HasManyToMany(x => x.Items).Access.CamelCaseField().AsSet().LazyLoad().Cascade.SaveUpdate().Table("tblServiceAndItems");
		}

		#endregion
	}
}