using System;
using System.Collections.Generic;
using System.Linq;
using WebApp;
using WebApp.Models;
using WebApp.ViewModels.OrderViewModels;

namespace WebApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;

        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.CurrentOrders.ToList();
        }

        public Order GetById(GetByIdOrderViewModel order)
        {
            return _context.CurrentOrders.First(l => l.Id == order.Id);
        }

        public bool Create(CreateOrderViewModel order)
        {
            try
            {
                var newOrder = new Order() {Name = order.Name, Customer = order.Customer};
                _context.CurrentOrders.Add(newOrder);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(EditOrderViewModel order)
        {
            try
            {
                var newOrder = new Order()
                {
                    Id = order.Id, Name = order.Name, Characters = order.Characters, Topic = order.Topic,
                    ExecutionTime = order.ExecutionTime, Executor = order.Executor
                };
                var entity = _context.CurrentOrders.First(l => l.Id == newOrder.Id);
                _context.CurrentOrders.Remove(entity);
                _context.CurrentOrders.Add(newOrder);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Complete(CompleteOrderViewModel order)
        {
            try
            {       
                var currentOrder=_context.CurrentOrders.First(l => l.Id == order.Id);
                currentOrder.Status = true;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(DeleteOrderViewModel order)
        {
            try
            {
                var entity = _context.CurrentOrders.First(l => l.Id == order.Id);
                _context.CurrentOrders.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(GetByIdOrderViewModel order);
        bool Create(CreateOrderViewModel order);
        bool Edit(EditOrderViewModel order);
        bool Delete(DeleteOrderViewModel order);
        
    }
}