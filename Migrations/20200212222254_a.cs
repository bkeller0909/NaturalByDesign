using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                schema: "MC",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Labour",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TimeSpent = table.Column<DateTime>(nullable: false),
                    EstStartDate = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labour", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Labour_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hours = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    LabourID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Task_Labour_LabourID",
                        column: x => x.LabourID,
                        principalSchema: "MC",
                        principalTable: "Labour",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityID",
                schema: "MC",
                table: "Clients",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Labour_ProjectID",
                schema: "MC",
                table: "Labour",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_LabourID",
                schema: "MC",
                table: "Task",
                column: "LabourID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients",
                column: "CityID",
                principalSchema: "MC",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "City",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Task",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Labour",
                schema: "MC");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CityID",
                schema: "MC",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CityID",
                schema: "MC",
                table: "Clients");
        }
    }
}
