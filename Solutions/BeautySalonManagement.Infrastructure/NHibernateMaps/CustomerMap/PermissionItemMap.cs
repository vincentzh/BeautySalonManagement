#region

using BeautySalonManagement.Domain.Permissions;
using BeautySalonManagement.Domain.UserType;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

#endregion

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomerMap
{
	/// <summary>
	///     Description of PermissionItemMap.
	/// </summary>
	public class PermissionItemMap : IAutoMappingOverride<PermissionItem>
	{
		public void Override(AutoMapping<PermissionItem> mapping)
		{
			mapping.Map(x => x.Description).CustomType<PermissionDescriptionUserType>();
			mapping.Map(y => y.Behavior).CustomType<PermissionBehaviorUserType>();
		}
	}
}