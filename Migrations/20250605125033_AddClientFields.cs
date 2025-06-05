using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogicCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddClientFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthNumber",
                table: "Clients",
                type: "TEXT",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "BirthNumber", "Birthday" },
                values: new object[] { "123456/7890", new DateTime(1996, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "BirthNumber", "Birthday" },
                values: new object[] { "123456/7890", new DateTime(2002, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Clients");
        }
    }
}
