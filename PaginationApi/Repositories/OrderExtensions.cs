using System.Linq.Expressions;
using PaginationApi.Models;

namespace PaginationApi.Repositories; 

public static class OrderExtensions {
	public static IQueryable<TSource> OrderBy<TSource,TKey>(this IQueryable<TSource> data, Order orderBy,  Expression<Func<TSource, TKey>> sortBy) {
		return orderBy switch {
			Order.Asc => data.OrderBy(sortBy),
			Order.Desc => data.OrderByDescending(sortBy),
			_ => throw new ArgumentOutOfRangeException(nameof(orderBy), orderBy, null)
		};
	}
}

