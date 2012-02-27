#region

using System;
using MindHarbor.ClassEnum;

#endregion

namespace BeautySalonManagement.Domain.Permissions
{
	[Serializable]
	public class PermissionBehavior : ClassEnumGeneric<PermissionBehavior>
	{
		public static readonly PermissionBehavior View = new PermissionBehavior("View", "只读");
		public static readonly PermissionBehavior Edit = new PermissionBehavior("Edit", "编辑");
		private readonly string description;

		protected PermissionBehavior(string name, string desc) : base(name)
		{
			description = desc;
		}

		public virtual string Description
		{
			get { return description; }
		}
	}
}