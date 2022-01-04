using System;

namespace WebApp.ViewModels.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public Guid Customer { get; set; }//
    }
}