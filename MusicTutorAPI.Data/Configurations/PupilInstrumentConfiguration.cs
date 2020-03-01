using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTutorAPI.Core.Models;

namespace MusicTutorAPI.Data.Configurations
{
    // https://docs.microsoft.com/en-us/ef/core/modeling/#use-fluent-api-to-configure-a-model
    public class PupilInstrumentConfiguration : IEntityTypeConfiguration<PupilInstrument>
    {
        public void Configure(EntityTypeBuilder<PupilInstrument> builder)
        {
            builder
                .HasKey(t => new { t.PupilId, t.InstrumentId });

            builder
                .HasOne(pi => pi.Pupil)
                .WithMany(p => p.PupilInstruments)
                .HasForeignKey(pt => pt.PupilId);

            builder
                .HasOne(pi => pi.Instrument)
                .WithMany(i => i.PupilInstruments)
                .HasForeignKey(pt => pt.InstrumentId);

        }
    }
}