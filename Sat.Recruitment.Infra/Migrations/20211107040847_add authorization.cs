using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sat.Recruitment.Infra.Migrations
{
    public partial class addauthorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("497b7118-dd73-42b7-bb72-6bd558783a53"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("df7cebf2-05f1-4780-bb5f-9266c6b0342b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e5bf082e-c1d8-4bb5-98b5-6960bcf9af35"));

            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("cc4f48d0-6b2d-48f9-afe2-497f9d3110f8"), "Peru 2464", "Seed Initial Data", null, "Juan@marmol.com", false, new DateTime(2021, 11, 7, 1, 8, 46, 410, DateTimeKind.Unspecified).AddTicks(9965), 1234m, "Juan", "+5491154762312", null, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("d903dd95-3f0b-4e90-ac57-93c905912cf3"), "Alvear y Colombres", "Seed Initial Data", null, "Franco.Perez@gmail.com", false, new DateTime(2021, 11, 7, 1, 8, 46, 413, DateTimeKind.Unspecified).AddTicks(4801), 112234m, "Franco", "+534645213542", null, "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("2939eea0-af9f-43d1-9c35-4e897fb68401"), "Garay y Otra Calle", "Seed Initial Data", null, "Agustina@gmail.com", false, new DateTime(2021, 11, 7, 1, 8, 46, 413, DateTimeKind.Unspecified).AddTicks(5184), 112234m, "Agustina", "+534645213542", null, "SuperUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2939eea0-af9f-43d1-9c35-4e897fb68401"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cc4f48d0-6b2d-48f9-afe2-497f9d3110f8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d903dd95-3f0b-4e90-ac57-93c905912cf3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("497b7118-dd73-42b7-bb72-6bd558783a53"), "Peru 2464", "Seed Initial Data", null, "Juan@marmol.com", false, new DateTime(2021, 11, 7, 0, 13, 14, 447, DateTimeKind.Unspecified).AddTicks(774), 1234m, "Juan", "+5491154762312", null, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("df7cebf2-05f1-4780-bb5f-9266c6b0342b"), "Alvear y Colombres", "Seed Initial Data", null, "Franco.Perez@gmail.com", false, new DateTime(2021, 11, 7, 0, 13, 14, 451, DateTimeKind.Unspecified).AddTicks(3980), 112234m, "Franco", "+534645213542", null, "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("e5bf082e-c1d8-4bb5-98b5-6960bcf9af35"), "Garay y Otra Calle", "Seed Initial Data", null, "Agustina@gmail.com", false, new DateTime(2021, 11, 7, 0, 13, 14, 451, DateTimeKind.Unspecified).AddTicks(5547), 112234m, "Agustina", "+534645213542", null, "SuperUser" });
        }
    }
}
