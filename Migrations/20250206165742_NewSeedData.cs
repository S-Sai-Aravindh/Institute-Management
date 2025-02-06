using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Institute_Management.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchTiming",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BatchType",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 1,
                columns: new[] { "BatchTiming", "BatchType" },
                values: new object[] { "9:00 AM - 11:00 AM", "Morning" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ContactDetails", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 4, "234-567-8902", "student2@example.com", "Student Two", "student456", "Student" },
                    { 5, "123-456-7891", "admin2@example.com", "Admin Two", "admin456", "Admin" },
                    { 6, "345-678-9013", "teacher2@example.com", "Teacher Two", "teacher456", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "UserId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "SubjectSpecialization", "UserId" },
                values: new object[] { 2, "Science", 6 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Description", "TeacherId" },
                values: new object[] { 2, "Physics 101", "Basic concepts of Physics", 2 });

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "BatchId", "BatchName", "BatchTiming", "BatchType", "CourseId" },
                values: new object[] { 2, "Batch B", "2:00 PM - 4:00 PM", "Afternoon", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BatchId", "UserId" },
                values: new object[] { 2, 2, 4 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Batches",
                keyColumn: "BatchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "BatchTiming",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "BatchType",
                table: "Batches");
        }
    }
}
