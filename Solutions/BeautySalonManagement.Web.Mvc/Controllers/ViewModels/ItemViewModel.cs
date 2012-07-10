using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Items;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class ItemViewModel
	{
		[HiddenInput]
		public int Id { get; set; }
		[Required(ErrorMessage = "请输入名称")]
		[DisplayName("名称")]
		public string Name { get; set; }
		[DisplayName("描述")]
		public string Description { get; set; }
		[Required(ErrorMessage = "请输入售价")]
		[DisplayName("售价")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "请输入成本")]
		[DisplayName("成本")]
		[DataType(DataType.Currency)]
		public decimal Cost { get; set; }
		[DisplayName("停止销售")]
		public bool Disable { get; set; }
		[Required(ErrorMessage = "请选择类别")]
		[DisplayName("类别")]
		public string ItemTypeName { get; set; }

		[Required(ErrorMessage = "请指定一个品牌")]
		[DisplayName("品牌")]
		[Range(1,int.MaxValue,ErrorMessage = "请指定一个品牌")]
		public int BrandId { get; set; }

		public ItemType GetItemType()
		{
			return ItemType.Parse(ItemTypeName);
		}
	}
}