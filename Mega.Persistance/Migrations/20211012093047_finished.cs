using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mega.Persistance.Migrations
{
    public partial class finished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "cartId",
                table: "cartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2021, 10, 12, 13, 0, 47, 81, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2021, 10, 12, 13, 0, 47, 85, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2021, 10, 12, 13, 0, 47, 85, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_cartId",
                table: "cartItems",
                column: "cartId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_carts_cartId",
                table: "cartItems",
                column: "cartId",
                principalTable: "carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_carts_cartId",
                table: "cartItems");

            migrationBuilder.DropIndex(
                name: "IX_cartItems_cartId",
                table: "cartItems");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "cartId",
                table: "cartItems");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2021, 10, 9, 19, 44, 38, 879, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2021, 10, 9, 19, 44, 38, 883, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2021, 10, 9, 19, 44, 38, 883, DateTimeKind.Local).AddTicks(2591));
        }
    }
}
