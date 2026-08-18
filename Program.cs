using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

app.MapControllers();

app.Run();