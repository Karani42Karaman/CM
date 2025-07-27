using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.Data.Migrations
{
    /// <inheritdoc />
    public partial class dosyayolu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "VisionModels");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Urünler");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "UrünKategori");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "RakamYani");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "MissionModels");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Galeri");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Belgeler");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "VisionModels",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "Urünler",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "UrünKategori",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "Slider",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "RakamYani",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "MissionModels",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "Galeri",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "Belgeler",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "VisionModels",
                newName: "ImageContentType");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Urünler",
                newName: "ImageContentType");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "UrünKategori",
                newName: "ImageContentType");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Slider",
                newName: "ImageContentType");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "RakamYani",
                newName: "ImageContentType");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "MissionModels",
                newName: "ImageContentType");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Galeri",
                newName: "ImageContentType");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Belgeler",
                newName: "ImageContentType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "VisionModels",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Urünler",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "UrünKategori",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Slider",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "RakamYani",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "MissionModels",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Galeri",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Belgeler",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
