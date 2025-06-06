using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogicCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultantDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractConsultant_Consultant_ConsultantsId",
                table: "ContractConsultant");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Consultant_AdminId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultant",
                table: "Consultant");

            migrationBuilder.RenameTable(
                name: "Consultant",
                newName: "Consultants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultants",
                table: "Consultants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractConsultant_Consultants_ConsultantsId",
                table: "ContractConsultant",
                column: "ConsultantsId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Consultants_AdminId",
                table: "Contracts",
                column: "AdminId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractConsultant_Consultants_ConsultantsId",
                table: "ContractConsultant");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Consultants_AdminId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultants",
                table: "Consultants");

            migrationBuilder.RenameTable(
                name: "Consultants",
                newName: "Consultant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultant",
                table: "Consultant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractConsultant_Consultant_ConsultantsId",
                table: "ContractConsultant",
                column: "ConsultantsId",
                principalTable: "Consultant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Consultant_AdminId",
                table: "Contracts",
                column: "AdminId",
                principalTable: "Consultant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
