using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Data.Migrations
{
    /// <inheritdoc />
    public partial class PernilleErGlad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CakeId",
                table: "CCoffeIngredients",
                newName: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "CCoffeIngredients",
                newName: "CakeId");
        }
    }
}
