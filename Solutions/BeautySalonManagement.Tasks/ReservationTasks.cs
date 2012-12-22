using BeautySalonManagement.Domain.Businesses;
using BeautySalonManagement.Domain.Contracts.Tasks;
using CommonLib.Tasks;

namespace BeautySalonManagement.Tasks
{
    public class ReservationTasks : NHibernateQueryTaskBase<Reservation>, IReservationTasks
    {
    }
}