namespace API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using BusinessLayer.DTOs;
    using BusinessLayer.Interfaces;
    using DataLayer.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService<TodoItemSelectionListDTO, 
            TodoItemCreateUpdateDTO, TodoItemDTO, TodoItem> _todoItemService;

        public TodoItemsController(ITodoItemService<TodoItemSelectionListDTO, 
            TodoItemCreateUpdateDTO, TodoItemDTO, TodoItem> todoItemService)
        {
            _todoItemService = todoItemService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var todoItems = await _todoItemService.GetAllAsync();

            return Ok(todoItems);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(long id)
        {
            var todoItem = await _todoItemService.GetAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // GET: api/TodoItems/selection-list
        [HttpGet("selection-list")]
        public async Task<IActionResult> GetSelectionList()
        {
            var todoItems = await _todoItemService.GetSelectionListAsync();

            return Ok(todoItems);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task <IActionResult> PutTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            await _todoItemService.UpdateAsync(todoItemDTO, id);

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTodoItem(TodoItemCreateUpdateDTO todoItemDTO)
        {
            await _todoItemService.AddAsync(todoItemDTO);

            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _todoItemService.GetAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            await _todoItemService.DeleteAsync(id);

            return NoContent();
        }
    }
}
