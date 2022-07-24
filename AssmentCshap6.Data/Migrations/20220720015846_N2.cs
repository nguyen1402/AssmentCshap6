using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssmentCshap6.Data.Migrations
{
    public partial class N2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Monhocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Monhocs");
        }
    }
}
