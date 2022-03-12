using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhotsoCBookStore.API.Migrations
{
    public partial class Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserMaster",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserMaster");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserMaster",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserMaster",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "UserMaster",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserMaster",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserMaster");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserMaster",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserMaster",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserMaster",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "UserID", "EmailAddress", "FirstName", "LastName", "Password", "UserTypeID", "Username" },
                values: new object[] { 1, "Mokhetkc@hotmail.com", "Khotso", "Mokhethi", "IamBatman", 1, "Batman" });
        }
    }
}
