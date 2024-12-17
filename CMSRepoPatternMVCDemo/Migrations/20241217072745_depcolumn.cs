using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSRepoPatternMVCDemo.Migrations
{
    /// <inheritdoc />
    public partial class depcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Alter the column to allow NULL values
            migrationBuilder.AlterColumn<int>(
                name: "DepId",
                table: "EmployeeTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // Ensure that invalid DepId references are set to NULL
            migrationBuilder.Sql(
                "UPDATE EmployeeTable SET DepId = NULL WHERE DepId IS NOT NULL AND DepId NOT IN (SELECT DepId FROM Departments)");

            // Add the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTable_Departments_DepId",
                table: "EmployeeTable",
                column: "DepId",
                principalTable: "Departments",
                principalColumn: "DepId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepId",
                table: "EmployeeTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            migrationBuilder.AddForeignKey(
          name: "FK_EmployeeTable_Departments_departmentDepId",
          table: "EmployeeTable",
          column: "departmentDepId",
          principalTable: "Departments",
          principalColumn: "DepId");
        }
    }
}
