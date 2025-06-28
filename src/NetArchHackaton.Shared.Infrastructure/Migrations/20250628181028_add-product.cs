using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetArchHackaton.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "menu");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "dbo",
                newName: "Products",
                newSchema: "menu");

            migrationBuilder.AlterColumn<short>(
                name: "Role",
                schema: "auth",
                table: "Users",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "menu",
                table: "Products",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "menu",
                table: "Products",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                schema: "menu",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "menu",
                table: "Products",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "menu",
                table: "Products",
                type: "decimal(10,2)",
                maxLength: 11,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "menu",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "menu",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                schema: "menu",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "menu",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "menu",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "auth",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "menu",
                newName: "Products",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "dbo",
                table: "Users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
