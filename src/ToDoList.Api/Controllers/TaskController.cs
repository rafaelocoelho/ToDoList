using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Utilities;
using ToDoList.Core;

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

        [HttpGet("Id")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetByIdAsync(Guid Id)
        {
            try
            {
                var task = await _taskService.GetTaskById(Id);
                if (task is null)
                    return Ok(new ResultViewModel("Nenhuma tarefa foi encontrada!", false, null));
                return Ok(new ResultViewModel("Tarefa encontrada com sucesso!", true, task));
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErroMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(null));
            }
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Search([FromBody] FilterTaskViewModel model)
        {
            if (ModelState.IsValid is false)
            {
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));
            }

            try
            {
                var tasks = await _taskService.GetAllTasksByFilter(new Core.DTOs.TaskFilterParamsDTO(DueDate: model.dueDate, Status: model.taskStatus));
                if (tasks is null)
                    return Ok(new ResultViewModel("Nenhuma tarefa foi encontrada!", false, null));
                return Ok(new ResultViewModel("Tarefa(s) encontrada(s) com sucesso!", true, tasks));
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErroMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(null));
            }

        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var tasks = await _taskService.GetAllTasks();
                if (tasks is null)
                    return Ok(new ResultViewModel("Nenhuma tarefa foi encontrada!", false, null));
                return Ok(new ResultViewModel("Tarefa(s) encontrada(s) com sucesso!", true, tasks));
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErroMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(null));
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] CreateTaskViewModel model)
        {
            if(ModelState.IsValid is false)
            {
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));
            }

            try
            {
                var task = _taskService.Create(new TaskDTO(
                Id: null,
                Title: model.Title,
                Description: model.Description,
                CreatedAt: null,
                DueDate: model.DueDate,
                Status: null));

                return Ok(Responses.SuccessMessage("Tarefa criada com sucesso!", task));

            } catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErroMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(null));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status400BadRequest)]
        public ActionResult Put(Guid id, [FromBody] UpdateTaskViewModel model)
        {
            if (ModelState.IsValid is false)
            {
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));
            }

            try
            {
                var task = _taskService.Update(new TaskDTO(
                Id: id,
                Title: model?.Title,
                Description: model?.Description,
                CreatedAt: null,
                DueDate: model?.DueDate,
                Status: model?.Status));

                return Ok(Responses.SuccessMessage("Tarefa atualizada com sucesso!", task));

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErroMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(null));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status400BadRequest)]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _taskService.Remove(id);
                return Ok(Responses.SuccessMessage("Tarefa removida com sucesso!"));
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErroMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(null));
            }
        }        
    }
}
