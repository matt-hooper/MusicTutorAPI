using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicTutorAPI.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    ContactID = table.Column<int>(nullable: false),
                    CurrentLessonRate = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    AccountBalance = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    FrequencyInDays = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pupils_Contact_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    PupilId = table.Column<int>(nullable: false),
                    PupilId1 = table.Column<int>(nullable: true),
                    InstrumentId = table.Column<int>(nullable: false),
                    IsPlanned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lesson_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lesson_Pupils_PupilId1",
                        column: x => x.PupilId1,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    PupilId = table.Column<int>(nullable: false),
                    PupilId1 = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Pupils_PupilId1",
                        column: x => x.PupilId1,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PupilInstrument",
                columns: table => new
                {
                    PupilId = table.Column<int>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilInstrument", x => new { x.PupilId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_PupilInstrument_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PupilInstrument_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_InstrumentId",
                table: "Lesson",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_PupilId",
                table: "Lesson",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_PupilId1",
                table: "Lesson",
                column: "PupilId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PupilId",
                table: "Payment",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PupilId1",
                table: "Payment",
                column: "PupilId1");

            migrationBuilder.CreateIndex(
                name: "IX_PupilInstrument_InstrumentId",
                table: "PupilInstrument",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_ContactID",
                table: "Pupils",
                column: "ContactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PupilInstrument");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
