using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Labours_LabourID",
                schema: "MC",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_LabourID",
                schema: "MC",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LabourID",
                schema: "MC",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TimeSpent",
                schema: "MC",
                table: "Labours");

            migrationBuilder.AddColumn<int>(
                name: "EstHours",
                schema: "MC",
                table: "Labours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                schema: "MC",
                table: "Labours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskID",
                schema: "MC",
                table: "Labours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "MC",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "MC",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTypeId",
                schema: "MC",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Labours_TaskID",
                schema: "MC",
                table: "Labours",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labours_Tasks_TaskID",
                schema: "MC",
                table: "Labours",
                column: "TaskID",
                principalSchema: "MC",
                principalTable: "Tasks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labours_Tasks_TaskID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropIndex(
                name: "IX_Labours_TaskID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "EstHours",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "Hours",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "TaskID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                schema: "MC",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "LabourID",
                schema: "MC",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeSpent",
                schema: "MC",
                table: "Labours",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "MC",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "MC",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LabourID",
                schema: "MC",
                table: "Tasks",
                column: "LabourID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Labours_LabourID",
                schema: "MC",
                table: "Tasks",
                column: "LabourID",
                principalSchema: "MC",
                principalTable: "Labours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
