using System.ComponentModel;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class EmployeeViewModel : PersonViewModel
	{
		[DisplayName("联系人")]
		public string ContactInfoName { get; set; }
		[DisplayName("联系人电话")]
		public string ContactInfoPhone { get; set; }
	}
}