using System.ComponentModel.DataAnnotations;

namespace BeautySalonManagement.Domain.Peoples
{
	public class Customer : Person
	{
		[Required]
		public virtual string CustomerCardNo { get; set; }
	}
}