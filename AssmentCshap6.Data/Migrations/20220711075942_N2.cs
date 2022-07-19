using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssmentCshap6.Data.Migrations
{
    public partial class N2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lops_Lops_Malop",
                table: "SinhVien_Lops");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Lops_Students_StudenId",
                table: "SinhVien_Lops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SinhVien_Lops",
                table: "SinhVien_Lops");

            migrationBuilder.RenameTable(
                name: "SinhVien_Lops",
                newName: "SinhVienInLops");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVien_Lops_Malop",
                table: "SinhVienInLops",
                newName: "IX_SinhVienInLops_Malop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SinhVienInLops",
                table: "SinhVienInLops",
                columns: new[] { "StudenId", "Malop" });

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienInLops_Lops_Malop",
                table: "SinhVienInLops",
                column: "Malop",
                principalTable: "Lops",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVienInLops_Students_StudenId",
                table: "SinhVienInLops",
                column: "StudenId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienInLops_Lops_Malop",
                table: "SinhVienInLops");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVienInLops_Students_StudenId",
                table: "SinhVienInLops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SinhVienInLops",
                table: "SinhVienInLops");

            migrationBuilder.RenameTable(
                name: "SinhVienInLops",
                newName: "SinhVien_Lops");

            migrationBuilder.RenameIndex(
                name: "IX_SinhVienInLops_Malop",
                table: "SinhVien_Lops",
                newName: "IX_SinhVien_Lops_Malop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SinhVien_Lops",
                table: "SinhVien_Lops",
                columns: new[] { "StudenId", "Malop" });

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lops_Lops_Malop",
                table: "SinhVien_Lops",
                column: "Malop",
                principalTable: "Lops",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Lops_Students_StudenId",
                table: "SinhVien_Lops",
                column: "StudenId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
