using System;

namespace WebApp.ViewModels.OrderViewModels
{
    public class EditOrderViewModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public int Characters { get; set; }
        public int ExecutionTime { get; set; }
        public string Topic { get; set; }
        
        public Guid Executor { get; set; }
    }
}