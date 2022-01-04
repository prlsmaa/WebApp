using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("CurrentOrders")]
    public class Order
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Characters { get; set; }
        public int ExecutionTime { get; set; }//Time
        public string Topic { get; set; }
        public bool Status { get; set; }
        public Guid Customer { get; set; }
        public Guid Executor { get; set; }
    }
}