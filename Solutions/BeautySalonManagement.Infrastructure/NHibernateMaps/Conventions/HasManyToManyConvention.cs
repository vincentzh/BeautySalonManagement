using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
	public class HasManyToManyConvention:IHasManyToManyConvention
	{
		public void Apply(IManyToManyCollectionInstance instance)
		{
			string tablename ="tbl"+ instance.EntityType.Name + "_" + instance.ChildType.Name + "_Relationships";
			instance.Table(tablename);
		}
	}
}
