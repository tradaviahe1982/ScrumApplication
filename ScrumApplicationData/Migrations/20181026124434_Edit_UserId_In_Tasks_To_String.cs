using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrumApplicationData.Migrations
{
    public partial class Edit_UserId_In_Tasks_To_String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
