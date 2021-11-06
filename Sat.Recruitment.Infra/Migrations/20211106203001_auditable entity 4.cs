using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sat.Recruitment.Infra.Migrations
{
    public partial class auditableentity4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("eea4a05c-35cd-43dc-8c49-1f25441ce834"), "Peru 2464", "Seed Initial Data", null, "Juan@marmol.com", false, new DateTime(2021, 11, 6, 17, 30, 1, 219, DateTimeKind.Unspecified).AddTicks(7518), 1234m, "Juan", "+5491154762312", null, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("abfa59d3-f3fe-4df7-b52e-dbf9429d1b2e"), "Alvear y Colombres", "Seed Initial Data", null, "Franco.Perez@gmail.com", false, new DateTime(2021, 11, 6, 17, 30, 1, 222, DateTimeKind.Unspecified).AddTicks(3789), 112234m, "Franco", "+534645213542", null, "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("ab3f73a6-8244-4c1c-beae-021161e1ec82"), "Garay y Otra Calle", "Seed Initial Data", null, "Agustina@gmail.com", false, new DateTime(2021, 11, 6, 17, 30, 1, 222, DateTimeKind.Unspecified).AddTicks(4082), 112234m, "Agustina", "+534645213542", null, "SuperUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ab3f73a6-8244-4c1c-beae-021161e1ec82"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abfa59d3-f3fe-4df7-b52e-dbf9429d1b2e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eea4a05c-35cd-43dc-8c49-1f25441ce834"));

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

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
    }
}
