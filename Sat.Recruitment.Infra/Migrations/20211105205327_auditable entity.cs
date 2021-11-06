using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sat.Recruitment.Infra.Migrations
{
    public partial class auditableentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35cfc7c8-8171-4122-aff4-294ac7ff5602"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55c7dfaa-c47c-4234-86e5-928cf2d73037"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b7bc2331-811a-4688-ad1e-308f331a66a5"));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModificationAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Money", "Name", "Phone", "UserType" },
                values: new object[] { new Guid("35cfc7c8-8171-4122-aff4-294ac7ff5602"), "Peru 2464", "Juan@marmol.com", 1234m, "Juan", "+5491154762312", "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Money", "Name", "Phone", "UserType" },
                values: new object[] { new Guid("b7bc2331-811a-4688-ad1e-308f331a66a5"), "Alvear y Colombres", "Franco.Perez@gmail.com", 112234m, "Franco", "+534645213542", "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Money", "Name", "Phone", "UserType" },
                values: new object[] { new Guid("55c7dfaa-c47c-4234-86e5-928cf2d73037"), "Garay y Otra Calle", "Agustina@gmail.com", 112234m, "Agustina", "+534645213542", "SuperUser" });
        }
    }
}
