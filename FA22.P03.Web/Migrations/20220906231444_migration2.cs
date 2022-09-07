using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA22.P03.Web.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemListings_Items_ItemsId",
                table: "ItemListings");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemListings_ListingDto_ListingId",
                table: "ItemListings");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemListings_ProductDto_ProductId",
                table: "ItemListings");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ProductDto_ProductId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ListingDto");

            migrationBuilder.DropTable(
                name: "ProductDto");

            migrationBuilder.DropIndex(
                name: "IX_ItemListings_ItemsId",
                table: "ItemListings");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "ItemListings");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ItemListings",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemListings_ProductId",
                table: "ItemListings",
                newName: "IX_ItemListings_itemId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemListings_Items_itemId",
                table: "ItemListings",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemListings_Listings_ListingId",
                table: "ItemListings",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemListings_Items_itemId",
                table: "ItemListings");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemListings_Listings_ListingId",
                table: "ItemListings");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "ItemListings",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemListings_itemId",
                table: "ItemListings",
                newName: "IX_ItemListings_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "ItemListings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListingDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemListings_ItemsId",
                table: "ItemListings",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemListings_Items_ItemsId",
                table: "ItemListings",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemListings_ListingDto_ListingId",
                table: "ItemListings",
                column: "ListingId",
                principalTable: "ListingDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemListings_ProductDto_ProductId",
                table: "ItemListings",
                column: "ProductId",
                principalTable: "ProductDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ProductDto_ProductId",
                table: "Items",
                column: "ProductId",
                principalTable: "ProductDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
