using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyAddedInEmployeeProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeProfiles_EmployeeProfileId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeProfileId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProfiles_EmployeeId",
                table: "EmployeeProfiles",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProfiles_Employees_EmployeeId",
                table: "EmployeeProfiles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProfiles_Employees_EmployeeId",
                table: "EmployeeProfiles");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeProfiles_EmployeeId",
                table: "EmployeeProfiles");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeProfileId",
                table: "Employees",
                column: "EmployeeProfileId",
                unique: true,
                filter: "[EmployeeProfileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeProfiles_EmployeeProfileId",
                table: "Employees",
                column: "EmployeeProfileId",
                principalTable: "EmployeeProfiles",
                principalColumn: "Id");
        }
    }
}
