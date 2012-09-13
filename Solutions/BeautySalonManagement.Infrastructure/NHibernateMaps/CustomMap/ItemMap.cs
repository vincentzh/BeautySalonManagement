using BeautySalonManagement.Domain.Articles;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class ItemMap : IAutoMappingOverride<Item>
	{
		#region IAutoMappingOverride<Item> Members

		public void Override(AutoMapping<Item> mapping)
		{
			mapping.Table("tblItems");
			mapping.UseUnionSubclassForInheritanceMapping();
			mapping.References<Brand>(x => x.Brand).Cascade.SaveUpdate().Not.Nullable();
		}

		#endregion
	}
}