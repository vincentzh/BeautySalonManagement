using BeautySalonManagement.Tasks.Commands.People;

namespace BeautySalonManagement.Tasks.Commands.Employees
{
	public class EmployeeCommandBase : PeopleCommandBase
	{
		public string ContactInfoName { get; set; }
		public string ContactInfoPhone { get; set; }
	}
}