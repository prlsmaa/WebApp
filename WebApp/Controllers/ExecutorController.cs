using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels.ExecutorViewModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExecutorController : ControllerBase
    {
        private readonly IExecutorService _executorService;

        public ExecutorController(IExecutorService executorService)
        {
            _executorService = executorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listExecutors = _executorService.GetAll();
            return Ok(listExecutors);
        }

        [HttpGet]
        public IActionResult GetById(GetByIdExecutorViewModel executor)
        {
            if (executor.Id == Guid.Empty) return BadRequest();
            var getByIdExecutor = _executorService.GetById(executor);
            return Ok(getByIdExecutor);
        }

        [HttpPost]
        public IActionResult Create(CreateExecutorViewModel executor)
        {
            var isSuccess = _executorService.Create(executor);
            return Ok(isSuccess);
        }

        [HttpPut]
        public IActionResult Edit(EditExecutorViewModel executor)
        {
            var isSuccess = _executorService.Edit(executor);
            return Ok(isSuccess);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteExecutorViewModel executor)
        {
            var isSuccess = _executorService.Delete(executor);
            return Ok(isSuccess);
        }
    }
}