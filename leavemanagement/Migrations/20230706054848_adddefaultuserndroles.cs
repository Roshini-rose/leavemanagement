using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace leavemanagement.Migrations
{
    /// <inheritdoc />
    public partial class adddefaultuserndroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datemodified",
                table: "leavetypes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datecreated",
                table: "leavetypes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datemodified",
                table: "leaveallocations",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datecreated",
                table: "leaveallocations",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateofbirth",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datejoined",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b8fae543-5c87-4952-a10e-14f6cea432eb", "7231067c-52f3-4989-ac81-93ebe079903c", "Administrator", "ADMINISTRATOR" },
                    { "c7fad533-5d87-4952-a91e-14d6cea462ea", "0e123445-96f1-4038-a95f-e2432fe447fa", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "datejoined", "dateofbirth", "firstname", "lastname", "taxid" },
                values: new object[,]
                {
                    { "d5fad533-5c87-5952-a90e-24f6cea432ea", 0, "ab489c72-de5d-43ba-804c-052253782f7a", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "admin@localhost.com", "AQAAAAEAACcQAAAAEFpQ5Lf3lTxcvyjpZksSaaV0nGVBM0qJ8apmyIJhciNl51HB9V2rmlNrTxU/Poq0NQ==", null, false, "c95c4a66-3c15-465c-9110-c7b4ca5c2bc1", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Admin", null },
                    { "e5dad533-5c87-5952-a90e-24f6cea432ea", 0, "5e3722ec-6586-4149-a596-daff42242947", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "user@localhost.com", "AQAAAAEAACcQAAAAEF8MBI6Gh/I/YJbgD9eVebfup7/K4QCz734jpszDOPNWqUEAGCEgYvpNxmgsmBNHMw==", null, false, "4cfa88e6-e9a5-4508-95fb-e546786d6e05", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b8fae543-5c87-4952-a10e-14f6cea432eb", "d5fad533-5c87-5952-a90e-24f6cea432ea" },
                    { "c7fad533-5d87-4952-a91e-14d6cea462ea", "e5dad533-5c87-5952-a90e-24f6cea432ea" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b8fae543-5c87-4952-a10e-14f6cea432eb", "d5fad533-5c87-5952-a90e-24f6cea432ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7fad533-5d87-4952-a91e-14d6cea462ea", "e5dad533-5c87-5952-a90e-24f6cea432ea" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8fae543-5c87-4952-a10e-14f6cea432eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7fad533-5d87-4952-a91e-14d6cea462ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5fad533-5c87-5952-a90e-24f6cea432ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5dad533-5c87-5952-a90e-24f6cea432ea");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datemodified",
                table: "leavetypes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datecreated",
                table: "leavetypes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datemodified",
                table: "leaveallocations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datecreated",
                table: "leaveallocations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateofbirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datejoined",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
