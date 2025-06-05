using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogicCRM.Migrations
{
    /// <inheritdoc />
    public partial class FixContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ClientId", "Closed", "Created", "Effective", "InstitutionId" },
                values: new object[,]
                {
                    { new Guid("27d4984c-5920-4394-b99e-b656bd4eafb9"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { new Guid("9e0b5eeb-8202-475f-a9d3-4e6b3074fc1f"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("27d4984c-5920-4394-b99e-b656bd4eafb9"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("9e0b5eeb-8202-475f-a9d3-4e6b3074fc1f"));
        }
    }
}
