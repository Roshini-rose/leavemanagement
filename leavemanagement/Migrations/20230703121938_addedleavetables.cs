using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace leavemanagement.Migrations
{
    /// <inheritdoc />
    public partial class addedleavetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leavetypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    defaultdays = table.Column<int>(type: "integer", nullable: false),
                    datecreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datemodified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leavetypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "leaveallocations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    noofdays = table.Column<int>(type: "integer", nullable: false),
                    leavetypeid = table.Column<int>(type: "integer", nullable: false),
                    employeeid = table.Column<string>(type: "text", nullable: false),
                    datecreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datemodified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveallocations", x => x.id);
                    table.ForeignKey(
                        name: "FK_leaveallocations_leavetypes_leavetypeid",
                        column: x => x.leavetypeid,
                        principalTable: "leavetypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaveallocations_leavetypeid",
                table: "leaveallocations",
                column: "leavetypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveallocations");

            migrationBuilder.DropTable(
                name: "leavetypes");
        }
    }
}
