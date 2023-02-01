using PaginationApi.Entities;
using PaginationApi.Models;

namespace PaginationApi.Repositories; 

public interface IUsersRepository {
	public Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize, Order orderBy, string sortBy);
	Task<int> GetUsersCount();
}