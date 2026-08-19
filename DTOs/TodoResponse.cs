namespace TodoApi.DTOs;


public class TodoResponse
{
    public int Id { get; init; }
    public string Title { get; set; } = "";
    public bool IsComplete { get; set; }
}
