
using BeautySalonManagement.Domain.Interfaces;

namespace BeautySalonManagement.Domain.Peoples
{
	public class Employee : People
	{
		public virtual ContactInfo ContactInfo { get; set; }
	}
}