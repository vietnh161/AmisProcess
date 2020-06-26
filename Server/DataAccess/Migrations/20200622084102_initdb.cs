using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace DataAccess.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    ProcessId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.ProcessId);
                    table.ForeignKey(
                        name: "FK_Process_ProcessCategory",
                        column: x => x.CategoryId,
                        principalTable: "ProcessCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phase",
                columns: table => new
                {
                    PhaseId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Serial = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    TimeImplement = table.Column<int>(nullable: false),
                    TimeImplementType = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    EmployeeImplementType = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    EmployeeImplement = table.Column<string>(type: "mediumtext", nullable: true),
                    IsLastPhase = table.Column<byte>(nullable: true, defaultValueSql: "'0'"),
                    IsFirstPhase = table.Column<byte>(nullable: true, defaultValueSql: "'0'"),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ProcessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phase", x => x.PhaseId);
                    table.ForeignKey(
                        name: "FK_Phase_Process",
                        column: x => x.ProcessId,
                        principalTable: "Process",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    FieldId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Option = table.Column<string>(type: "mediumtext", nullable: true),
                    Required = table.Column<byte>(nullable: true, defaultValueSql: "'0'"),
                    PhaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.FieldId);
                    table.ForeignKey(
                        name: "FK_Field_Phase",
                        column: x => x.PhaseId,
                        principalTable: "Phase",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessRunning",
                columns: table => new
                {
                    ProcessRunningId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    PhaseId = table.Column<int>(nullable: false),
                    EmployeeHandleId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRunning", x => x.ProcessRunningId);
                    table.ForeignKey(
                        name: "FK_ProcessRunning_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessRunning_Phase",
                        column: x => x.PhaseId,
                        principalTable: "Phase",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProcessRunningId = table.Column<int>(nullable: true),
                    FieldId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(type: "mediumtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldValue_Field",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldValue_ProcessRunning",
                        column: x => x.ProcessRunningId,
                        principalTable: "ProcessRunning",
                        principalColumn: "ProcessRunningId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_Employee_User_idx",
                table: "Employee",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Field_Phase_idx",
                table: "Field",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "FK_FieldId_idx",
                table: "FieldValue",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "FK_FieldValue_ProcessRunning_idx",
                table: "FieldValue",
                column: "ProcessRunningId");

            migrationBuilder.CreateIndex(
                name: "FK_Phase_Process_idx",
                table: "Phase",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "FK_Process_ProcessCategory_idx",
                table: "Process",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "FK_ProcessRunning_Employee_idx",
                table: "ProcessRunning",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "FK_ProcessRunning_Phase_idx",
                table: "ProcessRunning",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "RoleId_UNIQUE",
                table: "User",
                column: "RoleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldValue");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "ProcessRunning");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Phase");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "ProcessCategory");
        }
    }
}
