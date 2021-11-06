using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sat.Recruitment.Infra.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
