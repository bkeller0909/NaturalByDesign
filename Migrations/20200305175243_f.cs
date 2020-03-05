using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialID",
                schema: "MC",
                table: "ProjectMaterials");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_MaterialID",
                schema: "MC",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "MaterialID",
                schema: "MC",
                table: "ProjectMaterials",
                newName: "InventoryID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMaterials_MaterialID",
                schema: "MC",
                table: "ProjectMaterials",
                newName: "IX_ProjectMaterials_InventoryID");

            migrationBuilder.AddColumn<string>(
                name: "CurrentPhase",
                schema: "MC",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_MaterialID",
                schema: "MC",
                table: "Inventories",
                column: "MaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMaterials_Inventories_InventoryID",
                schema: "MC",
                table: "ProjectMaterials",
                column: "InventoryID",
                principalSchema: "MC",
                principalTable: "Inventories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMaterials_Inventories_InventoryID",
                schema: "MC",
                table: "ProjectMaterials");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_MaterialID",
                schema: "MC",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CurrentPhase",
                schema: "MC",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "InventoryID",
                schema: "MC",
                table: "ProjectMaterials",
                newName: "MaterialID");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectMaterials_InventoryID",
                schema: "MC",
                table: "ProjectMaterials",
                newName: "IX_ProjectMaterials_MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_MaterialID",
                schema: "MC",
                table: "Inventories",
                column: "MaterialID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialID",
                schema: "MC",
                table: "ProjectMaterials",
                column: "MaterialID",
                principalSchema: "MC",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
