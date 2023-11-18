using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITShop.Migrations
{
    /// <inheritdoc />
    public partial class khoitaocsdl4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "TinhTrang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "TinhTrang",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
