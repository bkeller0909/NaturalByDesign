using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class daily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesignBudget",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentHours = table.Column<int>(nullable: false),
                    EstHours = table.Column<int>(nullable: false),
                    HoursTotal = table.Column<int>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    Submitter = table.Column<string>(maxLength: 50, nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignBudget", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DesignBudget_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesignDay",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stage = table.Column<string>(maxLength: 1, nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    Task = table.Column<string>(maxLength: 250, nullable: false),
                    Submitter = table.Column<string>(maxLength: 50, nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DesignDay_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesignBudget_ProjectID",
                schema: "MC",
                table: "DesignBudget",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_DesignDay_ProjectID",
                schema: "MC",
                table: "DesignDay",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignBudget",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "DesignDay",
                schema: "MC");
        }
    }
}
