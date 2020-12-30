using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Data.Configurations
{
    // https://docs.microsoft.com/en-us/ef/core/modeling/#use-fluent-api-to-configure-a-model
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder
                .Property(a => a.PaymentDate)
                .IsRequired();
            
            builder
                .Property(a => a.Amount)
                .HasColumnType("decimal(6, 2)")
                .IsRequired(); 

            builder
                .Property(a => a.Type)
                .IsRequired();       

            builder
                .HasOne(a => a.Pupil)
                .WithMany(p => p.Payments)
                .HasForeignKey(a => a.PupilId)
                .IsRequired();     

            builder
                .ToTable("Payments");                

        }
    }
}