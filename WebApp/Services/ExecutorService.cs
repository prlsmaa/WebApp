using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.ViewModels.ExecutorViewModels;

namespace WebApp.Services
{
    public class ExecutorService: IExecutorService
    {
        private readonly ExecutorDbContext _context;

        public ExecutorService(ExecutorDbContext context)
        {
            _context = context;
        }

        public List<Executor> GetAll()
        {
            return _context.CurrentExecutors.ToList();
        }

        public Executor GetById(GetByIdExecutorViewModel executor)
        {
            return  _context.CurrentExecutors.First(l => l.Id == executor.Id);
        }

        public bool Create(CreateExecutorViewModel executor)
        {
            try
            {
                var newExecutor = new Executor()
                {
                    Id = executor.Id, Name = executor.Name, Surname = executor.Surname, UserName = executor.UserName,
                    CountCompletedOrders = 0, CountCurrentOrders = 0
                };
                _context.CurrentExecutors.Add(newExecutor);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(EditExecutorViewModel executor)
        {
            try
            {
                var editExecutor = new Executor()
                {
                    Id = executor.Id, Name = executor.Name, Surname = executor.Surname, UserName = executor.UserName
                };
                var entity =  _context.CurrentExecutors.First(l => l.Id == executor.Id); 
                _context.CurrentExecutors.Remove(entity);
                _context.CurrentExecutors.Add(editExecutor);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(DeleteExecutorViewModel executor)
        {
            try
            {
                var entity =  _context.CurrentExecutors.First(l => l.Id == executor.Id);
                _context.CurrentExecutors.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public interface IExecutorService
    {
        List<Executor> GetAll();
        Executor GetById(GetByIdExecutorViewModel executor);
        bool Create(CreateExecutorViewModel executor);
        bool Edit(EditExecutorViewModel executor);
        bool Delete(DeleteExecutorViewModel executor);
    }
}