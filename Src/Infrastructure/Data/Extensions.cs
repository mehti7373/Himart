using Core.Domain.TaskAggregate;
using Framework.Ef;
using Infrastructure.Data.Context;
using Infrastructure.Data.TaskAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;
public static class Extensions
{
    public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<DatabaseContext>>();

        var connectionString = configuration.GetConnectionString("Himart");
        var migrationsAssembly = typeof(DatabaseContext).Assembly.FullName;

        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
        );
        services.AddEntityFrameworkSqlServer();

        services.AddScoped<ITaskRepository, TaskRepository>();
    }

    public static void MigrateDbContext(this IServiceProvider serviceProvider)
    {
        var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        using var scope = serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        dbContext.Database.Migrate();
    }
}

