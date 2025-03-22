using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(wd => wd.Role);
        }
    }
}
