#region

using System.Collections.Generic;
using SharpArch.Domain.DomainModel;

#endregion

namespace BeautySalonManagement.Domain.Permissions
{
	public class PermissionItem : Entity
	{
		protected PermissionItem()
		{}

		public PermissionItem(PermissionDescription desc, PermissionBehavior behavior)
		{
			Description = desc;
			Behavior = behavior;
		}
		public virtual PermissionDescription Description { get; protected set; }

		public virtual PermissionBehavior Behavior { get; protected set; }
	}
}