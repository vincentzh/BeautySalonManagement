using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Peoples;
using SharpArch.Domain.Commands;

namespace BeautySalonManagement.Tasks.Commands.People
{
	public class PeopleCommandBase : CommandBase
	{
		[Required]
		[DisplayName("密码")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DisplayName("确认密码")]
		[Compare("Password", ErrorMessage = "密码不匹配")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required]
		[DisplayName("姓名")]
		public string Name { get; set; }

		[DataType(DataType.Date)]
		[DisplayName("出生日期")]
		public DateTime? Birthday { get; set; }
		[Required]
		[RegularExpression(@"\d{11}", ErrorMessage = "手机号码应为11为数字")]
		[DisplayName("手机")]
		public string MobilePhone { get; set; }
		[DisplayName("住址")]
		public string Address { get; set; }
		public int Id { get; set; }
		[Required]
		[DisplayName("性别")]
		public Gender Gender { get; set; }
	}
}