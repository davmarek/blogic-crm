using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogicCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Contracts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Consultant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    BirthNumber = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractConsultant",
                columns: table => new
                {
                    ConsultantsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParticipatingContractsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractConsultant", x => new { x.ConsultantsId, x.ParticipatingContractsId });
                    table.ForeignKey(
                        name: "FK_ContractConsultant_Consultant_ConsultantsId",
                        column: x => x.ConsultantsId,
                        principalTable: "Consultant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractConsultant_Contracts_ParticipatingContractsId",
                        column: x => x.ParticipatingContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Consultant",
                columns: new[] { "Id", "BirthNumber", "Birthday", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "123456/7890", new DateTime(1998, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "juank@mail.cz", "Juan", "Fernandez", "123456789" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "123456/7890", new DateTime(2000, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jose@gmail.com", "Jose", "Gomez", "123456789" }
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "AdminId", "Closed", "Created", "Effective" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "AdminId", "Closed", "Created", "Effective" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AdminId",
                table: "Contracts",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractConsultant_ParticipatingContractsId",
                table: "ContractConsultant",
                column: "ParticipatingContractsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Consultant_AdminId",
                table: "Contracts",
                column: "AdminId",
                principalTable: "Consultant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Consultant_AdminId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractConsultant");

            migrationBuilder.DropTable(
                name: "Consultant");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_AdminId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Contracts");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Closed", "Created", "Effective" },
                values: new object[] { new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Closed", "Created", "Effective" },
                values: new object[] { new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
