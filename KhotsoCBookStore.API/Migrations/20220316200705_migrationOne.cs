using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhotsoCBookStore.API.Migrations
{
    public partial class migrationOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ababa362-26f4-47b2-a434-bf657dc99136"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("8c0e5d87-e6be-4c9f-8f30-c7af35633efe"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("b1b6c41c-ba66-439e-988e-2602fbfb43a6"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DateOfBirth", "DateOfEndEmployment", "DateOfStartEmployment", "EmployeeNumber", "FirstName", "LastName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("77a48918-e1e8-4e1a-9784-a1fc2d843339"), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMP-001", "Khotso", "Mokhethi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CartTotal", "CreatedBy", "CreatedOn", "CustomerId", "OrderDate", "ShipAddress", "ShipDate", "UpdatedBy", "UpdatedOn", "UserID" },
                values: new object[] { new Guid("d0d99b73-eade-4ab2-ba6e-8aed04165a15"), 15.44m, "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("feb6f8d2-a51a-4ec6-8812-71a2c1819601"), new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), "Mandela Street Sandton Drive", new DateTime(2022, 3, 16, 22, 7, 3, 101, DateTimeKind.Local).AddTicks(1661), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CartTotal", "CreatedBy", "CreatedOn", "CustomerId", "OrderDate", "ShipAddress", "ShipDate", "UpdatedBy", "UpdatedOn", "UserID" },
                values: new object[] { new Guid("80ae8a60-15f1-4271-baeb-68353e6ce6f8"), 15.44m, "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("300f030a-8226-40a0-95f5-52d55b4242d6"), new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), "Mandela Street Sandton Drive", new DateTime(2022, 3, 16, 22, 7, 3, 101, DateTimeKind.Local).AddTicks(2922), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("77a48918-e1e8-4e1a-9784-a1fc2d843339"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("80ae8a60-15f1-4271-baeb-68353e6ce6f8"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("d0d99b73-eade-4ab2-ba6e-8aed04165a15"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DateOfBirth", "DateOfEndEmployment", "DateOfStartEmployment", "EmployeeNumber", "FirstName", "LastName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("ababa362-26f4-47b2-a434-bf657dc99136"), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMP-001", "Khotso", "Mokhethi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CartTotal", "CreatedBy", "CreatedOn", "CustomerId", "OrderDate", "ShipAddress", "ShipDate", "UpdatedBy", "UpdatedOn", "UserID" },
                values: new object[] { new Guid("b1b6c41c-ba66-439e-988e-2602fbfb43a6"), 15.44m, "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("feb6f8d2-a51a-4ec6-8812-71a2c1819601"), new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), "Mandela Street Sandton Drive", new DateTime(2022, 3, 17, 2, 46, 17, 424, DateTimeKind.Local).AddTicks(8681), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CartTotal", "CreatedBy", "CreatedOn", "CustomerId", "OrderDate", "ShipAddress", "ShipDate", "UpdatedBy", "UpdatedOn", "UserID" },
                values: new object[] { new Guid("8c0e5d87-e6be-4c9f-8f30-c7af35633efe"), 15.44m, "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("300f030a-8226-40a0-95f5-52d55b4242d6"), new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), "Mandela Street Sandton Drive", new DateTime(2022, 3, 17, 2, 46, 17, 425, DateTimeKind.Local).AddTicks(70), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
