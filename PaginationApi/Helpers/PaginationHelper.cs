using Microsoft.AspNetCore.WebUtilities;
using PaginationApi.Models;

namespace PaginationApi.Helpers; 

public static class PaginationHelper {
	public static PagedResponse<IEnumerable<T>> ToPagedResponse<T>(this IEnumerable<T> items, int pageNumber, int pageSize, int totalRecords) {
		int totalPages = Convert.ToInt32(Math.Ceiling((double) totalRecords / pageSize));
		
		return new PagedResponse<IEnumerable<T>>(
			items, 
			pageNumber, 
			pageSize, 
			GetPageUri("http://localhost:5233/users", 1, pageSize), 
			GetPageUri("http://localhost:5233/users", totalPages, pageSize)) {
			TotalRecords = totalRecords,
			TotalPages = totalPages,
			NextPage = pageNumber < totalPages ? GetPageUri("http://localhost:5233/users", pageNumber + 1, pageSize) : null,
			PreviousPage = pageNumber > 1 ? GetPageUri("http://localhost:5233/users", pageNumber - 1, pageSize) : null
		};
	}
	
	private static Uri GetPageUri(string route, int pageNumber, int pageSize)
	{
		Uri endpointUri = new (route);
		string modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "pageNumber", pageNumber.ToString());
		modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pageSize.ToString());
		return new Uri(modifiedUri);
	}
}