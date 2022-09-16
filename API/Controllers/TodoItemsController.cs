using Microsoft.AspNetCore.Mvc;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public IActionResult GetTodoItems()
        {
            var todoItems = _todoItemService.GetAll();
            return Ok(todoItems);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public IActionResult GetTodoItem(long id)
        {
            var todoItem = _todoItemService.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            _todoItemService.Update(todoItemDTO, id);
            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTodoItem(TodoItemDTO todoItemDTO)
        {
            _todoItemService.Add(todoItemDTO);

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItemDTO.Id },
                todoItemDTO);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(long id)
        {
            var todoItem = _todoItemService.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _todoItemService.Delete(id);
            return NoContent();
        }
    }
}
