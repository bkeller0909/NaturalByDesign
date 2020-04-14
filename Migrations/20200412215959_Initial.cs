using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectEmployeeID",
                schema: "MC",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectEmployeeID",
                schema: "MC",
                table: "Employees",
                column: "ProjectEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ProjectEmployees_ProjectEmployeeID",
                schema: "MC",
                table: "Employees",
                column: "ProjectEmployeeID",
                principalSchema: "MC",
                principalTable: "ProjectEmployees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProjectEmployees_ProjectEmployeeID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectEmployeeID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectEmployeeID",
                schema: "MC",
                table: "Employees");
        }
    }
}
