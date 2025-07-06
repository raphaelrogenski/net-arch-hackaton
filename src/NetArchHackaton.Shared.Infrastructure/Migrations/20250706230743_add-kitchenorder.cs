using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetArchHackaton.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addkitchenorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "KitchenOrders",
                schema: "dbo",
                newName: "KitchenOrders",
                newSchema: "order");

            migrationBuilder.AddColumn<Guid>(
                name: "IdHandledBy",
                schema: "order",
                table: "KitchenOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdOrder",
                schema: "order",
                table: "KitchenOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "order",
                table: "KitchenOrders",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "order",
                table: "KitchenOrders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_KitchenOrders_IdHandledBy",
                schema: "order",
                table: "KitchenOrders",
                column: "IdHandledBy");

            migrationBuilder.CreateIndex(
                name: "IX_KitchenOrders_IdOrder",
                schema: "order",
                table: "KitchenOrders",
                column: "IdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_KitchenOrders_Orders",
                schema: "order",
                table: "KitchenOrders",
                column: "IdOrder",
                principalSchema: "order",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KitchenOrders_Users",
                schema: "order",
                table: "KitchenOrders",
                column: "IdHandledBy",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitchenOrders_Orders",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_KitchenOrders_Users",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.DropIndex(
                name: "IX_KitchenOrders_IdHandledBy",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.DropIndex(
                name: "IX_KitchenOrders_IdOrder",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.DropColumn(
                name: "IdHandledBy",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "order",
                table: "KitchenOrders");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "KitchenOrders",
                schema: "order",
                newName: "KitchenOrders",
                newSchema: "dbo");
        }
    }
}
