using System;
using MiniTask.Domain.Entity;

namespace MiniTask.Domain.Repository
{
	public interface ITaskRepository
	{
        Task<List<TaskEntity>> FindAll();
        Task<TaskEntity> Create(TaskEntity task);
    }
}

