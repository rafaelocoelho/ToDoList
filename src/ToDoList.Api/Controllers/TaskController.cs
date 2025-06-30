using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.ViewModels;
using ToDoList.Core;
using ToDoList.Core.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]   
        public async Task<ActionResult> GetAllAsync()
        {
            var tasks = await _taskService.GetAllTasks();

            if (tasks is null)
                return Ok(new ResultViewModel("Nenhuma tarefa foi encontrada!", false, null));

            return Ok(new ResultViewModel ("Tarefa encontrado com sucesso!", true, tasks));

        }

        [HttpGet]
        public async Task<IEnumerable<TaskDTO>> GetAllByDueDate([FromQuery] DateOnly dueDate)
        {
            return await _taskService.GetAllTasksByDueDate(dueDate);
        }

        [HttpGet]
        public async Task<IEnumerable<TaskDTO>> GetAllByStatus([FromQuery] Domain.Enums.TaskStatus status)
        {
            return await _taskService.GetAllTasksByStatusAsync(status);
        }

        [HttpPost]
        [ProducesResponseType(typeof(), StatusCodes.Status200OK)]
        public ActionResult Post([FromBody] TaskDTO entity)
        {
            if (entity is null)
            {
                return BadRequest("Task cannot be null.");
            }

            var task = _taskService.Create(entity);
            if (task is not null)
            {
                return CreatedAtAction(nameof(GetAllAsync), new { id = task.Id }, task);
            }

            return BadRequest("Failed to create task.");
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] TaskDTO entity)
        {
            if (entity is null)
            {
                return BadRequest("Task cannot be null.");
            }
            var task = _taskService.Update(entity);
            if (task is not null)
            {
                return Ok(task);
            }

            return NotFound($"Task with ID {id} not found.");
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Task cannot be null.");
            }
            try
            {
                _taskService.Remove(id);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new InvalidOperationException($"Failed to delete task with ID {id}.", ex);
            }
        }


    }
}
