﻿namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
    #region Using Directives

    using FluentNHibernate.Conventions;

    using inflector_extension;
    #endregion

    public class TableNameConvention : IClassConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {
            instance.Table("tbl"+instance.EntityType.Name.InflectTo().Pluralized);
        }
    }
}