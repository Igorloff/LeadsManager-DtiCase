using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Suburb",
                table: "Leads",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ContactLastName",
                table: "Leads",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "ContactFirstName",
                table: "Leads",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "Leads",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Leads",
                newName: "Suburb");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Leads",
                newName: "ContactLastName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Leads",
                newName: "ContactFirstName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Leads",
                newName: "ContactEmail");
        }
    }
}
