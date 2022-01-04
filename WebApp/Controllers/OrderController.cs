using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;
using WebApp.ViewModels.OrderViewModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listOrders = _orderService.GetAll();
            return Ok(listOrders);
        }

        [HttpGet]
        public IActionResult GetById(GetByIdOrderViewModel order)
        {
            if (order.Id == Guid.Empty) return BadRequest();
            var newOrder = _orderService.GetById(order);
            return Ok(newOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderViewModel order)
        {
            var isSuccess = _orderService.Create(order);
            return Ok(isSuccess);
        }

        [HttpPut]
        public IActionResult Edit(EditOrderViewModel order)
        {
            var isSuccess = _orderService.Edit(order);
            return Ok(isSuccess);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteOrderViewModel order)
        {
            var isSuccess = _orderService.Delete(order);
            return Ok(isSuccess);
        }
    }
}