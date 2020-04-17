using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class chungus2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidReport",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstBID = table.Column<int>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    EstHours = table.Column<int>(nullable: false),
                    Costs = table.Column<int>(nullable: false),
                    EstCost = table.Column<int>(nullable: false),
                    HoursRemaining = table.Column<int>(nullable: false),
                    CostsRemaining = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidReport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BidReport_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlueprintCode = table.Column<string>(maxLength: 12, nullable: false),
                    EstStart = table.Column<DateTime>(nullable: false),
                    EstEnd = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvBids",
                schema: "MC",
                columns: table => new
                {
                    BidID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvBids", x => new { x.BidID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_InvBids_Bids_BidID",
                        column: x => x.BidID,
                        principalSchema: "MC",
                        principalTable: "Bids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidReport_ProjectID",
                schema: "MC",
                table: "BidReport",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectID",
                schema: "MC",
                table: "Bids",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidReport",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "InvBids",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Bids",
                schema: "MC");
        }
    }
}
