using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautySalonManagement.Web.Mvc.Controllers.ViewModels
{
    public class ReservationViewModel
    {
        public DateTime Appointment { get; set; }
        public int  CustomerId { get; set; }
        public int  ServiceId { get; set; }
        public int  SpecialId { get; set; }

    }
}