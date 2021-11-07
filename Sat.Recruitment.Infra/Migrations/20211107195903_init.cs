using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sat.Recruitment.Infra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    LastModificationAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("ba6f8779-b4f2-4a8c-a0d8-2a4b64324d50"), "Peru 2464", "Seed Initial Data", null, "Juan@marmol.com", false, new DateTime(2021, 11, 7, 16, 59, 3, 385, DateTimeKind.Unspecified).AddTicks(3758), 1234m, "Juan", "+5491154762312", null, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("b079b96b-0cd5-4dd2-ae81-46f402827962"), "Alvear y Colombres", "Seed Initial Data", null, "Franco.Perez@gmail.com", false, new DateTime(2021, 11, 7, 16, 59, 3, 387, DateTimeKind.Unspecified).AddTicks(5735), 112234m, "Franco", "+534645213542", null, "Premium" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreateBy", "DeleteBy", "Email", "IsDelete", "LastModificationAt", "Money", "Name", "Phone", "UpdateBy", "UserType" },
                values: new object[] { new Guid("086e013d-f9fc-464f-b939-e370e3945d1c"), "Garay y Otra Calle", "Seed Initial Data", null, "Agustina@gmail.com", false, new DateTime(2021, 11, 7, 16, 59, 3, 387, DateTimeKind.Unspecified).AddTicks(5972), 112234m, "Agustina", "+534645213542", null, "SuperUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
