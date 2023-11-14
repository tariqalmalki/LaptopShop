using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopShop.Migrations
{
    /// <inheritdoc />
    public partial class editItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tbItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tbItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
