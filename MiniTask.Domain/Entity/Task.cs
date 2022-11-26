using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MiniTask.Domain.Entity
{
	public class TaskEntity
    {
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Completed { get; set; }
	}
}

