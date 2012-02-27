using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
	public class ReferenceConvention : IReferenceConvention
	{
		#region IReferenceConvention Members

		public void Apply(IManyToOneInstance instance)
		{
			instance.Column(instance.Property.PropertyType.Name + "Id");
			instance.ForeignKey(instance.EntityType.Name+"_"+instance.Property.Name+"_FK");
		}

		#endregion
	}
}