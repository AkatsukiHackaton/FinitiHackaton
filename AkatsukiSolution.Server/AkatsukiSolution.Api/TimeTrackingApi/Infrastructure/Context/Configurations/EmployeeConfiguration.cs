using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(e => e.Type)
                .HasColumnType("varchar(20)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Manager);
        }
    }
}
