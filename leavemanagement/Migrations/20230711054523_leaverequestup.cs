using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace leavemanagement.Migrations
{
    /// <inheritdoc />
    public partial class leaverequestup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "requestcomments",
                table: "leaverequests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "period",
                table: "leaveallocations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8fae543-5c87-4952-a10e-14f6cea432eb",
                column: "ConcurrencyStamp",
                value: "189dd990-35ab-4c2a-8f3c-4943a19af5b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7fad533-5d87-4952-a91e-14d6cea462ea",
                column: "ConcurrencyStamp",
                value: "ecda4e9b-f69b-40e9-ad00-5ef06f6296a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5fad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8622174-3172-4acf-b803-63757e7119ae", "AQAAAAEAACcQAAAAEB9CZaWBaXqimVpKDZHHEf8vCo73wJIZXkoQ9NXhwHY0Hw0uaGBniy/TQOYykCw1lw==", "4a12f233-5283-43fb-b4a2-16fa3bc64c8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5dad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1be68158-5381-41fb-9266-c39adb2bafbe", "AQAAAAEAACcQAAAAEF06ceD+D/dv0SivMY+Fr1AXnWNR5Icvg6ftdjmbO92FTMTL1p2b11HRt8V16/VLJQ==", "0e37e965-847f-46be-bcf4-170182946640" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "period",
                table: "leaveallocations");

            migrationBuilder.AlterColumn<string>(
                name: "requestcomments",
                table: "leaverequests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8fae543-5c87-4952-a10e-14f6cea432eb",
                column: "ConcurrencyStamp",
                value: "09718aac-8e9b-4d37-aba2-d7f99f664507");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7fad533-5d87-4952-a91e-14d6cea462ea",
                column: "ConcurrencyStamp",
                value: "376fac6f-3c41-4341-8c25-c8adb8343f52");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5fad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff16469-5b5c-44e5-bf38-891602796639", "AQAAAAEAACcQAAAAELJ/ekLrQYPewL4UQ7GYwj4ygpQDGFMUYac+7EY6j6BXm8is0el1nF5Usdcf2AlfbA==", "ee17673c-b776-48a5-8666-3d8f0ba8150e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5dad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41c4292c-0027-4c7a-afed-9aee60275d63", "AQAAAAEAACcQAAAAEJ0LoLEHMxS0hnhF62DO9lWYllopK6WXppN++63RqTtT2OQTAhQ3icfHRN5/eCvMOQ==", "b8c09eb7-7a6b-4010-a50b-78675b6d4b03" });
        }
    }
}
