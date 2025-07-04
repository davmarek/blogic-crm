﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogicCRM.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthNumber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthNumber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Effective = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Closed = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AdminId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Consultants_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContractConsultant",
                columns: table => new
                {
                    ConsultantsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParticipatingContractsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractConsultant", x => new { x.ConsultantsId, x.ParticipatingContractsId });
                    table.ForeignKey(
                        name: "FK_ContractConsultant_Consultants_ConsultantsId",
                        column: x => x.ConsultantsId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractConsultant_Contracts_ParticipatingContractsId",
                        column: x => x.ParticipatingContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BirthNumber", "Birthdate", "CreatedAt", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "1234567890", new DateTime(1985, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Barry_Moran561@jcf8v.mobi", "Jan", "Novák", "123456789" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "1234567890", new DateTime(1986, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Ema_Mcleod5369@yahoo.directory", "David", "Svoboda", "987654321" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "1234567890", new DateTime(1987, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Maxwell_Ebbs6093@1kmd3.press", "Petr", "Novotný", "555123456" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "1234567890", new DateTime(1988, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Louise_Khan3677@ds59r.host", "Martin", "Dvořák", "444987654" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "1234567890", new DateTime(1989, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Aileen_Gaynor5441@hepmv.meet", "Tomáš", "Černý", "333555123" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "1234567890", new DateTime(1990, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Sloane_Tanner4692@kyb7t.info", "Lukáš", "Procházka", "222444987" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "1234567890", new DateTime(1991, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Adalind_Lindsay1835@yfxpw.edu", "Michal", "Kovář", "111333555" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "1234567890", new DateTime(1992, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Maria_Potts856@v1wn5.zone", "Jakub", "Veselý", "666777888" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "1234567890", new DateTime(1993, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Mason_Tutton6832@xtwt3.online", "Filip", "Horák", "999000111" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "1234567890", new DateTime(1994, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Fiona_Saunders8101@karnv.software", "Vojtěch", "Němec", "888999000" }
                });

            migrationBuilder.InsertData(
                table: "Consultants",
                columns: new[] { "Id", "BirthNumber", "Birthdate", "CreatedAt", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "1234567890", new DateTime(1985, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Sebastian_Sanchez2407@yvu30.website", "Jaroslav", "Fiala", "111888777" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "1234567890", new DateTime(1986, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Josh_Logan4466@uagvw.app", "Josef", "Král", "222999888" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "1234567890", new DateTime(1987, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Roger_Bingham7598@dvqq2.meet", "Adam", "Richter", "333111000" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "1234567890", new DateTime(1988, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Bryon_Windsor6229@iscmr.meet", "Matěj", "Beneš", "444222111" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "1234567890", new DateTime(1989, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Courtney_Salt2851@y96lx.mobi", "Daniel", "Růžička", "555444333" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "1234567890", new DateTime(1990, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Rocco_Richards6731@bcfhs.business", "Ondřej", "Pokorný", "777666555" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "1234567890", new DateTime(1991, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Fiona_Saunders8101@karnv.software", "Vojtěch", "Němec", "888999000" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "1234567890", new DateTime(1992, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Mason_Tutton6832@xtwt3.online", "Filip", "Horák", "999000111" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "1234567890", new DateTime(1993, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Maria_Potts856@v1wn5.zone", "Jakub", "Veselý", "666777888" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "1234567890", new DateTime(1994, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Adalind_Lindsay1835@yfxpw.edu", "Michal", "Kovář", "111333555" }
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ČSOB" },
                    { 2, "AEGON" },
                    { 3, "AXA" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "AdminId", "ClientId", "Closed", "Created", "CreatedAt", "Effective", "InstitutionId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractConsultant_ParticipatingContractsId",
                table: "ContractConsultant",
                column: "ParticipatingContractsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AdminId",
                table: "Contracts",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_InstitutionId",
                table: "Contracts",
                column: "InstitutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractConsultant");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
