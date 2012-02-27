using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
	public class ForeignKeyNameConvention : IHasOneConvention
	{
		#region IHasOneConvention Members

		public void Apply(IOneToOneInstance instance)
		{
			instance.ForeignKey(String.Format("{0}_{1}_FK", instance.Name, instance.EntityType.Name));
		}

		#endregion
	}
}