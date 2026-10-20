using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepEF.Migrations
{
    /// <inheritdoc />
    public partial class FixPricePerDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerDay",
                table: "Equipments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real(18)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PricePerDay",
                value: 125m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PricePerDay",
                value: 140m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PricePerDay",
                value: 200m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PricePerDay",
                value: 145m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                column: "PricePerDay",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "PricePerDay",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 7,
                column: "PricePerDay",
                value: 60m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 8,
                column: "PricePerDay",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 9,
                column: "PricePerDay",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 10,
                column: "PricePerDay",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 11,
                column: "PricePerDay",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 12,
                column: "PricePerDay",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 13,
                column: "PricePerDay",
                value: 60m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 14,
                column: "PricePerDay",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 15,
                column: "PricePerDay",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 16,
                column: "PricePerDay",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 17,
                column: "PricePerDay",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 18,
                column: "PricePerDay",
                value: 125m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 19,
                column: "PricePerDay",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 20,
                column: "PricePerDay",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 21,
                column: "PricePerDay",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 22,
                column: "PricePerDay",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 23,
                column: "PricePerDay",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 24,
                column: "PricePerDay",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 25,
                column: "PricePerDay",
                value: 120m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 26,
                column: "PricePerDay",
                value: 300m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 27,
                column: "PricePerDay",
                value: 320m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 28,
                column: "PricePerDay",
                value: 350m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 29,
                column: "PricePerDay",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 30,
                column: "PricePerDay",
                value: 160m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 31,
                column: "PricePerDay",
                value: 170m);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 32,
                column: "PricePerDay",
                value: 180m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PricePerDay",
                table: "Equipments",
                type: "real(18)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PricePerDay",
                value: 125f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PricePerDay",
                value: 140f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PricePerDay",
                value: 200f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PricePerDay",
                value: 145f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5,
                column: "PricePerDay",
                value: 50f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6,
                column: "PricePerDay",
                value: 50f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 7,
                column: "PricePerDay",
                value: 60f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 8,
                column: "PricePerDay",
                value: 50f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 9,
                column: "PricePerDay",
                value: 50f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 10,
                column: "PricePerDay",
                value: 75f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 11,
                column: "PricePerDay",
                value: 80f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 12,
                column: "PricePerDay",
                value: 50f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 13,
                column: "PricePerDay",
                value: 60f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 14,
                column: "PricePerDay",
                value: 50f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 15,
                column: "PricePerDay",
                value: 75f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 16,
                column: "PricePerDay",
                value: 75f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 17,
                column: "PricePerDay",
                value: 75f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 18,
                column: "PricePerDay",
                value: 125f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 19,
                column: "PricePerDay",
                value: 100f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 20,
                column: "PricePerDay",
                value: 150f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 21,
                column: "PricePerDay",
                value: 100f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 22,
                column: "PricePerDay",
                value: 100f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 23,
                column: "PricePerDay",
                value: 100f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 24,
                column: "PricePerDay",
                value: 100f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 25,
                column: "PricePerDay",
                value: 120f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 26,
                column: "PricePerDay",
                value: 300f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 27,
                column: "PricePerDay",
                value: 320f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 28,
                column: "PricePerDay",
                value: 350f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 29,
                column: "PricePerDay",
                value: 150f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 30,
                column: "PricePerDay",
                value: 160f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 31,
                column: "PricePerDay",
                value: 170f);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 32,
                column: "PricePerDay",
                value: 180f);
        }
    }
}
