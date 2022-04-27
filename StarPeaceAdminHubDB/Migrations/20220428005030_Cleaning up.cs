using Microsoft.EntityFrameworkCore.Migrations;

namespace StarPeaceAdminHubDB.Migrations
{
    public partial class Cleaningup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EntityVersion",
                table: "Books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityVersion",
                table: "Books");
        }
    }
}
