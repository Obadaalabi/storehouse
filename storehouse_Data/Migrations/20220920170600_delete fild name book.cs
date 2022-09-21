using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace storehouse_Data.Migrations
{
    public partial class deletefildnamebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_book",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name_book",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
