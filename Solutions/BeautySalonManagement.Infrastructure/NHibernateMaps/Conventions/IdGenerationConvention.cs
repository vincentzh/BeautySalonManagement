using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
	public class IdGenerationConvention : IIdConvention

	{
		#region IIdConvention Members

		public void Apply(IIdentityInstance instance)
		{
			instance.GeneratedBy.HiLo("1000");
		}

		#endregion
	}
}