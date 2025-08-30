using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFalTracker.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateDB_1708 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseDetail_Exercises_ExerciseId",
                table: "ExerciseDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseDetail",
                table: "ExerciseDetail");

            migrationBuilder.RenameTable(
                name: "ExerciseDetail",
                newName: "ExerciseDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseDetail_ExerciseId",
                table: "ExerciseDetails",
                newName: "IX_ExerciseDetails_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseDetails",
                table: "ExerciseDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseDetails_Exercises_ExerciseId",
                table: "ExerciseDetails",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseDetails_Exercises_ExerciseId",
                table: "ExerciseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseDetails",
                table: "ExerciseDetails");

            migrationBuilder.RenameTable(
                name: "ExerciseDetails",
                newName: "ExerciseDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseDetails_ExerciseId",
                table: "ExerciseDetail",
                newName: "IX_ExerciseDetail_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseDetail",
                table: "ExerciseDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseDetail_Exercises_ExerciseId",
                table: "ExerciseDetail",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
