using Microsoft.EntityFrameworkCore;
using PaginationApi.Entities;
using PaginationApi.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddControllers();
WebApplication app = builder.Build();

app.MapControllers();
app.Run();