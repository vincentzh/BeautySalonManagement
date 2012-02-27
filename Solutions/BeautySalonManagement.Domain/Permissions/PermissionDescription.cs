#region

using System;
using MindHarbor.ClassEnum;

#endregion

namespace BeautySalonManagement.Domain.Permissions
{
	[Serializable]
	public class PermissionDescription : ClassEnumGeneric<PermissionDescription>
	{
		public readonly static PermissionDescription Employee = new PermissionDescription("employee", "员工");
		private readonly string description;

		public PermissionDescription(string name, string desc) : base(name)
		{
			description = desc;
		}

		public virtual string Description
		{
			get { return description; }
		}
	}
}