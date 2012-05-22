using System;
using MindHarbor.ClassEnum;

namespace BeautySalonManagement.Domain.Permissions
{
	[Serializable]
	public class ActionNameEnum : ClassEnumGeneric<ActionNameEnum>
	{
		public static readonly ActionNameEnum Create = new ActionNameEnum("Create", "创建");
		public static readonly ActionNameEnum Delete = new ActionNameEnum("Delete", "删除");
		public static readonly ActionNameEnum Edit = new ActionNameEnum("Edit", "编辑");
		public static readonly ActionNameEnum Index = new ActionNameEnum("Index", "列表");

		ActionNameEnum(string name, string desc) : base(name)
		{
			Description = desc;
		}

		public string Description { get; private set; }
	}
}