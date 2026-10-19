using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepEF.Migrations
{
    /// <inheritdoc />
    public partial class FixDivingPackages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "BasketItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivingPackageId",
                table: "BasketItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedSize",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuitGender",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DivingPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BcdId = table.Column<int>(type: "int", nullable: true),
                    SuitId = table.Column<int>(type: "int", nullable: true),
                    RegulatorId = table.Column<int>(type: "int", nullable: true),
                    TankId = table.Column<int>(type: "int", nullable: true),
                    FinsId = table.Column<int>(type: "int", nullable: true),
                    MaskId = table.Column<int>(type: "int", nullable: true),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivingPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivingPackages_Equipments_BcdId",
                        column: x => x.BcdId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivingPackages_Equipments_FinsId",
                        column: x => x.FinsId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivingPackages_Equipments_MaskId",
                        column: x => x.MaskId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivingPackages_Equipments_RegulatorId",
                        column: x => x.RegulatorId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivingPackages_Equipments_SuitId",
                        column: x => x.SuitId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivingPackages_Equipments_TankId",
                        column: x => x.TankId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DivingPackages",
                columns: new[] { "Id", "BcdId", "Description", "FinsId", "MaskId", "Name", "PricePerDay", "RegulatorId", "SuitId", "TankId" },
                values: new object[,]
                {
                    { 1, 1, "BCD + Suit + RegulatorSet + Tank + Fins + Mask", 5, 12, "Complete StarterPack Diving Set", 500m, 18, 21, 29 },
                    { 2, 2, "BCD + Suit + RegulatorSet + Tank + Fins + Mask", 6, 13, "Complete Advanced Diving Set", 750m, 19, 22, 30 },
                    { 3, null, "Mask + Fins", 7, 14, "Complete Amateur Snorkel Set", 300m, null, null, null },
                    { 4, null, "Mask + Fins", 8, 15, "Complete Professional Snorkel Set", 400m, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_DivingPackageId",
                table: "BasketItems",
                column: "DivingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingPackages_BcdId",
                table: "DivingPackages",
                column: "BcdId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingPackages_FinsId",
                table: "DivingPackages",
                column: "FinsId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingPackages_MaskId",
                table: "DivingPackages",
                column: "MaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingPackages_RegulatorId",
                table: "DivingPackages",
                column: "RegulatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingPackages_SuitId",
                table: "DivingPackages",
                column: "SuitId");

            migrationBuilder.CreateIndex(
                name: "IX_DivingPackages_TankId",
                table: "DivingPackages",
                column: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_DivingPackages_DivingPackageId",
                table: "BasketItems",
                column: "DivingPackageId",
                principalTable: "DivingPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_DivingPackages_DivingPackageId",
                table: "BasketItems");

            migrationBuilder.DropTable(
                name: "DivingPackages");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_DivingPackageId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "DivingPackageId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SelectedSize",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SuitGender",
                table: "BasketItems");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
