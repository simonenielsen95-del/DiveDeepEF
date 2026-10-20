using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepEF.Migrations
{
    /// <inheritdoc />
    public partial class AddBasketItemQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BasketItems");
        }
    }
}
