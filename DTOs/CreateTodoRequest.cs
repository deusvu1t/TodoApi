using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs;

public class CreateTodoRequest
{
    [StringLength(200, MinimumLength = 3)]
    public required string Title { get; set; }
}