using System.ComponentModel.DataAnnotations;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class CustomerViewModel : PersonViewModel
	{
		[Required(ErrorMessage = "CustomerCardNo 不能为空")]
		public string CustomerCardNo { get; set; }
	}
}