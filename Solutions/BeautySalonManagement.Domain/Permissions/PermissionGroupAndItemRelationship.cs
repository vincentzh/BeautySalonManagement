using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Permissions
{
	public class PermissionGroupAndItemRelationship : Entity
	{
		public virtual PermissionGroup PermissionGroup { get; protected set; }
		public virtual PermissionItem PermissionItem { get; protected set; }
	}
}