using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActualCost",
                schema: "MC",
                table: "ProductionReports",
                newName: "BidCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BidCost",
                schema: "MC",
                table: "ProductionReports",
                newName: "ActualCost");
        }
    }
}
