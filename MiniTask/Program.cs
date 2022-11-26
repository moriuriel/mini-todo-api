using MiniTask.Domain.Database;
using MiniTask.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TasksDatabaseSettings>(builder.Configuration.GetSection("MongoDBDatabaseSettings"));

builder.Services.AddSingleton<TaskRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/tasks", async (TaskRepository repo) => await repo.FindAll());

app.Run();

