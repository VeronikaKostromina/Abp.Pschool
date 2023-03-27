using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abp.Pschool.Migrations
{
    /// <inheritdoc />
    public partial class CreateStudentTeacherStudentDocumentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_TeacherId",
                table: "AbpOrganizationUnits");

            migrationBuilder.RenameColumn(
                name: "TeacherName",
                table: "AbpPermissions",
                newName: "ParentName");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "AbpOrganizationUnits",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpOrganizationUnits_TeacherId",
                table: "AbpOrganizationUnits",
                newName: "IX_AbpOrganizationUnits_ParentId");

            migrationBuilder.RenameColumn(
                name: "TeacherName",
                table: "AbpFeatures",
                newName: "ParentName");

            migrationBuilder.CreateTable(
                name: "AppTeachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTeachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudents_AppTeachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AppTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppStudentDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudentDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudentDocuments_AppStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AppStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentDocuments_StudentId",
                table: "AppStudentDocuments",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppStudents_TeacherId",
                table: "AppStudents",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits",
                column: "ParentId",
                principalTable: "AbpOrganizationUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AppStudentDocuments");

            migrationBuilder.DropTable(
                name: "AppStudents");

            migrationBuilder.DropTable(
                name: "AppTeachers");

            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "AbpPermissions",
                newName: "TeacherName");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "AbpOrganizationUnits",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits",
                newName: "IX_AbpOrganizationUnits_TeacherId");

            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "AbpFeatures",
                newName: "TeacherName");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_TeacherId",
                table: "AbpOrganizationUnits",
                column: "TeacherId",
                principalTable: "AbpOrganizationUnits",
                principalColumn: "Id");
        }
    }
}
