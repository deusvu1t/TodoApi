using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;
using TodoApi.Models;
using TodoApi.DTOs;
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
    public ActionResult<IEnumerable<TodoItem>> GetAll() => Ok(_todoService.GetAll());

    [HttpGet("{id}")]
    public ActionResult<TodoItem> GetById(int id)
    {
        var item = _todoService.GetById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public ActionResult<TodoItem> Create([FromBody] CreateTodoRequest request)
    {
        var newItem = _todoService.Create(request.Title);
        return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
    }

    [HttpPut("{id}")]
    public ActionResult<TodoItem> Update(int id, [FromBody] CreateTodoRequest request)
    {
        var item = _todoService.Update(id, request.Title);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPatch("{id}/complete")]
    public ActionResult<TodoItem> MarkAsComplete(int id)
    {
        var item = _todoService.MarkAsComplete(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPatch("{id}/incomplete")]
    public ActionResult<TodoItem> MarkAsIncomplete(int id)
    {
        var item = _todoService.MarkAsIncomplete(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => _todoService.Delete(id) ? NoContent() : NotFound();
}