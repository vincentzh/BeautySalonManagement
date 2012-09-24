using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Articles;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class EquipmentMap : IAutoMappingOverride<Equipment>
	{
		public void Override(AutoMapping<Equipment> mapping)
		{
			mapping.Map(x => x.Name).Not.Nullable().UniqueKey("EquipmentName");
		}
	}
}
