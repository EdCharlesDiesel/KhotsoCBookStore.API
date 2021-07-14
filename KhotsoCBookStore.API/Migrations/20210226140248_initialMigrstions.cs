using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhotsoCBookStore.API.Migrations
{
    public partial class initialMigrstions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Wishlist__171E21A16A5148A4",
                table: "WishlistItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__UserMast__1788CCAC2694A2ED",
                table: "UserMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BookSubId",
                table: "BookSubscriptions");

            migrationBuilder.DeleteData(
                table: "BookSubscriptions",
                keyColumn: "BookSubId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookSubscriptions",
                keyColumn: "BookSubId",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookSubscriptions",
                keyColumn: "BookSubId",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "BookSubId",
                table: "BookSubscriptions");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "BookSubscriptions");

            migrationBuilder.DropColumn(
                name: "CoverFileName",
                table: "BookSubscriptions");

            migrationBuilder.RenameTable(
                name: "BookSubscriptions",
                newName: "BookSubscription");

            migrationBuilder.AddColumn<string>(
                name: "BookSubscriptionId",
                table: "BookSubscription",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BookSubscription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK__WishlistItemId",
                table: "WishlistItems",
                column: "WishlistItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__UserMasterID",
                table: "UserMaster",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BookSubscriptionId",
                table: "BookSubscription",
                column: "BookSubscriptionId");

            migrationBuilder.CreateTable(
                name: "BookSubscriptionItems",
                columns: table => new
                {
                    BookSubscriptionItemId = table.Column<int>(type: "int", unicode: false, maxLength: 36, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookSubscriptionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BookSubscriptionItemId", x => x.BookSubscriptionItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSubscriptionItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__WishlistItemId",
                table: "WishlistItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK__UserMasterID",
                table: "UserMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BookSubscriptionId",
                table: "BookSubscription");

            migrationBuilder.DropColumn(
                name: "BookSubscriptionId",
                table: "BookSubscription");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BookSubscription");

            migrationBuilder.RenameTable(
                name: "BookSubscription",
                newName: "BookSubscriptions");

            migrationBuilder.AddColumn<int>(
                name: "BookSubId",
                table: "BookSubscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "BookSubscriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverFileName",
                table: "BookSubscriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Wishlist__171E21A16A5148A4",
                table: "WishlistItems",
                column: "WishlistItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__UserMast__1788CCAC2694A2ED",
                table: "UserMaster",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__BookSubId",
                table: "BookSubscriptions",
                column: "BookSubId");

            migrationBuilder.InsertData(
                table: "BookSubscriptions",
                columns: new[] { "BookSubId", "BookName", "CoverFileName", "UserID" },
                values: new object[] { 1, "Webdevelopment-101", "Default_image", 1 });

            migrationBuilder.InsertData(
                table: "BookSubscriptions",
                columns: new[] { "BookSubId", "BookName", "CoverFileName", "UserID" },
                values: new object[] { 2, "Webdevelopment-102", "Default_image", 1 });

            migrationBuilder.InsertData(
                table: "BookSubscriptions",
                columns: new[] { "BookSubId", "BookName", "CoverFileName", "UserID" },
                values: new object[] { 3, "Webdevelopment-103", "Default_image", 1 });
        }
    }
}
