using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepEF.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PricePerDay",
                table: "Equipments",
                type: "real(18)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PricePerDay",
                table: "Equipments",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real(18)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
