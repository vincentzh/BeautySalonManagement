using System;
using MindHarbor.ClassEnum;

namespace BeautySalonManagement.Domain.Permissions
{
	[Serializable]
	public class ControllerNameEnum : ClassEnumGeneric<ControllerNameEnum>
	{
		public static readonly ControllerNameEnum Customer=new ControllerNameEnum("Customer","客户");
		ControllerNameEnum(string name, string desc) : base(name)
		{
			Description = desc;
		}

		public string Description { get; private set; }
	}
}