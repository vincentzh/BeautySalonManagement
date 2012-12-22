using BeautySalonManagement.Domain.Businesses;
using FluentNHibernate.Automapping.Alterations;

namespace BeautySalonManagement.Infrastructure.NHibernateMaps.CustomMap
{
    public class ReservationMap : IAutoMappingOverride<Reservation>
    {
        #region IAutoMappingOverride<Reservation> Members

        public void Override(FluentNHibernate.Automapping.AutoMapping<Reservation> mapping)
        {
            mapping.References(x => x.Customer, "CustomerId");
            mapping.References(x => x.Special, "SpecialId");
            mapping.References(x => x.Service, "ServiceId");
        }

        #endregion
    }
}
