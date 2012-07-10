using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Domain.Items;
using CommonLib.Tasks;

namespace BeautySalonManagement.Tasks
{
	public class BrandTasks : NHibernateQueryTaskBase<Brand>, IBrandTasks
	{
	}
}
