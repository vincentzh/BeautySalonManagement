#region

using System;
using BeautySalonManagement.Domain.Permissions;
using MindHarbor.ClassEnum;

#endregion

namespace BeautySalonManagement.Domain.UserType
{
	[Serializable]
	public class PermissionBehaviorUserType : ClassEnumUserType<PermissionBehavior>
	{}
}