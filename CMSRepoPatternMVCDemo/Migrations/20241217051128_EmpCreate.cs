using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSRepoPatternMVCDemo.Migrations
{
    /// <inheritdoc />
    public partial class EmpCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "111, 1"),
                    DepName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTable",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Desig = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departmentDepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTable", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeTable_Departments_departmentDepId",
                        column: x => x.departmentDepId,
                        principalTable: "Departments",
                        principalColumn: "DepId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTable_departmentDepId",
                table: "EmployeeTable",
                column: "departmentDepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTable");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
