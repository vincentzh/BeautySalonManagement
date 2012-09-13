using BeautySalonManagement.Domain.Articles;
using BeautySalonManagement.Domain.Contracts.Tasks;
using CommonLib.QueryOver;
using CommonLib.Tasks;

namespace BeautySalonManagement.Tasks
{
	public class ItemTasks : NHibernateQueryTaskBase<Item>, IItemTasks
	{
		public override System.Collections.Generic.IEnumerable<Item> FindAll(int startRow, int pageSize, CommonLib.ControlsExtension.MvcContributeGridSort sort)
		{
			Brand brandAlias = null;
			return Session.QueryOver<Item>().JoinAlias(x=>x.Brand,()=>brandAlias).OrderBy(sort).Skip(startRow).Take(pageSize).Future<Item>();
		}
	}
}