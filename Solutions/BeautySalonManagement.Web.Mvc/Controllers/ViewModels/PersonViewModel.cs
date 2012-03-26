#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

#endregion

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class PersonViewModel
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
		public string Name { get; set; }

		[DataType(DataType.Date)]
		public DateTime? Birthday { get; set; }
		
		public string MobilePhone { get; set; }

		public string Address { get; set; }
		public int Id { get; set; }
	}
}