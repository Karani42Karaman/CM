using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.Data.Migrations
{
    /// <inheritdoc />
    public partial class price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceModels",
                columns: table => new
                {
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagePrice = table.Column<int>(type: "int", nullable: false),
                    PackageContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageContentEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceModels", x => x.PriceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceModels");
        }
    }
}
