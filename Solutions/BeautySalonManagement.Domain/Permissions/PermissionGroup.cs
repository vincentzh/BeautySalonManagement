#region

using System.Collections.Generic;
using SharpArch.Domain.DomainModel;

#endregion

namespace BeautySalonManagement.Domain.Permissions
{
	public class PermissionGroup : Entity
	{
		public virtual string Name { get; set; }
		public virtual ICollection<PermissionGroupAndItemRelationship> Relationships { get; protected set; }
	}
}