using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace leavemanagement.Migrations
{
    /// <inheritdoc />
    public partial class addedleaverequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaverequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    leavetypeid = table.Column<int>(type: "integer", nullable: false),
                    daterequested = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    requestcomments = table.Column<string>(type: "text", nullable: false),
                    approved = table.Column<bool>(type: "boolean", nullable: true),
                    cancelled = table.Column<bool>(type: "boolean", nullable: false),
                    requestingemployeeid = table.Column<string>(type: "text", nullable: false),
                    datecreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    datemodified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaverequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_leaverequests_leavetypes_leavetypeid",
                        column: x => x.leavetypeid,
                        principalTable: "leavetypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_leaverequests_leavetypeid",
                table: "leaverequests",
                column: "leavetypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaverequests");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e4b04c-c316-4866-9338-e5998c4f138c", "AQAAAAEAACcQAAAAEANLzylyEwlCvrhn+0hso3B1OxEtJgTUsOnjuFpdTIh31h7nYWxP5UQhXN75JPE8Kg==", "2f3397d0-f410-4d3e-87f7-c03e5676500d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5dad533-5c87-5952-a90e-24f6cea432ea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c73d6627-689f-4a06-abd9-3eedbd617c4d", "AQAAAAEAACcQAAAAEEv9n714qD1UY6fa+O7PKV8ojx8SzTHZSiZ8IeAzhVE0XHbb9oybopycrrB3wmIcaQ==", "c9549535-970e-4029-80a5-672ee325d751" });
        }
    }
}
