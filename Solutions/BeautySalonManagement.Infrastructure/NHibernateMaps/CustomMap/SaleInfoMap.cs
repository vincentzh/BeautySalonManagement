using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.UserType;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class SaleInfoMap : IAutoMappingOverride<SaleInfo>
	{
		public void Override(AutoMapping<SaleInfo> mapping)
		{
			mapping.Map(x => x.Name).Not.Nullable();
			mapping.Map(x => x.Type).CustomType<ItemUserType>().Not.Nullable();
		}
	}
}
