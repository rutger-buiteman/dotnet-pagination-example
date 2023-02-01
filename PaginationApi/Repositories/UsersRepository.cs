using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaginationApi.Entities;
using PaginationApi.Models;

namespace PaginationApi.Repositories; 

public class UsersRepository: IUsersRepository {
	private readonly AppDbContext _context;

	public UsersRepository(AppDbContext context) {
		_context = context;
	}
	
	public async Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize, Order orderBy, string sortBy) {
		
		return await _context.Users
		                     .OrderBy(orderBy, user => user.LastName)
		                     .Skip((pageNumber - 1) * pageSize)
		                     .Take(pageSize)
		                     .ToListAsync();
	}
	
	public async Task<int> GetUsersCount() {
		return await _context.Users.CountAsync();
	}
}