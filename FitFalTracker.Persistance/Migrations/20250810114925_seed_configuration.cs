using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFalTracker.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class seed_configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AppUsers",
                newName: "LastName");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Age", "Height", "Weight", "FirstName", "LastName" },
                values: new object[] { 1, 18, 182f, 1.2f, "Michael", "Patrick" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AppUsers",
                newName: "Surname");
        }
    }
}
