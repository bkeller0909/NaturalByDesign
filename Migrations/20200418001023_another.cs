using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class another : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlueprintCode",
                schema: "MC",
                table: "Bids",
                newName: "BidID");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                schema: "MC",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DepartmentDescription = table.Column<string>(maxLength: 250, nullable: false),
                    ProductionID = table.Column<int>(nullable: false),
                    ProjectsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Projects_ProjectsID",
                        column: x => x.ProjectsID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamID",
                schema: "MC",
                table: "Employees",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ProjectsID",
                schema: "MC",
                table: "Teams",
                column: "ProjectsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamID",
                schema: "MC",
                table: "Employees",
                column: "TeamID",
                principalSchema: "MC",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "MC");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TeamID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "BidID",
                schema: "MC",
                table: "Bids",
                newName: "BlueprintCode");
        }
    }
}
