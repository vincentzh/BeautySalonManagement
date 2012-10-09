using BeautySalonManagement.Domain.Articles;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class ServiceMap : IAutoMappingOverride<Service>
	{
		#region IAutoMappingOverride<Service> Members

		public void Override(AutoMapping<Service> mapping)
		{
			mapping.Table("tblServices");
			mapping.UseUnionSubclassForInheritanceMapping();
			mapping.HasManyToMany(x => x.Items).Access.ReadOnlyPropertyThroughLowerCaseField(Prefix.Underscore).AsSet().LazyLoad().Cascade.SaveUpdate().Table("tblServiceAndItems");
		}

		#endregion
	}
}