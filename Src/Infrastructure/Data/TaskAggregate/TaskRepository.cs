using Core.Domain.TaskAggregate;
using Core.Domain.TaskAggregate.Entities;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.TaskAggregate;
public class TaskRepository(DatabaseContext database) : ITaskRepository
{
    public async Task AddAsync(TaskEntity task)
    {
        await database.AddAsync(task);
    }
    public async Task UpdateAsync(TaskEntity task)
    {
        database.Update(task);
        await Task.CompletedTask;
    }

    public async Task<TaskEntity?> FindAsync(Guid id)
    {
        return await database.Set<TaskEntity>().FindAsync(id);
    }
}
