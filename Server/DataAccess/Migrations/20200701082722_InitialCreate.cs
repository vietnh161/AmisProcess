using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleId = table.Column<byte[]>(maxLength: 36, nullable: false),
                    RoleName = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "process",
                columns: table => new
                {
                    ProcessId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    CategoryId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_process", x => x.ProcessId);
                    table.ForeignKey(
                        name: "Fk_category_process_categoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(maxLength: 36, nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    RoleId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                    table.ForeignKey(
                        name: "Fk_Role_User_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phase",
                columns: table => new
                {
                    PhaseId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    Serial = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    TimeImplement = table.Column<int>(nullable: true),
                    TimeImplementType = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    EmployeeImplementType = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    EmployeeImplement = table.Column<string>(type: "mediumtext", nullable: true),
                    IsLastPhase = table.Column<byte>(nullable: true, defaultValueSql: "'0'"),
                    IsFirstPhase = table.Column<byte>(nullable: true, defaultValueSql: "'0'"),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ProcessId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phase", x => x.PhaseId);
                    table.ForeignKey(
                        name: "FK_phase_process_processId",
                        column: x => x.ProcessId,
                        principalTable: "process",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EmployeeId = table.Column<byte[]>(maxLength: 36, nullable: false),
                    EmployeeCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    UserId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    FullName = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "Fk_Employee_User_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "field",
                columns: table => new
                {
                    FieldId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Required = table.Column<byte>(nullable: true, defaultValueSql: "'0'"),
                    PhaseId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field", x => x.FieldId);
                    table.ForeignKey(
                        name: "fk_phase_field",
                        column: x => x.PhaseId,
                        principalTable: "phase",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phaseemployee",
                columns: table => new
                {
                    PhaseEmployeeId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    EmployeeId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    PhaseId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phaseemployee", x => x.PhaseEmployeeId);
                    table.ForeignKey(
                        name: "FK_employee_phaseemployee_employeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_phaseemployee_phaseId",
                        column: x => x.PhaseId,
                        principalTable: "phase",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "processrunning",
                columns: table => new
                {
                    ProcessRunningId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    EmployeeId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    PhaseId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    EmployeeHandleId = table.Column<string>(unicode: false, maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processrunning", x => x.ProcessRunningId);
                    table.ForeignKey(
                        name: "Fk_Employee_Processrunning_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Phase_Processrunning_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "phase",
                        principalColumn: "PhaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "option",
                columns: table => new
                {
                    OptionId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    Value = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    FieldId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_option", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_option_field_fieldId",
                        column: x => x.FieldId,
                        principalTable: "field",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fieldvalue",
                columns: table => new
                {
                    Id = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    ProcessRunningId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    FieldId = table.Column<byte[]>(unicode: false, maxLength: 36, nullable: false),
                    Value = table.Column<string>(type: "mediumtext", nullable: true),
                    ValueForCheckBox = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fieldvalue", x => x.Id);
                    table.ForeignKey(
                        name: "fk_field_fieldvalue",
                        column: x => x.FieldId,
                        principalTable: "field",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_processrunning_fieldvalue",
                        column: x => x.ProcessRunningId,
                        principalTable: "processrunning",
                        principalColumn: "ProcessRunningId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Fk_Employee_User_UserId_idx",
                table: "employee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "fk_phase_field_idx",
                table: "field",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "fk_field_fieldvalue_idx",
                table: "fieldvalue",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "fk_processrunning_fieldvalue_idx",
                table: "fieldvalue",
                column: "ProcessRunningId");

            migrationBuilder.CreateIndex(
                name: "FK_option_field_fieldId_idx",
                table: "option",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "FK_phase_process_processId_idx",
                table: "phase",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "FK_employee_phaseemployee_employeeId_idx",
                table: "phaseemployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "FK_employee_phaseemployee_phaseId_idx",
                table: "phaseemployee",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "Fk_category_process_categoryId_idx",
                table: "process",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "Fk_Employee_Processrunning_EmployeeId_idx",
                table: "processrunning",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "Fk_Phase_Processrunning_PhaseId_idx",
                table: "processrunning",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "Fk_Role_User_RoleId_idx",
                table: "user",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fieldvalue");

            migrationBuilder.DropTable(
                name: "option");

            migrationBuilder.DropTable(
                name: "phaseemployee");

            migrationBuilder.DropTable(
                name: "processrunning");

            migrationBuilder.DropTable(
                name: "field");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "phase");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "process");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
