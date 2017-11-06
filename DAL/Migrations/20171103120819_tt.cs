using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    ForceToResetPassword = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    IsAdministrative = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BinaryFilesData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryFilesData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    MetaDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.MetaDataId);
                });

            migrationBuilder.CreateTable(
                name: "RequestsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeesEmail = table.Column<string>(nullable: true),
                    EmployeesName = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    MessageBodyToCustomer = table.Column<string>(nullable: true),
                    MessageToCustomer = table.Column<string>(nullable: true),
                    OrderWeight = table.Column<int>(nullable: false),
                    SendEmailToCustomer = table.Column<bool>(nullable: false),
                    SendEmailToEmployee = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Email = table.Column<string>(maxLength: 450, nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    RequestTypeId = table.Column<int>(nullable: true),
                    RequestTypeInString = table.Column<string>(maxLength: 450, nullable: true),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    Viewed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_RequestsType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BinaryDataId = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FileIndex = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    RequestFormId = table.Column<int>(nullable: true),
                    RequestFormToken = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_BinaryFilesData_BinaryDataId",
                        column: x => x.BinaryDataId,
                        principalTable: "BinaryFilesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_BinaryDataId",
                table: "Files",
                column: "BinaryDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_RequestId",
                table: "Files",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "BinaryFilesData");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "RequestsType");
        }
    }
}
