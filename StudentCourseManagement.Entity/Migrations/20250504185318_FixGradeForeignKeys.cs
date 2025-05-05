using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCourseManagement.Entity.Migrations
{
    /// <inheritdoc />
    public partial class FixGradeForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grades_courses_coursesCourseId",
                table: "grades");

            migrationBuilder.DropForeignKey(
                name: "FK_grades_students_studentsStudentId",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_coursesCourseId",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_studentsStudentId",
                table: "grades");

            migrationBuilder.DropColumn(
                name: "coursesCourseId",
                table: "grades");

            migrationBuilder.DropColumn(
                name: "studentsStudentId",
                table: "grades");

            migrationBuilder.CreateIndex(
                name: "IX_grades_CourseId",
                table: "grades",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_grades_StudentId",
                table: "grades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_grades_courses_CourseId",
                table: "grades",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grades_students_StudentId",
                table: "grades",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grades_courses_CourseId",
                table: "grades");

            migrationBuilder.DropForeignKey(
                name: "FK_grades_students_StudentId",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_CourseId",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_StudentId",
                table: "grades");

            migrationBuilder.AddColumn<int>(
                name: "coursesCourseId",
                table: "grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentsStudentId",
                table: "grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_grades_coursesCourseId",
                table: "grades",
                column: "coursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_grades_studentsStudentId",
                table: "grades",
                column: "studentsStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_grades_courses_coursesCourseId",
                table: "grades",
                column: "coursesCourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grades_students_studentsStudentId",
                table: "grades",
                column: "studentsStudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
