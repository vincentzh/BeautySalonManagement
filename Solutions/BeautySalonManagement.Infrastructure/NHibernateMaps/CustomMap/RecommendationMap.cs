using BeautySalonManagement.Domain.Peoples;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class RecommendationMap:IAutoMappingOverride<Recommendation>
	{
		public void Override(AutoMapping<Recommendation> mapping)
		{
			mapping.References(x => x.Introduce, "IntroduceId").Cascade.SaveUpdate();
			mapping.References(x => x.Rookie, "RookieId").Cascade.SaveUpdate();
		}
	}
}
