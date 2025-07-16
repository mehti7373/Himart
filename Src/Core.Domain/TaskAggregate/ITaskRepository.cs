using Core.Domain.TaskAggregate.Entities;

namespace Core.Domain.TaskAggregate;
public interface ITaskRepository
{
    Task AddAsync(TaskEntity task);
    Task<TaskEntity?> FindAsync(Guid id);
    Task UpdateAsync(TaskEntity task);
}
