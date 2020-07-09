using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class configcadecase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_Employee_User_UserId",
                table: "employee");

            migrationBuilder.DropForeignKey(
                name: "fk_phase_field",
                table: "field");

            migrationBuilder.DropForeignKey(
                name: "fk_field_fieldvalue",
                table: "fieldvalue");

            migrationBuilder.DropForeignKey(
                name: "fk_processrunning_fieldvalue",
                table: "fieldvalue");

            migrationBuilder.DropForeignKey(
                name: "FK_phase_process_processId",
                table: "phase");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_phaseemployee_employeeId",
                table: "phaseemployee");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_phaseemployee_phaseId",
                table: "phaseemployee");

            migrationBuilder.DropForeignKey(
                name: "Fk_category_process_categoryId",
                table: "process");

            migrationBuilder.DropForeignKey(
                name: "Fk_Employee_Processrunning_EmployeeId",
                table: "processrunning");

            migrationBuilder.DropForeignKey(
                name: "Fk_Phase_Processrunning_PhaseId",
                table: "processrunning");

            migrationBuilder.DropForeignKey(
                name: "Fk_Role_User_RoleId",
                table: "user");

            migrationBuilder.DropTable(
                name: "option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                table: "role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_processrunning",
                table: "processrunning");

            migrationBuilder.DropPrimaryKey(
                name: "PK_process",
                table: "process");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phaseemployee",
                table: "phaseemployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phase",
                table: "phase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fieldvalue",
                table: "fieldvalue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_field",
                table: "field");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee",
                table: "employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropColumn(
                name: "IsFirstPhase",
                table: "phase");

            migrationBuilder.DropColumn(
                name: "IsLastPhase",
                table: "phase");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "processrunning",
                newName: "ProcessRunning");

            migrationBuilder.RenameTable(
                name: "process",
                newName: "Process");

            migrationBuilder.RenameTable(
                name: "phaseemployee",
                newName: "PhaseEmployee");

            migrationBuilder.RenameTable(
                name: "phase",
                newName: "Phase");

            migrationBuilder.RenameTable(
                name: "fieldvalue",
                newName: "FieldValue");

            migrationBuilder.RenameTable(
                name: "field",
                newName: "Field");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "Fk_category_process_categoryId_idx",
                table: "Process",
                newName: "FK_process_category_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "User",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "User",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Role",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Status",
                table: "ProcessRunning",
                type: "tinyint(4)",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PhaseId",
                table: "ProcessRunning",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "ProcessRunning",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeHandleId",
                table: "ProcessRunning",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldUnicode: false,
                oldMaxLength: 36,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessRunningId",
                table: "ProcessRunning",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Process",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Process",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Process",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Process",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Process",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Process",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessId",
                table: "Process",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhaseId",
                table: "PhaseEmployee",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "PhaseEmployee",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhaseEmployeeId",
                table: "PhaseEmployee",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Phase",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "TimeImplementType",
                table: "Phase",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "TimeImplement",
                table: "Phase",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Serial",
                table: "Phase",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessId",
                table: "Phase",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Phase",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeImplementType",
                table: "Phase",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeImplement",
                table: "Phase",
                type: "mediumtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "mediumtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Phase",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Phase",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhaseId",
                table: "Phase",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "Posittion",
                table: "Phase",
                type: "int(11)",
                nullable: true,
                defaultValueSql: "'2'",
                comment: "Vi tri cua phase trong process: 1 dau, 2 giua, 3 cuoi");

            migrationBuilder.AlterColumn<string>(
                name: "ValueForCheckBox",
                table: "FieldValue",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "FieldValue",
                type: "mediumtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "mediumtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessRunningId",
                table: "FieldValue",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "FieldId",
                table: "FieldValue",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FieldValue",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Field",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Required",
                table: "Field",
                type: "tinyint(4)",
                nullable: true,
                defaultValueSql: "'0'",
                oldClrType: typeof(sbyte),
                oldType: "tinyint",
                oldNullable: true,
                oldDefaultValueSql: "'0'");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhaseId",
                table: "Field",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Field",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Field",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "FieldId",
                table: "Field",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employee",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employee",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeCode",
                table: "Employee",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employee",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "varchar(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Category",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Category",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "char(36)",
                oldUnicode: false,
                oldMaxLength: 36)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessRunning",
                table: "ProcessRunning",
                column: "ProcessRunningId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Process",
                table: "Process",
                column: "ProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhaseEmployee",
                table: "PhaseEmployee",
                column: "PhaseEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phase",
                table: "Phase",
                column: "PhaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldValue",
                table: "FieldValue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Field",
                table: "Field",
                column: "FieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "FieldOption",
                columns: table => new
                {
                    OptionId = table.Column<Guid>(nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Value = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    FieldId = table.Column<Guid>(nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_option_field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "FK_option_field_fieldId_idx",
                table: "FieldOption",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_user_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_field_phase_PhaseId",
                table: "Field",
                column: "PhaseId",
                principalTable: "Phase",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fieldvalue_field_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fieldvalue_processrunning_ProcessRunningId",
                table: "FieldValue",
                column: "ProcessRunningId",
                principalTable: "ProcessRunning",
                principalColumn: "ProcessRunningId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phase_process_ProcessId",
                table: "Phase",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phaseemployee_employee_EmployeeId",
                table: "PhaseEmployee",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phaseemployee_phase_PhaseId",
                table: "PhaseEmployee",
                column: "PhaseId",
                principalTable: "Phase",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_process_category_CategoryId",
                table: "Process",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_processrunning_employee_EmployeeId",
                table: "ProcessRunning",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_processrunning_phase_PhaseId",
                table: "ProcessRunning",
                column: "PhaseId",
                principalTable: "Phase",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_user_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_field_phase_PhaseId",
                table: "Field");

            migrationBuilder.DropForeignKey(
                name: "FK_fieldvalue_field_FieldId",
                table: "FieldValue");

            migrationBuilder.DropForeignKey(
                name: "FK_fieldvalue_processrunning_ProcessRunningId",
                table: "FieldValue");

            migrationBuilder.DropForeignKey(
                name: "FK_phase_process_ProcessId",
                table: "Phase");

            migrationBuilder.DropForeignKey(
                name: "FK_phaseemployee_employee_EmployeeId",
                table: "PhaseEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_phaseemployee_phase_PhaseId",
                table: "PhaseEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_process_category_CategoryId",
                table: "Process");

            migrationBuilder.DropForeignKey(
                name: "FK_processrunning_employee_EmployeeId",
                table: "ProcessRunning");

            migrationBuilder.DropForeignKey(
                name: "FK_processrunning_phase_PhaseId",
                table: "ProcessRunning");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "FieldOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessRunning",
                table: "ProcessRunning");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Process",
                table: "Process");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhaseEmployee",
                table: "PhaseEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phase",
                table: "Phase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldValue",
                table: "FieldValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Field",
                table: "Field");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Posittion",
                table: "Phase");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "ProcessRunning",
                newName: "processrunning");

            migrationBuilder.RenameTable(
                name: "Process",
                newName: "process");

            migrationBuilder.RenameTable(
                name: "PhaseEmployee",
                newName: "phaseemployee");

            migrationBuilder.RenameTable(
                name: "Phase",
                newName: "phase");

            migrationBuilder.RenameTable(
                name: "FieldValue",
                newName: "fieldvalue");

            migrationBuilder.RenameTable(
                name: "Field",
                newName: "field");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "employee");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameIndex(
                name: "FK_process_category_CategoryId",
                table: "process",
                newName: "Fk_category_process_categoryId_idx");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "user",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RoleId",
                table: "user",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "user",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "UserId",
                table: "user",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "role",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RoleId",
                table: "role",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Status",
                table: "processrunning",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PhaseId",
                table: "processrunning",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "EmployeeId",
                table: "processrunning",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeHandleId",
                table: "processrunning",
                type: "varchar(36)",
                unicode: false,
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProcessRunningId",
                table: "processrunning",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "process",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "process",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "process",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "process",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "process",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "CategoryId",
                table: "process",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProcessId",
                table: "process",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PhaseId",
                table: "phaseemployee",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "EmployeeId",
                table: "phaseemployee",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PhaseEmployeeId",
                table: "phaseemployee",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "phase",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "TimeImplementType",
                table: "phase",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "TimeImplement",
                table: "phase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Serial",
                table: "phase",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProcessId",
                table: "phase",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "phase",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeImplementType",
                table: "phase",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeImplement",
                table: "phase",
                type: "mediumtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "mediumtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "phase",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "phase",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PhaseId",
                table: "phase",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<sbyte>(
                name: "IsFirstPhase",
                table: "phase",
                type: "tinyint",
                nullable: true,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<sbyte>(
                name: "IsLastPhase",
                table: "phase",
                type: "tinyint",
                nullable: true,
                defaultValueSql: "'0'");

            migrationBuilder.AlterColumn<string>(
                name: "ValueForCheckBox",
                table: "fieldvalue",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "fieldvalue",
                type: "mediumtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "mediumtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProcessRunningId",
                table: "fieldvalue",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FieldId",
                table: "fieldvalue",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Id",
                table: "fieldvalue",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "field",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Required",
                table: "field",
                type: "tinyint",
                nullable: true,
                defaultValueSql: "'0'",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(4)",
                oldNullable: true,
                oldDefaultValueSql: "'0'");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PhaseId",
                table: "field",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "field",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "field",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FieldId",
                table: "field",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "UserId",
                table: "employee",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "employee",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "employee",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeCode",
                table: "employee",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "employee",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "employee",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "EmployeeId",
                table: "employee",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "category",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "category",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte[]>(
                name: "CategoryId",
                table: "category",
                type: "char(36)",
                unicode: false,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid))
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                table: "role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_processrunning",
                table: "processrunning",
                column: "ProcessRunningId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_process",
                table: "process",
                column: "ProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phaseemployee",
                table: "phaseemployee",
                column: "PhaseEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phase",
                table: "phase",
                column: "PhaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fieldvalue",
                table: "fieldvalue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_field",
                table: "field",
                column: "FieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee",
                table: "employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "option",
                columns: table => new
                {
                    OptionId = table.Column<byte[]>(type: "char(36)", unicode: false, maxLength: 36, nullable: false),
                    FieldId = table.Column<byte[]>(type: "char(36)", unicode: false, maxLength: 36, nullable: false),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "FK_option_field_fieldId_idx",
                table: "option",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "Fk_Employee_User_UserId",
                table: "employee",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_phase_field",
                table: "field",
                column: "PhaseId",
                principalTable: "phase",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_field_fieldvalue",
                table: "fieldvalue",
                column: "FieldId",
                principalTable: "field",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_processrunning_fieldvalue",
                table: "fieldvalue",
                column: "ProcessRunningId",
                principalTable: "processrunning",
                principalColumn: "ProcessRunningId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phase_process_processId",
                table: "phase",
                column: "ProcessId",
                principalTable: "process",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_phaseemployee_employeeId",
                table: "phaseemployee",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_phaseemployee_phaseId",
                table: "phaseemployee",
                column: "PhaseId",
                principalTable: "phase",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_category_process_categoryId",
                table: "process",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_Employee_Processrunning_EmployeeId",
                table: "processrunning",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_Phase_Processrunning_PhaseId",
                table: "processrunning",
                column: "PhaseId",
                principalTable: "phase",
                principalColumn: "PhaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Fk_Role_User_RoleId",
                table: "user",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
