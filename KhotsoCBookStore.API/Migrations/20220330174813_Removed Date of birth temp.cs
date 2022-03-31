using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhotsoCBookStore.API.Migrations
{
    public partial class RemovedDateofbirthtemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "UserMasters");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "UserMasters",
                newName: "EmailAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeId",
                table: "UserMasters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "UserMasters");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "UserMasters",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "UserMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
