namespace BeautySalonManagement.Infrastructure.NHibernateMaps.Conventions
{
    #region Using Directives

    using FluentNHibernate.Conventions;

    #endregion

    public class HasManyConvention : IHasManyConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IOneToManyCollectionInstance instance)
        {
			instance.Key.Column(instance.EntityType.Name + "Id");
			instance.Key.ForeignKey(instance.EntityType.Name+"_"+instance.ChildType.Name+"_FK");
            instance.Cascade.AllDeleteOrphan();
            instance.Inverse();
        }
    }
}