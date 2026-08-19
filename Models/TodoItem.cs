namespace TodoApi.Models;

public class TodoItem
{
    public int Id { get; init; }
    public string Title { get; set; } = "";
    public bool IsComplete { get; set; }
}
