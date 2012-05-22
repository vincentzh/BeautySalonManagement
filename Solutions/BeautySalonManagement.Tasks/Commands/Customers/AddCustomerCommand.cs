using System.ComponentModel.DataAnnotations;
using BeautySalonManagement.Tasks.Commands.People;

namespace BeautySalonManagement.Tasks.Commands.Customers
{
	public class AddCustomerCommand : PeopleCommandBase
	{
		[Required]
		public string CustomerCardNo { get; set; }
	}
}