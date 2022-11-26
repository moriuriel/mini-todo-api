
using Microsoft.Extensions.Options;
using MiniTask.Domain.Database;
using MiniTask.Domain.Entity;
using MongoDB.Driver;

namespace MiniTask.Infrastructure.Repository
{
	public class TaskRepository
	{
		private readonly IMongoCollection<TaskEntity> _task;

		public TaskRepository(IOptions<TasksDatabaseSettings> options)
		{
			var mongoClient = new MongoClient(options.Value.ConnectionString);

			var db = mongoClient.GetDatabase(options.Value.DatabaseName);

			_task = db.GetCollection<TaskEntity>(options.Value.CollectionName);

		}

		public async Task<List<TaskEntity>> FindAll() => await _task.Find(_ => true).ToListAsync();
	}
}

