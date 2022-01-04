using System;

namespace WebApp.ViewModels.ExecutorViewModels
{
    public class CreateExecutorViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}