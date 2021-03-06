﻿using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Domain.UserType;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
	public class PeopleMap : IAutoMappingOverride<People>
	{
		#region IAutoMappingOverride<People> Members

		public void Override(AutoMapping<People> mapping)
		{
			mapping.Map(x => x.Name).Not.Nullable();
			mapping.Map(x => x.Password).Access.LowerCaseField(Prefix.Underscore).Not.Nullable();
			mapping.Map(x => x.Salt).Not.Nullable();
			mapping.Map(x => x.Gender).CustomType<GenderUserType>().Not.Nullable();
			mapping.Map(x => x.MobilePhone).Not.Nullable();
		}

		#endregion
	}
}