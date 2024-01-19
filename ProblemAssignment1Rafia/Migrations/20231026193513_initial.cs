using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProblemAssignment1Rafia.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "BPMeasurements",
                columns: table => new
                {
                    BPMeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystolicValue = table.Column<int>(type: "int", nullable: false),
                    DiastolicValue = table.Column<int>(type: "int", nullable: false),
                    DateofReading = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMeasurements", x => x.BPMeasurementId);
                    table.ForeignKey(
                        name: "FK_BPMeasurements_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "PositionName" },
                values: new object[,]
                {
                    { "ly", "Lying Down" },
                    { "sd", "Standing" },
                    { "si", "Sitting" }
                });

            migrationBuilder.InsertData(
                table: "BPMeasurements",
                columns: new[] { "BPMeasurementId", "DateofReading", "DiastolicValue", "PositionId", "SystolicValue" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, "sd", 190 },
                    { 2, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, "si", 142 },
                    { 3, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, "ly", 131 },
                    { 4, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, "si", 122 },
                    { 5, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, "ly", 190 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BPMeasurements_PositionId",
                table: "BPMeasurements",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BPMeasurements");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
