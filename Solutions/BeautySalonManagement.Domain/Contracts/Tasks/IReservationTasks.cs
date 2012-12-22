using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Businesses;
using CommonLib.Tasks;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
    public interface IReservationTasks:IPaggingTask<Reservation>,ITask<Reservation>
    {
    }
}
