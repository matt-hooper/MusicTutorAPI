using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Data.Configurations
{
    // https://docs.microsoft.com/en-us/ef/core/modeling/#use-fluent-api-to-configure-a-model
    public class PupilConfiguration : IEntityTypeConfiguration<Pupil>
    {
        public void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .UseIdentityColumn();

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150); 

            builder
                .Property(p => p.IsActive)
                .IsRequired();   

            builder
                .Property(p => p.AccountBalance)
                .HasColumnType("decimal(6, 2)")
                .IsRequired();     

            builder
                .Property(p => p.CurrentLessonRate)
                .HasColumnType("decimal(6, 2)")
                .IsRequired();         

            builder
                .Property(p => p.Timestamp)
                .IsRowVersion(); 

            builder
                .HasMany(p => p.Lessons)
                .WithOne();

            builder
                .HasMany(p => p.Payments)
                .WithOne();   

            builder
                .HasMany(p => p.PupilInstruments)
                .WithOne();

            builder
                .HasOne(p => p.Contact)
                .WithMany(c => c.Pupils)
                .HasForeignKey(p => p.ContactID);     

            builder
                .ToTable("Pupils");                      

        }
    }
}