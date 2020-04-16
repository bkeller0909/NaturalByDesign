using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MC");

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    HourlyPay = table.Column<double>(nullable: false),
                    HourlyCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
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
                    table.PrimaryKey("PK_Materials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hours = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(nullable: false),
                    ResponsibilityType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Province = table.Column<string>(maxLength: 50, nullable: true),
                    Postal = table.Column<string>(maxLength: 15, nullable: true),
                    ConFirst = table.Column<string>(maxLength: 50, nullable: false),
                    ConLast = table.Column<string>(maxLength: 100, nullable: false),
                    ConPhone = table.Column<long>(nullable: false),
                    ConPosition = table.Column<string>(maxLength: 30, nullable: true),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityID",
                        column: x => x.CityID,
                        principalSchema: "MC",
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
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
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventories_Materials_MaterialID",
                        column: x => x.MaterialID,
                        principalSchema: "MC",
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Desc = table.Column<string>(maxLength: 100, nullable: false),
                    EstCost = table.Column<double>(nullable: false),
                    BidDate = table.Column<DateTime>(nullable: false),
                    EstStartDate = table.Column<DateTime>(nullable: false),
                    EstFinishDate = table.Column<DateTime>(nullable: false),
                    CurrentPhase = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    FinishDate = table.Column<DateTime>(nullable: true),
                    Cost = table.Column<double>(nullable: true),
                    BidCustApproved = table.Column<bool>(nullable: false),
                    BidManagementApproved = table.Column<bool>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    DesignerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalSchema: "MC",
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabourSummaries",
                schema: "MC",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    EmployeeTypeID = table.Column<int>(nullable: false),
                    Hours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourSummaries", x => new { x.ProjectID, x.EmployeeTypeID });
                    table.ForeignKey(
                        name: "FK_LabourSummaries_EmployeeTypes_EmployeeTypeID",
                        column: x => x.EmployeeTypeID,
                        principalSchema: "MC",
                        principalTable: "EmployeeTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourSummaries_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMaterials",
                schema: "MC",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    InventoryID = table.Column<int>(nullable: false),
                    MatDelivery = table.Column<DateTime>(nullable: false),
                    MatInstall = table.Column<DateTime>(nullable: false),
                    MatEstQty = table.Column<int>(nullable: false),
                    MatActQty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMaterials", x => new { x.ProjectID, x.InventoryID });
                    table.ForeignKey(
                        name: "FK_ProjectMaterials_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalSchema: "MC",
                        principalTable: "Inventories",
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

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "MC",
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmployeeTypeID = table.Column<int>(nullable: false),
                    ProjectEmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeID",
                        column: x => x.EmployeeTypeID,
                        principalSchema: "MC",
                        principalTable: "EmployeeTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_ProjectEmployees_ProjectEmployeeID",
                        column: x => x.ProjectEmployeeID,
                        principalSchema: "MC",
                        principalTable: "ProjectEmployees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Labours",
                schema: "MC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstStartDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EstHours = table.Column<int>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false),
                    TaskID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Labours_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalSchema: "MC",
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Labours_ProjectEmployees_TeamID",
                        column: x => x.TeamID,
                        principalSchema: "MC",
                        principalTable: "ProjectEmployees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityID",
                schema: "MC",
                table: "Clients",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeID",
                schema: "MC",
                table: "Employees",
                column: "EmployeeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectEmployeeID",
                schema: "MC",
                table: "Employees",
                column: "ProjectEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_MaterialID",
                schema: "MC",
                table: "Inventories",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_TaskID",
                schema: "MC",
                table: "Labours",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Labours_TeamID",
                schema: "MC",
                table: "Labours",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_LabourSummaries_EmployeeTypeID",
                schema: "MC",
                table: "LabourSummaries",
                column: "EmployeeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeID",
                schema: "MC",
                table: "ProjectEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_ProjectID",
                schema: "MC",
                table: "ProjectEmployees",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMaterials_InventoryID",
                schema: "MC",
                table: "ProjectMaterials",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                schema: "MC",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DesignerID",
                schema: "MC",
                table: "Projects",
                column: "DesignerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_DesignerID",
                schema: "MC",
                table: "Projects",
                column: "DesignerID",
                principalSchema: "MC",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                schema: "MC",
                table: "ProjectEmployees",
                column: "EmployeeID",
                principalSchema: "MC",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cities_CityID",
                schema: "MC",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProjectEmployees_ProjectEmployeeID",
                schema: "MC",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Labours",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "LabourSummaries",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "ProjectMaterials",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Inventories",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Materials",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "EmployeeTypes",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "ProjectEmployees",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "MC");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "MC");
        }
    }
}
