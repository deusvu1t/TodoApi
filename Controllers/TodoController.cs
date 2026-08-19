using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Extensions;
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
    public async Task<ActionResult<IEnumerable<TodoResponse>>> GetAll() => Ok((await _todoService.GetAll()).Select(item => item.ToResponse()));

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoResponse>> GetById(int id)
    {
        var item = await _todoService.GetById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.ToResponse());
    }

    [HttpPost]
    public async Task<ActionResult<TodoResponse>> Create([FromBody] CreateTodoRequest request)
    {
        var newItem = await _todoService.Create(request.Title);
        return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem.ToResponse());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TodoResponse>> Update(int id, [FromBody] UpdateTodoRequest request)
    {
        var item = await _todoService.Update(id, request.Title);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.ToResponse());
    }

    [HttpPatch("{id}/complete")]
    public async Task<ActionResult<TodoResponse>> MarkAsComplete(int id)
    {
        var item = await _todoService.MarkAsComplete(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.ToResponse());
    }

    [HttpPatch("{id}/incomplete")]
    public async Task<ActionResult<TodoResponse>> MarkAsIncomplete(int id)
    {
        var item = await _todoService.MarkAsIncomplete(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.ToResponse());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return await _todoService.Delete(id) ? NoContent() : NotFound();
    }
}