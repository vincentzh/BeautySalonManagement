using System.Collections.Generic;
using CommonLib.ControlsExtension;
using CommonLib.QueryOver;
using NHibernate;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate;

namespace CommonLib.Tasks
{
	public class NHibernateQueryTaskBase<T> : NHibernateQuery, ITask<T>, IPaggingTask<T> where T : Entity
	{
		#region IPaggingTask<T> Members

		public virtual IEnumerable<T> FindAll(int startRow, int pageSize, MvcContributeGridSort sort)
		{
			return Session.QueryOver<T>().OrderBy(sort).Skip(startRow).Take(pageSize).Future<T>();
		}

		public virtual IFutureValue<int> CountAll()
		{
			return Session.QueryOver<T>().Count().FutureValue<int>();
		}

		#endregion

		#region ITask<T> Members

		public virtual T Get(int id)
		{
			return Session.Get<T>(id);
		}

		public IEnumerable<T> FindByAll()
		{
			return Session.QueryOver<T>().Future<T>();
		}

		#endregion
	}
}