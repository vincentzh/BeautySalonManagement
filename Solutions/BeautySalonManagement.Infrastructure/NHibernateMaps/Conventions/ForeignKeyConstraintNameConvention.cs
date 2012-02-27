using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
	public class ForeignKeyConstraintNameConvention : IHasManyConvention
	{
		#region IHasManyConvention Members

		public void Apply(IOneToManyCollectionInstance instance)
		{
			instance.Key.ForeignKey(String.Format("{0}_{1}_FK", instance.Member.Name, instance.EntityType.Name));
		}

		#endregion
	}
}