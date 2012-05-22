#region

using System.Collections.Generic;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

#endregion

namespace BeautySalonManagement.Domain.Permissions
{
	[HasUniqueDomainSignature(ErrorMessage = "权限组已经存在")]
	public class PermissionGroup : Entity
	{
		[DomainSignature]
		public virtual string Name { get; set; }
		public virtual ICollection<PermissionGroupAndControllerActionRelation> PermissionGroupAndControllerActionRelations { get; protected set; }
	}
}