using System.Collections.Generic;
using BeautySalonManagement.Domain.Peoples;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	internal interface IPersonTask
	{
		ICollection<Person> GetAll();
		Person Get(int Id);
	}
}