using System.Collections.Generic;
using BeautySalonManagement.Domain.Interfaces;
using BeautySalonManagement.Domain.Items;
using MindHarbor.CollectionWrappers;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Services
{
	public class Service : Entity, ISaleInfo
	{
		readonly ISet<Item> items = new HashSet<Item>();

		public virtual ICollection<Item> Items
		{
			get { return new ReadonlyCollection<Item>(items); }
		}

		#region ISaleInfo Members

		public virtual string Name { get; set; }

		public virtual decimal Price { get; set; }

		public virtual decimal Cost { get; set; }

		#endregion
	}
}