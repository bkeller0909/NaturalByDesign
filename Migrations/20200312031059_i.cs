using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Labours_Projects_ProjectID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropIndex(
                name: "IX_Labours_ProjectID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.RenameColumn(
                name: "EmployeeTypeId",
                schema: "MC",
                table: "Employees",
                newName: "EmployeeTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeTypeId",
                schema: "MC",
                table: "Employees",
                newName: "IX_Employees_EmployeeTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeID",
                schema: "MC",
                table: "Employees",
                column: "EmployeeTypeID",
                principalSchema: "MC",
                principalTable: "EmployeeTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeTypeID",
                schema: "MC",
                table: "Employees",
                newName: "EmployeeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeTypeID",
                schema: "MC",
                table: "Employees",
                newName: "IX_Employees_EmployeeTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                schema: "MC",
                table: "Labours",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labours_ProjectID",
                schema: "MC",
                table: "Labours",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                schema: "MC",
                table: "Employees",
                column: "EmployeeTypeId",
                principalSchema: "MC",
                principalTable: "EmployeeTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Labours_Projects_ProjectID",
                schema: "MC",
                table: "Labours",
                column: "ProjectID",
                principalSchema: "MC",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
