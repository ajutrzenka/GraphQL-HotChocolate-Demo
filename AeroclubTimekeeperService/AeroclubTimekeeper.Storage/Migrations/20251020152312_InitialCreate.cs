using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroclubTimekeeper.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistrationCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    ProductionYear = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatsNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TopSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    StallSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    IsServiceRequired = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    EnginePower = table.Column<double>(type: "REAL", nullable: true),
                    LiftToDragRatio = table.Column<int>(type: "INTEGER", nullable: true),
                    OptimalSpeed = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    HasValidLicense = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsStudent = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsInstructor = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasValidMedicalExamination = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasInsurance = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentWeathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AirportId = table.Column<int>(type: "INTEGER", nullable: false),
                    TemperatureC = table.Column<int>(type: "INTEGER", nullable: false),
                    WindDirection = table.Column<int>(type: "INTEGER", nullable: false),
                    WindSpeedKnots = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentWeathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentWeathers_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartAirportId = table.Column<int>(type: "INTEGER", nullable: false),
                    EndAirportId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    TakeOffTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LandingTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AircraftId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstPilotId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondPilotId = table.Column<int>(type: "INTEGER", nullable: true),
                    HasInstructorGroundSupervision = table.Column<bool>(type: "INTEGER", nullable: false),
                    TaskType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_EndAirportId",
                        column: x => x.EndAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_StartAirportId",
                        column: x => x.StartAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_FirstPilotId",
                        column: x => x.FirstPilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_SecondPilotId",
                        column: x => x.SecondPilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentWeathers_AirportId",
                table: "CurrentWeathers",
                column: "AirportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftId",
                table: "Flights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_EndAirportId",
                table: "Flights",
                column: "EndAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FirstPilotId",
                table: "Flights",
                column: "FirstPilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_SecondPilotId",
                table: "Flights",
                column: "SecondPilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StartAirportId",
                table: "Flights",
                column: "StartAirportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentWeathers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Pilots");
        }
    }
}
