using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entities;
using WebApi.Data.Repositories;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TODOController : ControllerBase
    {
        private readonly ITODORepository _todoRepository;

        public TODOController(ITODORepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ToDoModel model)
        {
            var todo = await _todoRepository.GetByIdAsync(id);

            if(todo == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            todo.Title = model.Title;
            todo.Description = model.Description;
            todo.StatusId = model.Status;
            todo.PriorityId = model.Priority;

            await _todoRepository.UpdateAsync(todo);

            return Ok(todo);
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ToDoModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = new TODO
            {
                Title = model.Title,
                Description = model.Description,
                StatusId = model.Status,
                PriorityId = model.Priority
            };

            await _todoRepository.AddAsync(todo);

            return Ok(todo);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTODO(int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            await _todoRepository.DeleteAsync(todo);

            return Ok();
        }

        [Route("todos")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _todoRepository.GetAllAsync();

            return Ok(result);
        }

        [Route("todo")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _todoRepository.GetByIdAsync(id);

            if(result == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
