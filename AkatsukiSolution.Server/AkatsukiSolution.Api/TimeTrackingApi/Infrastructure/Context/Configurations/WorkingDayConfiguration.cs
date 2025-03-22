using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context.Configurations
{
    public class WorkingDayConfiguration : IEntityTypeConfiguration<WorkingDay>
    {
        public void Configure(EntityTypeBuilder<WorkingDay> builder)
        {
            builder
                .Property(wd => wd.Date)
                .IsRequired();

            builder
                .Property(wd => wd.TaskDescription)
                .HasMaxLength(300)
                .IsRequired();

            builder .Property(wd => wd.Hours)
                .HasColumnType("decimal")
                .IsRequired();

            builder
                .HasOne(wd => wd.Employee);

            builder
                .HasOne(wd => wd.Project)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
