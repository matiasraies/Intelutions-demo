using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "request");

            migrationBuilder.CreateSequence(
                name: "permissionseq",
                schema: "request",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "permissiontypeseq",
                schema: "request",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "PermissionType",
                schema: "request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PermissionTypeId = table.Column<int>(nullable: false),
                    EmployeeLastName = table.Column<string>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: false),
                    PermissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionType_PermissionTypeId",
                        column: x => x.PermissionTypeId,
                        principalSchema: "request",
                        principalTable: "PermissionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionTypeId",
                schema: "request",
                table: "Permission",
                column: "PermissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission",
                schema: "request");

            migrationBuilder.DropTable(
                name: "PermissionType",
                schema: "request");

            migrationBuilder.DropSequence(
                name: "permissionseq",
                schema: "request");

            migrationBuilder.DropSequence(
                name: "permissiontypeseq",
                schema: "request");
        }
    }
}
