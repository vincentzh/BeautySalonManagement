using BeautySalonManagement.Domain.Interfaces;
using BeautySalonManagement.Domain.Items;
using BeautySalonManagement.Domain.UserType;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class ItemMap : IAutoMappingOverride<Item>
	{
		#region IAutoMappingOverride<Item> Members

		public void Override(AutoMapping<Item> mapping)
		{
			mapping.Map(x => x.Type).CustomType<ItemUserType>().Not.Nullable();
			mapping.References<Brand>(x => x.Brand).Cascade.SaveUpdate().Not.Nullable();
		}

		#endregion
	}
}