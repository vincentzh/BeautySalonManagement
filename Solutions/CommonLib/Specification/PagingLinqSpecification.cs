using System.Linq;
using SharpArch.Domain.Specifications;

namespace CommonLib.Specification
{
	public class PagingLinqSpecification<T> : ILinqSpecification<T> where T : class
	{
		public PagingLinqSpecification(int startRow, int pageSize)
		{
			StartRow = startRow;
			PageSize = pageSize;
		}

		public int PageSize { get; protected set; }

		public int StartRow { get; protected set; }

		#region ILinqSpecification<T> Members

		public IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
		{
			return candidates.Skip(StartRow).Take(PageSize);
		}

		#endregion
	}
}