using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicTutorAPI.Data.Migrations
{
    public partial class UniqueIndexForInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Instruments_Name",
                table: "Instruments",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instruments_Name",
                table: "Instruments");
        }
    }
}
