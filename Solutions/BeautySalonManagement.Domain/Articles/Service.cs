using System.Collections.Generic;
using BeautySalonManagement.Domain.Interfaces;
using MindHarbor.CollectionWrappers;

namespace BeautySalonManagement.Domain.Articles
{
	public class Service : SaleInfo, IService
	{
		readonly ISet<Item> _items = new HashSet<Item>();

		public virtual ICollection<Item> Items
		{
			get { return new ReadonlyCollection<Item>(_items); }
		}

		public virtual void AddItem(Item item)
		{
			if (!_items.Contains(item))
				_items.Add(item);
		}
		public virtual bool RemoveItem(Item item)
		{
			return _items.Remove(item);
		}

	}
}