using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Data.Configurations
{
    // https://docs.microsoft.com/en-us/ef/core/modeling/#use-fluent-api-to-configure-a-model
    public class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
    {
        public void Configure(EntityTypeBuilder<Instrument> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .UseIdentityColumn();
            
            builder
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(i => i.PupilInstruments)
                .WithOne();

            builder
                .ToTable("Intruments");        
   
        }
    }
}