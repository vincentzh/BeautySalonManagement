using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class LoginViewModel
	{
		[DisplayName("工号:")]
		[Required(ErrorMessage = "请输入工号")]
	
	    public string EmployeeNo { get; set; }

		[DisplayName("密码:")]
		[Required(ErrorMessage = "请输入密码")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}