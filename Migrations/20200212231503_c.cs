using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                schema: "MC",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "MC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                schema: "MC",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => new { x.ProjectID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "MC",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvgNetPrice = table.Column<double>(nullable: false),
                    ListPrice = table.Column<double>(nullable: false),
                    SizeValue = table.Column<int>(nullable: false),
                    SizeUnit = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    MaterialID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventory_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalSchema: "MC",
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMaterials",
                schema: "MC",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    MaterialID = table.Column<int>(nullable: false),
                    MatDelivery = table.Column<DateTime>(nullable: false),
                    MatInstall = table.Column<DateTime>(nullable: false),
                    MatEstQty = table.Column<int>(nullable: false),
                    MatActQty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMaterials", x => new { x.ProjectID, x.MaterialID });
                    table.ForeignKey(
                        name: "FK_ProjectMaterials_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalSchema: "MC",
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMaterials_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DesignerID",
                schema: "MC",
                table: "Projects",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_MaterialID",
                schema: "MC",
                table: "Inventory",
                column: "MaterialID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeID",
                schema: "MC",
                table: "ProjectEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMaterials_MaterialID",
                schema: "MC",
                table: "ProjectMaterials",
                column: "MaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employee_DesignerID",
                schema: "MC",
                table: "Projects",
                column: "DesignerID",
                principalSchema: "MC",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employee_DesignerID",
                schema: "MC",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "ProjectEmployees",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "ProjectMaterials",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Material",
                schema: "MC");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DesignerID",
                schema: "MC",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                schema: "MC",
                table: "Projects");
        }
    }
}
