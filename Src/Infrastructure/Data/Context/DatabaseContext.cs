using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.TaskAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context;
public class DatabaseContext:DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (string item in Directory.GetFiles(AppContext.BaseDirectory, "Infrastructure*.dll", new EnumerationOptions
        {
            MatchCasing = MatchCasing.CaseInsensitive
        }).ToList())
        {
            Assembly assembly = Assembly.LoadFile(item);
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

    }
}
