using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table ("CurrentUsers")]
    public class Executor
    {
        [Key] 
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public int CountCurrentOrders { get; set; }
        public int CountCompletedOrders { get; set; }
        public int Rating { get; set; }
        //public List<Guid> Orders { get; set; }
    }
}