using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace leavemanagement.Migrations
{
    /// <inheritdoc />
    public partial class adddefaultuserndusernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8fae543-5c87-4952-a10e-14f6cea432eb",
                column: "ConcurrencyStamp",
                value: "a5b7b3b7-68b9-4008-8301-f5b693f90d0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7fad533-5d87-4952-a91e-14d6cea462ea",
                column: "ConcurrencyStamp",
                value: "bf96796d-ddd3-4829-91ca-d5f7a77bf8a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5fad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a6e4b04c-c316-4866-9338-e5998c4f138c", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEANLzylyEwlCvrhn+0hso3B1OxEtJgTUsOnjuFpdTIh31h7nYWxP5UQhXN75JPE8Kg==", "2f3397d0-f410-4d3e-87f7-c03e5676500d", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5dad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c73d6627-689f-4a06-abd9-3eedbd617c4d", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEEv9n714qD1UY6fa+O7PKV8ojx8SzTHZSiZ8IeAzhVE0XHbb9oybopycrrB3wmIcaQ==", "c9549535-970e-4029-80a5-672ee325d751", "user@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8fae543-5c87-4952-a10e-14f6cea432eb",
                column: "ConcurrencyStamp",
                value: "7231067c-52f3-4989-ac81-93ebe079903c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7fad533-5d87-4952-a91e-14d6cea462ea",
                column: "ConcurrencyStamp",
                value: "0e123445-96f1-4038-a95f-e2432fe447fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5fad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ab489c72-de5d-43ba-804c-052253782f7a", "admin@localhost.com", "AQAAAAEAACcQAAAAEFpQ5Lf3lTxcvyjpZksSaaV0nGVBM0qJ8apmyIJhciNl51HB9V2rmlNrTxU/Poq0NQ==", "c95c4a66-3c15-465c-9110-c7b4ca5c2bc1", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5dad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5e3722ec-6586-4149-a596-daff42242947", "user@localhost.com", "AQAAAAEAACcQAAAAEF8MBI6Gh/I/YJbgD9eVebfup7/K4QCz734jpszDOPNWqUEAGCEgYvpNxmgsmBNHMw==", "4cfa88e6-e9a5-4508-95fb-e546786d6e05", null });
        }
    }
}
