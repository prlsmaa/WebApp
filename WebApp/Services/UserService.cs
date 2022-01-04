using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using WebApp.Models;
using WebApp.ViewModels.UserViewModels;

namespace WebApp.Services
{
    public class UserService: IUserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.CurrentUsers.ToList();
        }

        public User GetById(GetByIdUserViewModel user)
        {
            return  _context.CurrentUsers.First(l => l.Id == user.Id);
        }

        public bool Create(CreateUserViewModel user)
        {
            try
            {
                var newUser = new User()
                    {Id = user.Id, Name = user.Name, Surname = user.Surname, UserName = user.UserName, CountCurrentOrders = 0};
                _context.CurrentUsers.Add(newUser);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(EditUserViewModel user)
        {
            try
            {
                var editUser = new User()
                    {Id = user.Id, Name = user.Name, Surname = user.Surname, UserName = user.UserName};
                var entity =  _context.CurrentUsers.First(l => l.Id == editUser.Id); 
                _context.CurrentUsers.Remove(entity);
                _context.CurrentUsers.Add(editUser);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(DeleteUser user)
        {
            try
            {
                var entity =  _context.CurrentUsers.First(l => l.Id == user.Id);
                _context.CurrentUsers.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }

    public interface IUserService
    {
        List<User> GetAll();
        User GetById(GetByIdUserViewModel user);
        bool Create(CreateUserViewModel user);
        bool Edit(EditUserViewModel user);
        bool Delete(DeleteUser user);
    }
}