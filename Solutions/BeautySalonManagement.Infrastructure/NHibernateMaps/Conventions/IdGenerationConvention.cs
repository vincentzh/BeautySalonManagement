using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
	public class IdGenerationConvention : IIdConvention

	{
		#region IIdConvention Members

		public void Apply(IIdentityInstance instance)
		{

			instance.GeneratedBy.HiLo(instance.EntityType.Name.InflectTo().Pluralized+"_HiLo" ,"NextHi", "1000");
		}

		#endregion
	}
}