using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFalTracker.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateDB_1508 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Rir",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Rpe",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Tempo",
                table: "Exercises",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Sets",
                table: "Exercises",
                newName: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "AppUsers",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AppUsers",
                type: "date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BodyWeightEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightEnum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyWeightEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyWeightEntry_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    Rir = table.Column<int>(type: "int", nullable: true),
                    Rpe = table.Column<int>(type: "int", nullable: true),
                    Tempo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightEnum = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseDetail_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyWeightEntry_AppUserId",
                table: "BodyWeightEntry",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDetail_ExerciseId",
                table: "ExerciseDetail",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "BodyWeightEntry");

            migrationBuilder.DropTable(
                name: "ExerciseDetail");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Exercises",
                newName: "Sets");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Exercises",
                newName: "Tempo");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rir",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rpe",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "AppUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "AppUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Age", "Height", "Weight", "FirstName", "LastName" },
                values: new object[] { 1, 18, 182f, 1.2f, "Michael", "Patrick" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }
    }
}
