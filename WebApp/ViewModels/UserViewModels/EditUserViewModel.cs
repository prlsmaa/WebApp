using System;

namespace WebApp.ViewModels.UserViewModels
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}