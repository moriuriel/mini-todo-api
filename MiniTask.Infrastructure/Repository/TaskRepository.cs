
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MiniTask.Domain.Database;
using MiniTask.Domain.Entity;
using MiniTask.Domain.Repository;
using MongoDB.Driver;

namespace MiniTask.Infrastructure.Repository
{
	public class TaskRepository : ITaskRepository
	{
		private readonly IMongoCollection<TaskEntity> _task;

		public TaskRepository(IOptions<TasksDatabaseSettings> options)
		{
			var mongoClient = new MongoClient(options.Value.ConnectionString);

			var db = mongoClient.GetDatabase(options.Value.DatabaseName);

			_task = db.GetCollection<TaskEntity>(options.Value.CollectionName);

		}

		public async Task<List<TaskEntity>> FindAll() => await _task.Find(_ => true).ToListAsync();

		public async Task<TaskEntity> FindByID(string id) => await _task.Find(t => t.Id == id).FirstOrDefaultAsync();

		public async Task<TaskEntity> Create(TaskEntity task)
		{
			await _task.InsertOneAsync(task);
			return task;
		}
    
	}
}

