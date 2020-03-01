using Microsoft.EntityFrameworkCore;
using MusicTutorAPI.Core.Models;
using MusicTutorAPI.Data.Configurations;

namespace MusicTutorAPI.Data
{
    public class MusicTutorAPIDbContext : DbContext
    {
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        
        public MusicTutorAPIDbContext(DbContextOptions<MusicTutorAPIDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ContactConfiguration());
            builder
                .ApplyConfiguration(new InstrumentConfiguration());                
            builder
                .ApplyConfiguration(new LessonConfiguration());    
            builder
                .ApplyConfiguration(new PaymentConfiguration());                
            builder
                .ApplyConfiguration(new PupilConfiguration());
            builder
                .ApplyConfiguration(new PupilInstrumentConfiguration());

        }
    }
}