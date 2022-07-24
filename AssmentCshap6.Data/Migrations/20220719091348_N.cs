using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssmentCshap6.Data.Migrations
{
    public partial class N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Lops",
                columns: table => new
                {
                    MaLop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lops", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "Monhocs",
                columns: table => new
                {
                    IdMonhoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonhoc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monhocs", x => x.IdMonhoc);
                });

            migrationBuilder.CreateTable(
                name: "Nganhs",
                columns: table => new
                {
                    IdNganh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNganh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganhs", x => x.IdNganh);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    IdSchool = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.IdSchool);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HovsTenDem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DBO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexs = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienInLops",
                columns: table => new
                {
                    StudenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Malop = table.Column<int>(type: "int", nullable: false),
                    Desctions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienInLops", x => new { x.StudenId, x.Malop });
                    table.ForeignKey(
                        name: "FK_SinhVienInLops_Lops_Malop",
                        column: x => x.Malop,
                        principalTable: "Lops",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienInLops_Students_StudenId",
                        column: x => x.StudenId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienInMonHocs",
                columns: table => new
                {
                    StudenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaMonHoc = table.Column<int>(type: "int", nullable: false),
                    Diem = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienInMonHocs", x => new { x.StudenId, x.MaMonHoc });
                    table.ForeignKey(
                        name: "FK_SinhVienInMonHocs_Monhocs_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "Monhocs",
                        principalColumn: "IdMonhoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienInMonHocs_Students_StudenId",
                        column: x => x.StudenId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienInNganhs",
                columns: table => new
                {
                    StudenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNganh = table.Column<int>(type: "int", nullable: false),
                    Desctions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienInNganhs", x => new { x.StudenId, x.IdNganh });
                    table.ForeignKey(
                        name: "FK_SinhVienInNganhs_Nganhs_IdNganh",
                        column: x => x.IdNganh,
                        principalTable: "Nganhs",
                        principalColumn: "IdNganh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienInNganhs_Students_StudenId",
                        column: x => x.StudenId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienInSchools",
                columns: table => new
                {
                    StudenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSchools = table.Column<int>(type: "int", nullable: false),
                    Desctions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienInSchools", x => new { x.StudenId, x.IdSchools });
                    table.ForeignKey(
                        name: "FK_SinhVienInSchools_Schools_IdSchools",
                        column: x => x.IdSchools,
                        principalTable: "Schools",
                        principalColumn: "IdSchool",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienInSchools_Students_StudenId",
                        column: x => x.StudenId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienInLops_Malop",
                table: "SinhVienInLops",
                column: "Malop");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienInMonHocs_MaMonHoc",
                table: "SinhVienInMonHocs",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienInNganhs_IdNganh",
                table: "SinhVienInNganhs",
                column: "IdNganh");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienInSchools_IdSchools",
                table: "SinhVienInSchools",
                column: "IdSchools");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "SinhVienInLops");

            migrationBuilder.DropTable(
                name: "SinhVienInMonHocs");

            migrationBuilder.DropTable(
                name: "SinhVienInNganhs");

            migrationBuilder.DropTable(
                name: "SinhVienInSchools");

            migrationBuilder.DropTable(
                name: "Lops");

            migrationBuilder.DropTable(
                name: "Monhocs");

            migrationBuilder.DropTable(
                name: "Nganhs");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
