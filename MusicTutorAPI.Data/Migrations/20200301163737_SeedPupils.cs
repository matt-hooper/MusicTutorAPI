using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicTutorAPI.Data.Migrations
{
    public partial class SeedPupils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Instruments (Name) Values ('Flute'), ('Piano')");

            migrationBuilder
                .Sql("INSERT INTO Contacts (Name, Email, PhoneNumber) Values ('Sarah', 'mum.sarah@mailinator.com', '07777 123456'), ('Peter', 'dad.peter@mailinator.com', '07777 112233')");
            
            migrationBuilder
                .Sql("INSERT INTO Pupils (Name, ContactID, CurrentLessonRate, AccountBalance, StartDate, IsActive, FrequencyInDays)" + 
                     " Values ('Grace', (SELECT Id FROM Contacts WHERE Name = 'Sarah'), 15.50, 0, '2020-01-01', 1, 7)" +
                     ", ('Thomas', (SELECT Id FROM Contacts WHERE Name = 'Sarah'), 15.50, 0, '2020-01-02', 1, 7)" +
                     ", ('Gordon', (SELECT Id FROM Contacts WHERE Name = 'Peter'), 15.50, 0, '2020-01-03', 1, 7)" );    

            migrationBuilder
                .Sql("INSERT INTO PupilInstruments (PupilId, InstrumentId)" + 
                     " Values ((SELECT Id FROM Pupils WHERE Name = 'Grace'), (SELECT Id FROM Instruments WHERE Name = 'Flute'))" + 
                     " , ((SELECT Id FROM Pupils WHERE Name = 'Thomas'), (SELECT Id FROM Instruments WHERE Name = 'Piano'))" +           
                     " , ((SELECT Id FROM Pupils WHERE Name = 'Gordon'), (SELECT Id FROM Instruments WHERE Name = 'Piano'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM PupilInstruments");

            migrationBuilder
                .Sql("DELETE FROM Pupils");

            migrationBuilder
                .Sql("DELETE FROM Contacts");

            migrationBuilder
                .Sql("DELETE FROM Instruments");
        }
    }
}
