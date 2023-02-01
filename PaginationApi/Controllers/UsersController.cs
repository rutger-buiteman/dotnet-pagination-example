using Microsoft.AspNetCore.Mvc;
using PaginationApi.Entities;
using PaginationApi.Helpers;
using PaginationApi.Models;
using PaginationApi.Repositories;

namespace PaginationApi.Controllers; 

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase {
	private readonly IUsersRepository _usersRepository;

	public UsersController(IUsersRepository usersRepository) {
		_usersRepository = usersRepository;
	}
	
	[HttpGet]
	public async Task<IActionResult> GetUsers([FromQuery] PaginationFilter filter, [FromQuery] OrderingFilter orderingFilter) {
		IEnumerable<User> users = await _usersRepository.GetUsers(filter.PageNumber, filter.PageSize, orderingFilter.OrderBy, orderingFilter.SortBy);
		int totalRecords = await _usersRepository.GetUsersCount();
		
		return Ok(users.ToPagedResponse(filter.PageNumber, filter.PageSize, totalRecords));
	}
}