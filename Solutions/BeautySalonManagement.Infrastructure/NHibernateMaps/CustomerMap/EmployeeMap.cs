﻿#region

using BeautySalonManagement.Domain.Peoples;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

#endregion

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomerMap
{
	public class EmployeeMap : IAutoMappingOverride<Employee>
	{
		#region IAutoMappingOverride<Employee> Members

		public void Override(AutoMapping<Employee> mapping)
		{
			mapping.Table("tblEmployees");
		}

		#endregion
	}
}