using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.Contracts.Tasks;
using CommonLib.Tasks;

namespace BeautySalonManagement.Tasks
{
	public class EquimentTasks:NHibernateQueryTaskBase<Equipment>,IEquipmentTasks
	{

	}
}
