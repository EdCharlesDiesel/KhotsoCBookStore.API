using Microsoft.EntityFrameworkCore.Migrations;

namespace KhotsoCBookStore.API.Migrations
{
    public partial class ChangedTheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionItems_Subscriptions_ProductSubscriptionId",
                table: "SubscriptionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_UserMasters_UserId",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_UserId",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionItems_ProductSubscriptionId",
                table: "SubscriptionItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_UserId",
                table: "UserTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItems_ProductSubscriptionId",
                table: "SubscriptionItems",
                column: "ProductSubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionItems_Subscriptions_ProductSubscriptionId",
                table: "SubscriptionItems",
                column: "ProductSubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "ProductSubscriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_UserMasters_UserId",
                table: "UserTypes",
                column: "UserId",
                principalTable: "UserMasters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
