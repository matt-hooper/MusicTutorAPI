using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Data.Configurations
{
    // https://docs.microsoft.com/en-us/ef/core/modeling/#use-fluent-api-to-configure-a-model
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .UseIdentityColumn();

            builder
                .Property(l => l.StartDateTime)
                .IsRequired();

            builder
                .Property(l => l.EndDateTime)
                .IsRequired();    

            builder
                .Property(l => l.Cost)
                .HasColumnType("decimal(6, 2)")
                .IsRequired(); 

            builder
                .Property(c => c.IsPlanned)
                .IsRequired();       

            builder
                .HasOne(l => l.Pupil)
                .WithMany(p => p.Lessons)
                .HasForeignKey(l => l.PupilId)
                .IsRequired();    

            builder
                .ToTable("Lessons");                      

        }
    }
}