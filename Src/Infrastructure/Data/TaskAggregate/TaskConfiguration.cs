using Core.Domain.Shared.ValueObjects;
using Core.Domain.TaskAggregate.Entities;
using Core.Domain.TaskAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.TaskAggregate;

public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(t => t.Id);
        builder.Property(x => x.Id).HasColumnName("Id");

        builder.Property(a => a.Title)
               .HasConversion(x => x.Value, value => Title.Parse(value))
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.Status)
           .HasConversion(p => p.Id, p => Status.FromValue(p));

          builder.Property(a => a.CreateAt)
               .HasConversion(x => x.Value, value => CreateAt.Parse(value))
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(a => a.CheckOutDate)
               .HasConversion<DateOnly?>(x => x == null ? null : x.Value, value => value == null ? null : CheckOutDate.Parse(value.Value));


        builder.Property(a => a.CreatorUserId)
               .HasConversion(x => x.Value, value => CreatorUserId.Parse(value))
               .IsRequired();


    }
}
