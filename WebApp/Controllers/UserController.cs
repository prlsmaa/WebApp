using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;
using WebApp.ViewModels.UserViewModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var listUsers = _userService.GetAll();
            return Ok(listUsers);
        }

        [HttpGet]
        public IActionResult GetById(GetByIdUserViewModel user)
        {
            if (user.Id == Guid.Empty) return BadRequest();
            var _user = _userService.GetById(user);
            return Ok(_user);
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel user)
        {
            var isSuccess = _userService.Create(user);
            return Ok(isSuccess);
        }

        [HttpPut]
        public IActionResult Edit(EditUserViewModel user)
        {
            var isSuccess = _userService.Edit(user);
            return Ok(isSuccess);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteUser user)
        {
            var isSuccess = _userService.Delete(user);
            return Ok(isSuccess);
        }
    }
}