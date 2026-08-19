using TodoApi.DTOs;
using TodoApi.Models;
namespace TodoApi.Extensions;

public static class TodoItemExtensions
{
    public static TodoResponse ToResponse(this TodoItem item)
    {
        return new TodoResponse
        {
            Id = item.Id,
            Title = item.Title,
            IsComplete = item.IsComplete
        };
    }
}
