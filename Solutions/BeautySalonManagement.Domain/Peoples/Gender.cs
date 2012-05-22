using MindHarbor.ClassEnum;

namespace BeautySalonManagement.Domain.Peoples
{
	public class Gender : ClassEnumGeneric<Gender>
	{
		public static readonly Gender Female = new Gender("Female", "女");
		public static readonly Gender Male = new Gender("Male", "男");

		Gender(string name, string desc) : base(name)
		{
			Desc = desc;
		}

		public string Desc { get; set; }
	}
}