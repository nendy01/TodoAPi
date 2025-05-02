using ApplicationLayer.Services.TaskServices;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _Service;

        public TaskController(TaskService service)
        {
            _Service = service;
        }
        [HttpGet]
        public async Task<ActionResult<Response<Tareas>>> GetTaskAllAsync()
        => await _Service.GetTaskAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Tareas>>> GetTaskByIdAsync(int id)
          => await _Service.GetTaskByIdAsync(id);
        [HttpPost]
        public async Task<ActionResult<Response<string>>> AddTaskAsync(Tareas tarea)
            => await _Service.AddTaskAsync(tarea);
        [HttpPut]
        public async Task<ActionResult<Response<string>>> UpdateTaskAsync(Tareas tarea)
            => await _Service.UpdateTaskAsync(tarea);
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<string>>> DeleteTaskAsync(int id)
            => await _Service.DeleteTaskAsync(id);


    }
}
