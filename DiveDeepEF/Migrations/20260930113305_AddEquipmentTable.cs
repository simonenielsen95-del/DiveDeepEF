using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiveDeepEF.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Equipments_EquipmentId",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Equipment_EquipmentId",
                table: "BasketItems",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Equipment_EquipmentId",
                table: "BasketItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Equipments_EquipmentId",
                table: "BasketItems",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
