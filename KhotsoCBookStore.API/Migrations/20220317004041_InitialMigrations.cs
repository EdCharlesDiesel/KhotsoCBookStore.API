using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhotsoCBookStore.API.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("70d8ca38-3ff2-4c82-b0de-839c6596fe5e"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DateOfBirth", "DateOfEndEmployment", "DateOfStartEmployment", "EmployeeNumber", "FirstName", "LastName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("de355925-a93f-4931-b629-e4e2539e713a"), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMP-001", "Khotso", "Mokhethi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CartTotal", "CreatedBy", "CreatedOn", "CustomerId", "OrderDate", "ShipAddress", "ShipDate", "UpdatedBy", "UpdatedOn", "UserID" },
                values: new object[] { new Guid("b7369188-103b-4e3b-a481-fc609c11d6fb"), 15.44m, "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("feb6f8d2-a51a-4ec6-8812-71a2c1819601"), new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), "Mandela Street Sandton Drive", new DateTime(2022, 3, 17, 2, 40, 38, 700, DateTimeKind.Local).AddTicks(7243), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CartTotal", "CreatedBy", "CreatedOn", "CustomerId", "OrderDate", "ShipAddress", "ShipDate", "UpdatedBy", "UpdatedOn", "UserID" },
                values: new object[] { new Guid("f9ea5517-1653-4358-b439-f4a52757fd70"), 15.44m, "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("300f030a-8226-40a0-95f5-52d55b4242d6"), new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), "Mandela Street Sandton Drive", new DateTime(2022, 3, 17, 2, 40, 38, 700, DateTimeKind.Local).AddTicks(8557), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("de355925-a93f-4931-b629-e4e2539e713a"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("b7369188-103b-4e3b-a481-fc609c11d6fb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f9ea5517-1653-4358-b439-f4a52757fd70"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DateOfBirth", "DateOfEndEmployment", "DateOfStartEmployment", "EmployeeNumber", "FirstName", "LastName", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("70d8ca38-3ff2-4c82-b0de-839c6596fe5e"), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMP-001", "Khotso", "Mokhethi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
