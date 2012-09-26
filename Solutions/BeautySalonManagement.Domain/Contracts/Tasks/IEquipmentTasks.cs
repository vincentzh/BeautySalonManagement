using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Articles;
using CommonLib.Tasks;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IEquipmentTasks : ITask<Equipment>, IPaggingTask<Equipment>
	{

	}
}
