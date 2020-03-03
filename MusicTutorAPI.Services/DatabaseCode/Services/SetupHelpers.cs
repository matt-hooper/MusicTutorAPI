using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MusicTutorAPI.Core.Models;
using MusicTutorAPI.Data;

namespace MusicTutorAPI.Services.DatabaseCode.Services
{
    public static class SetupHelpers
    {
        
        public static void DevelopmentEnsureDeleted(this MusicTutorAPIDbContext db)
        {
            db.Database.EnsureDeleted();
        }

        public static void DevelopmentEnsureCreated(this MusicTutorAPIDbContext db)
        {
            db.Database.EnsureCreated();
        }
        
        public static int SeedDatabase(this MusicTutorAPIDbContext context)
        {
            // if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            //     throw new InvalidOperationException("The database does not exist. If you are using Migrations then run PMC command update-database to create it");

            var numInstruments = context.Instruments.Count();
            if (numInstruments == 0)
            {
                //the database is empty so we fill it from a json file
                // var books = BookJsonLoader.LoadBooks(Path.Combine(dataDirectory, SeedFileSubDirectory),
                //     SeedDataSearchName).ToList();
                // context.Books.AddRange(books);
                // context.SaveChanges();
                // numInstruments = books.Count + 1;
                // context.ResetOrders(books);

                var instruments = new Instrument[] { new Instrument{ Name = "Piano"}, new Instrument{ Name = "Flute"} };
                context.Instruments.AddRange(instruments);
                context.SaveChanges();
                numInstruments = instruments.Length;
            }

            return numInstruments;
        }
    }
}