using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airtickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airtickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airtickets_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Airtickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "Id", "License", "Name" },
                values: new object[,]
                {
                    { 1, "LKMN", "S8 Airline" },
                    { 2, "QWER", "Barnaulskie avialinii" },
                    { 3, "BGYU", "Altair avia" },
                    { 4, "WASD", "Average lines" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Standart" },
                    { 2, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "AirlineId", "Date", "Departure", "Destination" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2023, 11, 22, 12, 15, 0, 0, DateTimeKind.Unspecified), "Barnaul", "Moskow" },
                    { 2, 1, new DateTime(2023, 11, 23, 11, 30, 0, 0, DateTimeKind.Unspecified), "Barnaul", "Krasnoyars" },
                    { 3, 2, new DateTime(2023, 11, 24, 15, 15, 0, 0, DateTimeKind.Unspecified), "Novosibirsk", "Saint Barnaul" },
                    { 4, 4, new DateTime(2023, 11, 25, 16, 55, 0, 0, DateTimeKind.Unspecified), "Omsk", "Novosibirsk" },
                    { 5, 3, new DateTime(2023, 11, 26, 13, 45, 0, 0, DateTimeKind.Unspecified), "Nizhniy Novgorod", "Moskow" },
                    { 6, 3, new DateTime(2023, 11, 27, 10, 10, 0, 0, DateTimeKind.Unspecified), "Moscow", "Novosibirsk" },
                    { 7, 2, new DateTime(2023, 11, 28, 15, 15, 0, 0, DateTimeKind.Unspecified), "Novosibirsk", "NoName" },
                    { 8, 1, new DateTime(2023, 11, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), "Barnaul", "Ne Baranaul" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DocumentNumber", "Login", "Name", "Password", "RoleId", "Surname" },
                values: new object[] { 1, "0000", "Admin", "Administrator", "12345", 2, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Airtickets_ScheduleId",
                table: "Airtickets",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Airtickets_UserId",
                table: "Airtickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AirlineId",
                table: "Schedules",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airtickets");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
