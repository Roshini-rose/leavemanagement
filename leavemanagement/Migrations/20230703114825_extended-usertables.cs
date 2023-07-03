using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace leavemanagement.Migrations
{
    /// <inheritdoc />
    public partial class extendedusertables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datejoined",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateofbirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "taxid",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datejoined",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "dateofbirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "taxid",
                table: "AspNetUsers");
        }
    }
}
