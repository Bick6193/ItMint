using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiUsers",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ApplicationType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RefreshTokenLifeTime = table.Column<long>(nullable: false),
                    Secret = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUsers", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ForceToResetPassword = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    IsAdministrative = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
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
                name: "Projectses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true),
                    RevisionTime = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(nullable: true),
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
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessToken = table.Column<string>(nullable: false),
                    AccessTokenExpiresUtc = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IssuedUtc = table.Column<DateTime>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: false),
                    RefreshTokenExpiresUtc = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefaultFolder = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true),
                    ProjectId1 = table.Column<int>(nullable: true),
                    RevisionTime = table.Column<DateTime>(nullable: false),
                    VersionFolder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_Projectses_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Projectses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Flag = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RequestTypeId = table.Column<int>(nullable: true),
                    RequestTypeInString = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Viewed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_RequestsType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BinaryProjectFileDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: true),
                    ProjectFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryProjectFileDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinaryProjectFileDatas_ProjectFiles_ProjectFileId",
                        column: x => x.ProjectFileId,
                        principalTable: "ProjectFiles",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinaryProjectFileDatas_ProjectFileId",
                table: "BinaryProjectFileDatas",
                column: "ProjectFileId");

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
                name: "IX_ProjectFiles_ProjectId1",
                table: "ProjectFiles",
                column: "ProjectId1",
                unique: true,
                filter: "[ProjectId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "BinaryProjectFileDatas");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "ProjectFiles");

            migrationBuilder.DropTable(
                name: "BinaryFilesData");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Projectses");

            migrationBuilder.DropTable(
                name: "RequestsType");
        }
    }
}
