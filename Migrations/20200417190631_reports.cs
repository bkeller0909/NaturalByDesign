using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstBID",
                schema: "MC",
                table: "BidReport",
                newName: "EstBid");

            migrationBuilder.RenameColumn(
                name: "Hours",
                schema: "MC",
                table: "BidReport",
                newName: "ActlHours");

            migrationBuilder.RenameColumn(
                name: "Costs",
                schema: "MC",
                table: "BidReport",
                newName: "ActlCosts");

            migrationBuilder.CreateTable(
                name: "ProductionReports",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualCost = table.Column<int>(nullable: false),
                    EstCost = table.Column<int>(nullable: false),
                    TotalCost = table.Column<int>(nullable: false),
                    ActualMtlCost = table.Column<int>(nullable: false),
                    EstMtlCost = table.Column<int>(nullable: false),
                    ActualLabourProdCost = table.Column<int>(nullable: false),
                    EstLabourProdCost = table.Column<int>(nullable: false),
                    ActualDesignCost = table.Column<int>(nullable: false),
                    EstDesignCost = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionReports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductionReports_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionWorkReports",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Submitter = table.Column<string>(maxLength: 50, nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionWorkReports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductionWorkReports_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionReports_ProjectID",
                schema: "MC",
                table: "ProductionReports",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionWorkReports_ProjectID",
                schema: "MC",
                table: "ProductionWorkReports",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionReports",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "ProductionWorkReports",
                schema: "MC");

            migrationBuilder.RenameColumn(
                name: "EstBid",
                schema: "MC",
                table: "BidReport",
                newName: "EstBID");

            migrationBuilder.RenameColumn(
                name: "ActlHours",
                schema: "MC",
                table: "BidReport",
                newName: "Hours");

            migrationBuilder.RenameColumn(
                name: "ActlCosts",
                schema: "MC",
                table: "BidReport",
                newName: "Costs");
        }
    }
}
