using System.Collections.Generic;
using BeautySalonManagement.Domain.Peoples;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	internal interface IPersonTask
	{
		ICollection<People> GetAll();
		People Get(int Id);
	}
}