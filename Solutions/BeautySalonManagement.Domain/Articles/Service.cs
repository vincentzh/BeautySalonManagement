using System.Collections.Generic;
using BeautySalonManagement.Domain.Interfaces;
using MindHarbor.CollectionWrappers;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Articles
{
	public class Service : SaleInfo, IService
	{
		readonly ISet<Item> items = new HashSet<Item>();

		public virtual ICollection<Item> Items
		{
			get { return new ReadonlyCollection<Item>(items); }
		}

		
	}
}