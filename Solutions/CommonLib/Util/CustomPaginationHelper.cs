#region

using CommonLib.ControlsExtension;
using CommonLib.Tasks;
using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;

#endregion

namespace CommonLib.Util
{
	public class CustomPaginationHelper<T> where T : class
	{
		readonly IPaggingTask<T> _paggingTask;

		public CustomPaginationHelper(IPaggingTask<T> task)
		{
			_paggingTask = task;
		}

		public CustomPagination<T> Pagination(int pageSize, int? pageIndex, GridSortOptions sort)
		{
			var index = (pageIndex ?? 1);
			var startRow = pageSize*(index - 1);
			var customers = _paggingTask.FindAll(startRow, pageSize,
			                                     new MvcContributeGridSort
			                                     	{
			                                     			Column = sort.Column,
			                                     			Direction =
			                                     					(sort.Direction == SortDirection.Ascending
			                                     					 		? Direction.ASC
			                                     					 		: Direction.DESC)
			                                     	});
			var count = _paggingTask.CountAll();
			return new CustomPagination<T>(customers, index, pageSize, count.Value);
		}
	}
}