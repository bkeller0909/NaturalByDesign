using Microsoft.EntityFrameworkCore.Migrations;

namespace NBDv2.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                schema: "MC",
                table: "City");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "MC",
                newName: "Cities",
                newSchema: "MC");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "MC",
                table: "Projects",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                schema: "MC",
                table: "Projects",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
                name: "ConPosition",
                schema: "MC",
                table: "Clients",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ConPhone",
                schema: "MC",
                table: "Clients",
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
                name: "PK_Cities",
                schema: "MC",
                table: "Cities",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Cities_CityID",
                schema: "MC",
                table: "Clients",
                column: "CityID",
                principalSchema: "MC",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cities_CityID",
                schema: "MC",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                schema: "MC",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "MC",
                newName: "City",
                newSchema: "MC");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "MC",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                schema: "MC",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

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
                name: "ConPosition",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConPhone",
                schema: "MC",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(long));

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
                name: "PK_City",
                schema: "MC",
                table: "City",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_City_CityID",
                schema: "MC",
                table: "Clients",
                column: "CityID",
                principalSchema: "MC",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
