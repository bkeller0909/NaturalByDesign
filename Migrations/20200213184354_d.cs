using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Material_MaterialID",
                schema: "MC",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Labour_Projects_ProjectID",
                schema: "MC",
                table: "Labour");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_Employee_EmployeeID",
                schema: "MC",
                table: "ProjectEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMaterials_Material_MaterialID",
                schema: "MC",
                table: "ProjectMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employee_DesignerID",
                schema: "MC",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Labour_LabourID",
                schema: "MC",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                schema: "MC",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                schema: "MC",
                table: "Material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labour",
                schema: "MC",
                table: "Labour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                schema: "MC",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                schema: "MC",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Task",
                schema: "MC",
                newName: "Tasks",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Material",
                schema: "MC",
                newName: "Materials",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Labour",
                schema: "MC",
                newName: "Labours",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Inventory",
                schema: "MC",
                newName: "Inventories",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Employee",
                schema: "MC",
                newName: "Employees",
                newSchema: "MC");

            migrationBuilder.RenameIndex(
                name: "IX_Task_LabourID",
                schema: "MC",
                table: "Tasks",
                newName: "IX_Tasks_LabourID");

            migrationBuilder.RenameIndex(
                name: "IX_Labour_ProjectID",
                schema: "MC",
                table: "Labours",
                newName: "IX_Labours_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_MaterialID",
                schema: "MC",
                table: "Inventories",
                newName: "IX_Inventories_MaterialID");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Postal",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ConLast",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ConFirst",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                schema: "MC",
                table: "Tasks",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                schema: "MC",
                table: "Materials",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labours",
                schema: "MC",
                table: "Labours",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                schema: "MC",
                table: "Inventories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                schema: "MC",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Materials_MaterialID",
                schema: "MC",
                table: "Inventories",
                column: "MaterialID",
                principalSchema: "MC",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labours_Projects_ProjectID",
                schema: "MC",
                table: "Labours",
                column: "ProjectID",
                principalSchema: "MC",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                schema: "MC",
                table: "ProjectEmployees",
                column: "EmployeeID",
                principalSchema: "MC",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialID",
                schema: "MC",
                table: "ProjectMaterials",
                column: "MaterialID",
                principalSchema: "MC",
                principalTable: "Materials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_DesignerID",
                schema: "MC",
                table: "Projects",
                column: "DesignerID",
                principalSchema: "MC",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Labours_LabourID",
                schema: "MC",
                table: "Tasks",
                column: "LabourID",
                principalSchema: "MC",
                principalTable: "Labours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Materials_MaterialID",
                schema: "MC",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Labours_Projects_ProjectID",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                schema: "MC",
                table: "ProjectEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMaterials_Materials_MaterialID",
                schema: "MC",
                table: "ProjectMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_DesignerID",
                schema: "MC",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Labours_LabourID",
                schema: "MC",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                schema: "MC",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                schema: "MC",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labours",
                schema: "MC",
                table: "Labours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                schema: "MC",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                schema: "MC",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Tasks",
                schema: "MC",
                newName: "Task",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Materials",
                schema: "MC",
                newName: "Material",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Labours",
                schema: "MC",
                newName: "Labour",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Inventories",
                schema: "MC",
                newName: "Inventory",
                newSchema: "MC");

            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "MC",
                newName: "Employee",
                newSchema: "MC");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_LabourID",
                schema: "MC",
                table: "Task",
                newName: "IX_Task_LabourID");

            migrationBuilder.RenameIndex(
                name: "IX_Labours_ProjectID",
                schema: "MC",
                table: "Labour",
                newName: "IX_Labour_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_MaterialID",
                schema: "MC",
                table: "Inventory",
                newName: "IX_Inventory_MaterialID");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                schema: "MC",
                table: "Clients",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Postal",
                schema: "MC",
                table: "Clients",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "MC",
                table: "Clients",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConLast",
                schema: "MC",
                table: "Clients",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConFirst",
                schema: "MC",
                table: "Clients",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "MC",
                table: "Clients",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                schema: "MC",
                table: "Task",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                schema: "MC",
                table: "Material",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labour",
                schema: "MC",
                table: "Labour",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                schema: "MC",
                table: "Inventory",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                schema: "MC",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Material_MaterialID",
                schema: "MC",
                table: "Inventory",
                column: "MaterialID",
                principalSchema: "MC",
                principalTable: "Material",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labour_Projects_ProjectID",
                schema: "MC",
                table: "Labour",
                column: "ProjectID",
                principalSchema: "MC",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_Employee_EmployeeID",
                schema: "MC",
                table: "ProjectEmployees",
                column: "EmployeeID",
                principalSchema: "MC",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMaterials_Material_MaterialID",
                schema: "MC",
                table: "ProjectMaterials",
                column: "MaterialID",
                principalSchema: "MC",
                principalTable: "Material",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employee_DesignerID",
                schema: "MC",
                table: "Projects",
                column: "DesignerID",
                principalSchema: "MC",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Labour_LabourID",
                schema: "MC",
                table: "Task",
                column: "LabourID",
                principalSchema: "MC",
                principalTable: "Labour",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
