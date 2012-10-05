using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class BrandViewModel
	{
		[HiddenInput]
		public int Id { get; set; }
		[DisplayName("品牌名称")]
		[Required(ErrorMessage = "请输入品牌名称")]
		public  string Name { get; set; }

		[DisplayName("描述")]
		public  string Description { get; set; }
	}
}