#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Peoples;

#endregion

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class PersonViewModel
	{
		[Required(ErrorMessage = "请输入密码")]
		[DisplayName("密码")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "请确认密码")]
		[DisplayName("确认密码")]
		[Compare("Password", ErrorMessage = "密码不匹配")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "请输入姓名")]
		[DisplayName("姓名")]
		public string Name { get; set; }

		[DataType(DataType.Date)]
		[DisplayName("出生日期")]
		[RegularExpression(@"(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})\/(((0[13578]|1[02])\/(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)\/(0[1-9]|[12][0-9]|30))|(02\/(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))\/02\/29)", ErrorMessage = "请输入正确的日期格式 例如:2012/01/01")]
		public string Birthday { get; set; }
		[Required(ErrorMessage = "请输入手机号码")]
	[RegularExpression(@"\d{11}",ErrorMessage = "手机号码应为11为数字")]
		[DisplayName("手机号码")]
		public string MobilePhone { get; set; }
[DisplayName("住址")]
		public string Address { get; set; }
		[HiddenInput]
		public int Id { get; set; }
		[Required(ErrorMessage = "请选择性别")]
		[DisplayName("性别")]
		public string GenderName { get; set; }
		public Gender GetGender()
		{
			return Gender.Parse(GenderName);
		}
		public DateTime? GetBirthday()
		{
			DateTime birthday;
			if(DateTime.TryParse(Birthday,out birthday))
			return birthday;
			return null;
		}
	}
}