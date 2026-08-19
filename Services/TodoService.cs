namespace TodoApi.Services;

using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

public class TodoService
{
    private TodoDbContext _todoDb;

    public TodoService(TodoDbContext todoDb) => _todoDb = todoDb;

    public async Task<IEnumerable<TodoItem>> GetAll()
    {
        return await _todoDb.TodoItems.ToListAsync();
    }

    public async Task<TodoItem?> GetById(int id)
    {
        return await _todoDb.TodoItems.FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<TodoItem> Create(string title)
    {
        var item = new TodoItem
        {
            Title = title,
            IsComplete = false
        };
        _todoDb.TodoItems.Add(item);
        await _todoDb.SaveChangesAsync();
        return item;
    }

    public async Task<TodoItem?> Update(int id, string title)
    {
        var item = await GetById(id);
        if (item == null) return null;

        item.Title = title;
        await _todoDb.SaveChangesAsync();
        return item;
    }

    public async Task<TodoItem?> MarkAsComplete(int id)
    {
        var item = await GetById(id);
        if (item == null) return null;
        item.IsComplete = true;
        await _todoDb.SaveChangesAsync();
        return item;
    }

    public async Task<TodoItem?> MarkAsIncomplete(int id)
    {
        var item = await GetById(id);
        if (item == null) return null;
        item.IsComplete = false;
        await _todoDb.SaveChangesAsync();
        return item;
    }

    public async Task<bool> Delete(int id)
    {
        var item = await GetById(id);
        if (item == null) return false;
        _todoDb.TodoItems.Remove(item);
        await _todoDb.SaveChangesAsync();
        return true;
    }
}