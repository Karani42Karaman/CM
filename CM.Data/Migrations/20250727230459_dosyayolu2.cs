using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.Data.Migrations
{
    /// <inheritdoc />
    public partial class dosyayolu2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Galeri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Galeri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
