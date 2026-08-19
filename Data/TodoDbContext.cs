namespace TodoApi.Data;

using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }
}