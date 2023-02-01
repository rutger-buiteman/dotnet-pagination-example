using System.ComponentModel.DataAnnotations;

namespace PaginationApi.Models; 

public class PaginationFilter {
	public int PageNumber { get; set; } = 1;
	[Range(1, 100, ErrorMessage = "Page size must be between 1 and 100")]
	public int PageSize { get; set; } = 10;
}