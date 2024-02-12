using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext applicationDbContext) 
        {
            context = applicationDbContext;
        }
        public Task<User> GetUser()
        {
            return context.Users.OrderByDescending(user => user.Orders.Count).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return context.Users.Where(user => user.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
