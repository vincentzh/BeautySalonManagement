using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BeautySalonManagement.Domain.Items;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
	public class ItemViewModel
	{
		[Required]
		[DisplayName("名称")]
		public string Name { get; set; }
		[DisplayName("描述")]
		public string Description { get; set; }
		[Required]
		[DisplayName("售价")]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
		[Required]
		[DisplayName("成本")]
		[DataType(DataType.Currency)]
		public decimal Cost { get; set; }
		[DisplayName("停止销售")]
		public bool Disable { get; set; }
		[Required]
		public string ItemTypeName { get; set; }

		[Required]
		[DisplayName("品牌")]
		[Range(1,int.MaxValue,ErrorMessage = "请指定一个品牌")]
		public int BrandId { get; set; }

		public ItemType GetItemType()
		{
			return ItemType.Parse(ItemTypeName);
		}
	}
}