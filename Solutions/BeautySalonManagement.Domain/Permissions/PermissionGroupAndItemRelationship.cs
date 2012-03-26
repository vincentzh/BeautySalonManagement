using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

namespace BeautySalonManagement.Domain.Permissions
{
	[HasUniqueDomainSignature(ErrorMessage = "权限组关系已经存在")]
	public class PermissionGroupAndItemRelationship : Entity
	{
		[DomainSignature]
		public virtual PermissionGroup PermissionGroup { get; protected set; }
		[DomainSignature]
		public virtual PermissionItem PermissionItem { get; protected set; }
	}
}