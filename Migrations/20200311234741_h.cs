using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class h : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "MC",
                table: "ProjectEmployees");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "MC",
                table: "Employees",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "MC",
                table: "ProjectEmployees",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                schema: "MC",
                table: "Labours",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                schema: "MC",
                table: "Labours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "MC",
                table: "ProjectEmployees",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    HourlyPay = table.Column<double>(nullable: false),
                    HourlyCost = table.Column<double>(nullable: false),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_ProjectID",
                schema: "MC",
                table: "ProjectEmployees",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_TeamID",
                schema: "MC",
                table: "Labours",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                schema: "MC",
                table: "Employees",
                column: "EmployeeTypeId");

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
                name: "FK_Labours_ProjectEmployees_TeamID",
                schema: "MC",
                table: "Labours",
                column: "TeamID",
                principalSchema: "MC",
                principalTable: "ProjectEmployees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Labours_ProjectEmployees_TeamID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropTable(
                name: "EmployeeTypes",
                schema: "MC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "MC",
                table: "ProjectEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployees_ProjectID",
                schema: "MC",
                table: "ProjectEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Labours_TeamID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeTypeId",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "MC",
                table: "ProjectEmployees");

            migrationBuilder.DropColumn(
                name: "TeamID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "MC",
                table: "Employees",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                schema: "MC",
                table: "Labours",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectEmployees",
                schema: "MC",
                table: "ProjectEmployees",
                columns: new[] { "ProjectID", "EmployeeID" });
        }
    }
}
