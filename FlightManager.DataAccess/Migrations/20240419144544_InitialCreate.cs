using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Airports_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalCityId",
                table: "Flights",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureCityId",
                table: "Flights",
                column: "DepartureCityId");

            Seed(migrationBuilder);
        }

        private void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Name"},
                values: new object[,] { 
                    { 1, "Warsaw" },
                    { 2, "Lublin" },
                    { 3, "Radom" },
                    { 4, "Wroclaw" },
                });
            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "Name" },
                values: new object[,] {
                                { 1, "Embraer" },
                                { 2, "Boeing" },
                                { 3, "Airbus" },
                                { 4, "Cessna" },
                });
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Name", "DepartureTime", "DepartureCityId", "ArrivalCityId", "AirplaneId" },
                values: new object[,] {
                                { 1, "ABC1", DateTime.Now, 1, 2, 1 },
                                { 2, "AAA2", DateTime.Now.AddDays(2), 2, 3, 2 },
                                { 3, "BCD1", DateTime.Now.AddDays(5), 1, 3, 3 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
