using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sat.Recruitment.Infra.Migrations
{
    public partial class auditableentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d6a5262-4ff3-4bff-91d3-28bc9d05441c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8fbd6a2a-c571-486a-9fa6-093f36cdbe6c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a11b661a-f99c-4043-83ed-2459e0889ffd"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("6d6a5262-4ff3-4bff-91d3-28bc9d05441c"), "Peru 2464", null, null, "Juan@marmol.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234m, "Juan", "+5491154762312", null, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("a11b661a-f99c-4043-83ed-2459e0889ffd"), "Alvear y Colombres", null, null, "Franco.Perez@gmail.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112234m, "Franco", "+534645213542", null, "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("8fbd6a2a-c571-486a-9fa6-093f36cdbe6c"), "Garay y Otra Calle", null, null, "Agustina@gmail.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112234m, "Agustina", "+534645213542", null, "SuperUser" });
        }
    }
}
