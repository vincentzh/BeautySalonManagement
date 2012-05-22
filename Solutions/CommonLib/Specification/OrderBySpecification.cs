using System.Linq;
using CommonLib.ControlsExtension;
using SharpArch.Domain.Specifications;

namespace CommonLib.Specification
{
	public class OrderBySpecification<T> : ILinqSpecification<T> where T : class

	{
		readonly MvcContributeGridSort sortOptions;

		public OrderBySpecification(MvcContributeGridSort sort)
		{
			sortOptions = sort;
		}

		#region ILinqSpecification<T> Members

		public IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
		{
			if (sortOptions.Direction == Direction.ASC)
				return candidates.OrderBy(T => typeof (T).GetProperty(sortOptions.Column)).AsQueryable();
			return candidates.OrderByDescending(T => typeof (T).GetProperty(sortOptions.Column)).AsQueryable();
		}

		#endregion
	}
}