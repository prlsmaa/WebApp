using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    public class ExecutorDbContext: DbContext
    {
        public ExecutorDbContext(DbContextOptions<ExecutorDbContext> options) : base(options)
        {
            //Database.EnsureDeleted(); //для тестирования
            Database.EnsureCreated();
        }

        public DbSet<Executor> CurrentExecutors { get; set; }
    }
}