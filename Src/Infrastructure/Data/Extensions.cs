using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.TaskAggregate;
using Framework.Ef;
using Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;
public static class Extensions
{
    public static void AddEntityFramework(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork,UnitOfWork<DatabaseContext>>();
        services.AddScoped<ITaskRepository,ITaskRepository>();
    }
}
