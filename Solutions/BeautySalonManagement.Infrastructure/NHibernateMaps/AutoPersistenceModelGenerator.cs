#region

using System;
using BeautySalonManagement.Domain.Peoples;
using BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.FluentNHibernate;

#endregion

namespace BeautySalonManagement.Infrastructure.NHibernateMaps
{
	/// <summary>
	///     Generates the automapping for the domain assembly
	/// </summary>
	public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
	{
		#region IAutoPersistenceModelGenerator Members

		public AutoPersistenceModel Generate()
		{
			AutoPersistenceModel mappings = AutoMap.AssemblyOf<Employee>(new AutomappingConfiguration());
			mappings.IgnoreBase<Entity>();
			mappings.IgnoreBase(typeof (EntityWithTypedId<>));

			mappings.Conventions.Setup(GetConventions());
			mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
			mappings.WriteMappingsTo(@"d:\mappings");
			return mappings;
		}

		#endregion

		static Action<IConventionFinder> GetConventions()
		{
			return c =>
			{
				c.Add<IdGenerationConvention>();
				c.Add<PrimaryKeyConvention>();
				c.Add<CustomForeignKeyConvention>();
				c.Add<HasManyConvention>();
				c.Add<TableNameConvention>();
				c.Add<CustomManyToManyTableNameConvention>();
				c.Add<ForeignKeyNameConvention>();
				c.Add<ReferenceConvention>();
			};
		}
	}
}