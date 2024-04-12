using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestPermission.Api.Migrations
{
    /// <inheritdoc />
    public partial class employeePkError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_E_MANAGERID",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "E_MANAGERID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_E_MANAGERID",
                table: "Employees",
                column: "E_MANAGERID",
                principalTable: "Employees",
                principalColumn: "E_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_E_MANAGERID",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "E_MANAGERID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_E_MANAGERID",
                table: "Employees",
                column: "E_MANAGERID",
                principalTable: "Employees",
                principalColumn: "E_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
