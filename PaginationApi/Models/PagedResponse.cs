namespace PaginationApi.Models; 

public class PagedResponse<T> {
	public T Data { get; set; }
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public int TotalPages { get; set; }
	public int TotalRecords { get; set; }
	public Uri FirstPage { get; set; }
	public Uri? PreviousPage { get; set; }
	public Uri? NextPage { get; set; }
	public Uri LastPage { get; set; }
	
	public PagedResponse(T data, int pageNumber , int pageSize, Uri firstPage, Uri lastPage)
	{
		PageNumber = pageNumber;
		PageSize = pageSize;
		FirstPage = firstPage;
		LastPage = lastPage;
		Data = data;
	}
}