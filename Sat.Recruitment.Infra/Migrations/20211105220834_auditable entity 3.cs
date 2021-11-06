using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sat.Recruitment.Infra.Migrations
{
    public partial class auditableentity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fe14cee-91b0-4086-a30d-984b151f58bc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6eacaca1-fea4-4e5c-9617-670c1cabead4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9e6b3753-7616-4c72-bf17-462a90452e7d"));

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("21903f91-5d5f-46cd-9f8a-227450b5f174"), "Peru 2464", "Seed Initial Data", null, "Juan@marmol.com", false, new DateTime(2021, 11, 5, 19, 8, 34, 362, DateTimeKind.Unspecified).AddTicks(4384), 1234m, "Juan", "+5491154762312", null, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("b4c69db4-417f-4230-8f06-1658a65c69f1"), "Alvear y Colombres", "Seed Initial Data", null, "Franco.Perez@gmail.com", false, new DateTime(2021, 11, 5, 19, 8, 34, 364, DateTimeKind.Unspecified).AddTicks(8087), 112234m, "Franco", "+534645213542", null, "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("f51fb033-9c50-4584-92b1-f0df39928968"), "Garay y Otra Calle", "Seed Initial Data", null, "Agustina@gmail.com", false, new DateTime(2021, 11, 5, 19, 8, 34, 364, DateTimeKind.Unspecified).AddTicks(8346), 112234m, "Agustina", "+534645213542", null, "SuperUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("21903f91-5d5f-46cd-9f8a-227450b5f174"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b4c69db4-417f-4230-8f06-1658a65c69f1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f51fb033-9c50-4584-92b1-f0df39928968"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "FirstName", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("1fe14cee-91b0-4086-a30d-984b151f58bc"), "Peru 2464", "Seed Initial Data", null, "Juan@marmol.com", false, new DateTime(2021, 11, 5, 19, 7, 23, 278, DateTimeKind.Unspecified).AddTicks(4321), 1234m, "Juan", "+5491154762312", null, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "FirstName", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("6eacaca1-fea4-4e5c-9617-670c1cabead4"), "Alvear y Colombres", "Seed Initial Data", null, "Franco.Perez@gmail.com", false, new DateTime(2021, 11, 5, 19, 7, 23, 280, DateTimeKind.Unspecified).AddTicks(7709), 112234m, "Franco", "+534645213542", null, "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "FirstName", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("9e6b3753-7616-4c72-bf17-462a90452e7d"), "Garay y Otra Calle", "Seed Initial Data", null, "Agustina@gmail.com", false, new DateTime(2021, 11, 5, 19, 7, 23, 280, DateTimeKind.Unspecified).AddTicks(7967), 112234m, "Agustina", "+534645213542", null, "SuperUser" });
        }
    }
}
