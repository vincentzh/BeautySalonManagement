using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Articles;
using CommonLib.Tasks;

namespace BeautySalonManagement.Domain.Contracts.Tasks
{
	public interface IServiceTasks:IPaggingTask<Service>,ITask<Service>
	{

	}
}
