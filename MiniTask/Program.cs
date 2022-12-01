using MiniTask.Domain.Database;
using MiniTask.Domain.Entity;
using MiniTask.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TasksDatabaseSettings>(builder.Configuration.GetSection("MongoDBDatabaseSettings"));

builder.Services.AddSingleton<TaskRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/tasks", async (TaskRepository repo) => await repo.FindAll());
app.MapPost("/v1/tasks", async (TaskRepository repo, TaskEntity task) =>
{
    var newTask = await repo.Create(task);

    return Results.Created("/v1/tasks", newTask);
});

app.Run();

