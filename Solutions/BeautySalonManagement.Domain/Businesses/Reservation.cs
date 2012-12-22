using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.Peoples;
using SharpArch.Domain.DomainModel;

namespace BeautySalonManagement.Domain.Businesses
{
	public class Reservation:Entity
	{
		public virtual DateTime Appointment   { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual Service Service { get; set; }
		public virtual Employee Special { get; set; }
	}
}
