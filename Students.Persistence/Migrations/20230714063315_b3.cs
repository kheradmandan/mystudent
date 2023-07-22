using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students.Persistence.Migrations
{
    public partial class b3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nomre",
                table: "CourseStudents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nomre",
                table: "CourseStudents");
        }
    }
}
