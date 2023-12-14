using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceAndLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CustomCoffees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Coffees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Cakes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CustomCoffees");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Coffees");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cakes");
        }
    }
}
