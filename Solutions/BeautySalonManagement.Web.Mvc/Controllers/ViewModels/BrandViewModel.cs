using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class BrandViewModel
	{
		[DisplayName("品牌名称")]
		[Required(ErrorMessage = "请输入品牌名称")]
		public virtual string Name { get; set; }

		[DisplayName("描述")]
		public virtual string Description { get; set; }
	}
}