using BeautySalonManagement.Domain.Permissions;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomerMap
{
	public class PermissionGroupMap : IAutoMappingOverride<PermissionGroup>
	{
		#region IAutoMappingOverride<PermissionGroup> Members

		public void Override(AutoMapping<PermissionGroup> mapping)
		{
			mapping.HasManyToMany(x => x.PermissionItems).Cascade.All().LazyLoad();
			mapping.Map(x => x.Name).UniqueKey("u_Name");
		}

		#endregion
	}
}