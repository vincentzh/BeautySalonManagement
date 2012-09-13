using BeautySalonManagement.Domain.Interfaces;

namespace BeautySalonManagement.Domain.Articles
{

	public class Item : SaleInfo, IItem
	{
		public virtual IBrand Brand { get; set; }
	}
}