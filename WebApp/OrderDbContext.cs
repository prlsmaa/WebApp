using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
            //Database.EnsureDelete(); //для тестирования
            Database.EnsureCreated();
        }

        public DbSet<Order> CurrentOrders { get; set; }
    }
}