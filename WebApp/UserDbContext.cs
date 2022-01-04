using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            //Database.EnsureDeleted(); //для тестирования
            Database.EnsureCreated();
        }

        public DbSet<User> CurrentUsers { get; set; }
    }
}