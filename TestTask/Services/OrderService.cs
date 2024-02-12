using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        public Task<Order> GetOrder()
        {
            return context.Orders.OrderByDescending(order => order.Price).FirstOrDefaultAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return context.Orders.Where(order => order.Quantity > 10).ToListAsync();
        }
    }
}
