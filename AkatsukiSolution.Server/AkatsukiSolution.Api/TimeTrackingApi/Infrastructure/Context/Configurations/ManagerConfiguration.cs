using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder
                .Property(m => m.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(m => m.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(m => m.Projects);

            builder
                .HasMany(m => m.Employees);

        }
    }
}
