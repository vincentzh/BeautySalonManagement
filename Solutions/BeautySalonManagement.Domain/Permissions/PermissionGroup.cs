using System.Collections.Generic;
using BeautySalonManagement.Domain.Peoples;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Permissions
{
	public class PermissionGroup:Entity
	{
		public virtual string Name { get; set; }
		public virtual ICollection<PermissionGroupAndItemRelationship> Relationships { get; protected set; }
		
	}
}
