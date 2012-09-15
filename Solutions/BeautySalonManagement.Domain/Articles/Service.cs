using System.Collections.Generic;
using BeautySalonManagement.Domain.Interfaces;
using MindHarbor.CollectionWrappers;

namespace BeautySalonManagement.Domain.Articles
{
	public class Service : SaleInfo, IService
	{
		readonly ISet<Item> items = new HashSet<Item>();

		public virtual ICollection<Item> Items
		{
			get { return new ReadonlyCollection<Item>(items); }
		}

		public virtual void AddItem(Item item)
		{
			if (!items.Contains(item))
				items.Add(item);
		}
		public virtual bool RemoveItem(Item item)
		{
			return items.Remove(item);
		}

	}
}