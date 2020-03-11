using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class prodreports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdReportID",
                schema: "MC",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdReportID",
                schema: "MC",
                table: "Labours",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProdReport",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdReport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProdReport_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ProdReportID",
                schema: "MC",
                table: "Materials",
                column: "ProdReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_ProdReportID",
                schema: "MC",
                table: "Labours",
                column: "ProdReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdReport_ProjectID",
                schema: "MC",
                table: "ProdReport",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labours_ProdReport_ProdReportID",
                schema: "MC",
                table: "Labours",
                column: "ProdReportID",
                principalSchema: "MC",
                principalTable: "ProdReport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_ProdReport_ProdReportID",
                schema: "MC",
                table: "Materials",
                column: "ProdReportID",
                principalSchema: "MC",
                principalTable: "ProdReport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labours_ProdReport_ProdReportID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_ProdReport_ProdReportID",
                schema: "MC",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "ProdReport",
                schema: "MC");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ProdReportID",
                schema: "MC",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Labours_ProdReportID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropColumn(
                name: "ProdReportID",
                schema: "MC",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ProdReportID",
                schema: "MC",
                table: "Labours");
        }
    }
}
