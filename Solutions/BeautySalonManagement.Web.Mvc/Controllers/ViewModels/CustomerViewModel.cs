using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class CustomerViewModel : PersonViewModel
	{
		[Required(ErrorMessage = "会员卡号不能为空")]
		[DisplayName("会员卡号")]
		public string CustomerCardNo { get; set; }
	}
}