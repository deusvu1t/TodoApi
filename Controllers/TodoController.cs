using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Models;
using TodoApi.Services;
namespace TodoApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;
    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll() => Ok(await _todoService.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetById(int id)
    {
        var item = await _todoService.GetById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> Create([FromBody] CreateTodoRequest request)
    {
        var newItem = await _todoService.Create(request.Title);
        return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TodoItem>> Update(int id, [FromBody] CreateTodoRequest request)
    {
        var item = await _todoService.Update(id, request.Title);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPatch("{id}/complete")]
    public async Task<ActionResult<TodoItem>> MarkAsComplete(int id)
    {
        var item = await _todoService.MarkAsComplete(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPatch("{id}/incomplete")]
    public async Task<ActionResult<TodoItem>> MarkAsIncomplete(int id)
    {
        var item = await _todoService.MarkAsIncomplete(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return await _todoService.Delete(id) ? NoContent() : NotFound();
    }
}