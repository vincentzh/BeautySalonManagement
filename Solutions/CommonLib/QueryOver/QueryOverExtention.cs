using MvcContrib.Sorting;
using MvcContrib.UI.Grid;
using NHibernate;
using NHibernate.Criterion.Lambda;

namespace CommonLib.QueryOver
{
	public static class QueryOverExtention
	{
		public static IQueryOver<TRoot, TSubType> OrderBy<TRoot, TSubType>(this IQueryOver<TRoot, TSubType> queryOver,
		                                                                   GridSortOptions sort)
		{
			if (sort == null)
				return queryOver;
			if (!string.IsNullOrWhiteSpace(sort.Column))
			{
				IQueryOverOrderBuilder<TRoot, TSubType> queryOrder = queryOver.OrderBy(() => sort.Column);
				if (sort.Direction == SortDirection.Ascending)
					return queryOrder.Asc;
				return queryOrder.Desc;
			}
			return queryOver;
		}
		public static IQueryOver<TRoot, TRoot> Count<TRoot>(this IQueryOver<TRoot> queryOver)
		{
			return queryOver.ToRowCountQuery();
		}
	}
}