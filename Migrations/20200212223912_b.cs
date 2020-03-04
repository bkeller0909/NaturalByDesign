using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Labour_Projects_ProjectID",
                schema: "MC",
                table: "Labour");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Labour_LabourID",
                schema: "MC",
                table: "Task");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients",
                column: "CityID",
                principalSchema: "MC",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Labour_Projects_ProjectID",
                schema: "MC",
                table: "Labour",
                column: "ProjectID",
                principalSchema: "MC",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Labour_LabourID",
                schema: "MC",
                table: "Task",
                column: "LabourID",
                principalSchema: "MC",
                principalTable: "Labour",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Labour_Projects_ProjectID",
                schema: "MC",
                table: "Labour");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Labour_LabourID",
                schema: "MC",
                table: "Task");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients",
                column: "CityID",
                principalSchema: "MC",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labour_Projects_ProjectID",
                schema: "MC",
                table: "Labour",
                column: "ProjectID",
                principalSchema: "MC",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Labour_LabourID",
                schema: "MC",
                table: "Task",
                column: "LabourID",
                principalSchema: "MC",
                principalTable: "Labour",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
