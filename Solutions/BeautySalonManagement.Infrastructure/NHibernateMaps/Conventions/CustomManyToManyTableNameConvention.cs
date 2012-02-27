using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
	public class CustomManyToManyTableNameConvention
			: ManyToManyTableNameConvention
	{
		protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection,
		                                                    IManyToManyCollectionInspector otherSide)
		{
			return "tbl" + collection.EntityType.Name + "_" + otherSide.EntityType.Name+"_R";
		}
		
		protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
		{
			return "tbl" + collection.EntityType.Name + "_" + collection.ChildType.Name+"_R";
		}
		
	}
}