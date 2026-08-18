namespace TodoApi.Services;

using TodoApi.Models;

public class TodoService
{
    private List<TodoItem> _todoItems = new List<TodoItem>();
    private int _count = 0;

    public List<TodoItem> GetAll()
    {
        return _todoItems;
    }

    public TodoItem? GetById(int id)
    {
        return _todoItems.FirstOrDefault(item => item.Id == id);
    }

    public TodoItem Create(string title)
    {
        _count = _count + _todoItems.Count;
        var item = new TodoItem
        {
            Id = _count,
            Title = title,
            IsCompleted = false
        };
        _todoItems.Add(item);
        return item;
    }

    public TodoItem? Update(int id, string title)
    {
        var item = GetById(id);
        if (item == null) return null;

        item.Title = title;
        return item;
    }

    public TodoItem? MarkAsCompleted(int id)
    {
        var item = GetById(id);
        if (item == null) return null;
        item.IsCompleted = true;
        return item;
    }

    public bool Delete(int id)
    {
        var item = GetById(id);
        if (item == null) return false;
        _todoItems.Remove(item);
        return true;
    }
}