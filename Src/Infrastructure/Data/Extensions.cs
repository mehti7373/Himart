using Core.Domain.TaskAggregate;
using Framework.Ef;
using Infrastructure.Data.Context;
using Infrastructure.Data.TaskAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;
public static class Extensions
{
    public static void AddEntityFramework(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<DatabaseContext>>();
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}
