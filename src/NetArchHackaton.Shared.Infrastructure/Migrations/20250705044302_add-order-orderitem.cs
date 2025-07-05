using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetArchHackaton.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addorderorderitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "dbo",
                newName: "Orders",
                newSchema: "order");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "dbo",
                newName: "OrderItems",
                newSchema: "order");

            migrationBuilder.AddColumn<string>(
                name: "CancelReason",
                schema: "order",
                table: "Orders",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DeliveryMethod",
                schema: "order",
                table: "Orders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<Guid>(
                name: "IdCustomer",
                schema: "order",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "order",
                table: "Orders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrder",
                schema: "order",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                schema: "order",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "order",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "order",
                table: "OrderItems",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCustomer",
                schema: "order",
                table: "Orders",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdOrder",
                schema: "order",
                table: "OrderItems",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdProduct",
                schema: "order",
                table: "OrderItems",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders",
                schema: "order",
                table: "OrderItems",
                column: "IdOrder",
                principalSchema: "order",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products",
                schema: "order",
                table: "OrderItems",
                column: "IdProduct",
                principalSchema: "menu",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users",
                schema: "order",
                table: "Orders",
                column: "IdCustomer",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users",
                schema: "order",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdCustomer",
                schema: "order",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_IdOrder",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_IdProduct",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CancelReason",
                schema: "order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                schema: "order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                schema: "order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "order",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "order",
                newName: "Orders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "order",
                newName: "OrderItems",
                newSchema: "dbo");
        }
    }
}
