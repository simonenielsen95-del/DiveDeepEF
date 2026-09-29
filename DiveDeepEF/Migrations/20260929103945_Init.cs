using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiveDeepEF.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostumerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerDay = table.Column<float>(type: "real", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fins_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fins_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mask_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suit_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suit_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thickness = table.Column<double>(type: "float", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Brand", "EquipmentType", "Model", "PricePerDay", "Size" },
                values: new object[,]
                {
                    { 1, "Scubapro", "BCD", "Navigator Lite", 125f, "S, M, L" },
                    { 2, "Scubapro", "BCD", "Glide", 140f, "S, M, L" },
                    { 3, "Scubapro", "BCD", "Hydros Pro", 200f, "S, M, L" },
                    { 4, "Seac", "BCD", "Modular", 145f, "S, M, L" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Brand", "EquipmentType", "Fins_Model", "PricePerDay", "Fins_Size" },
                values: new object[,]
                {
                    { 5, "Scubapro", "Fins", "Jet Fin", 50f, "XS, S, M, L, XL" },
                    { 6, "Scubapro", "Fins", "GO Travel", 50f, "XS, S, M, L, XL" },
                    { 7, "Scubapro", "Fins", "Seawing Supernova", 60f, "XS, S, M, L, XL" },
                    { 8, "Seac", "Fins", "Propulsion", 50f, "XS, S, M, L, XL" },
                    { 9, "Seac", "Fins", "ALA", 50f, "XS, S, M, L, XL" },
                    { 10, "Fourth Element", "Fins", "Tech", 75f, "XS, S, M, L, XL" },
                    { 11, "Fourth Element", "Fins", "Rec Fin", 80f, "XS, S, M, L, XL" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Brand", "EquipmentType", "Mask_Model", "PricePerDay" },
                values: new object[,]
                {
                    { 12, "Scubapro", "Mask", "Ghost", 50f },
                    { 13, "Scubapro", "Mask", "D-Mask", 60f },
                    { 14, "Scubapro", "Mask", "Spectra Mini", 50f },
                    { 15, "Scubapro", "Mask", "Crystal VU", 75f },
                    { 16, "Fourth Element", "Mask", "Scout Enhance", 75f },
                    { 17, "Tusa", "Mask", "Element", 75f }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Brand", "EquipmentType", "FirstStage", "Octopus", "PricePerDay", "SecondStage" },
                values: new object[,]
                {
                    { 18, "Scubapro", "RegulatorSet", "MK25 EVO", "R105", 125f, "S600" },
                    { 19, "Scubapro", "RegulatorSet", "MK17 EVO", "R095", 100f, "C370" },
                    { 20, "Scubapro", "RegulatorSet", "MK25 EVO BT", "S270", 150f, "A700 Carbon BT" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Brand", "EquipmentType", "Gender", "Suit_Model", "PricePerDay", "Suit_Size", "Thickness", "Type" },
                values: new object[,]
                {
                    { 21, "Scubapro", "Suit", "Men/Women", "Definition", 100f, "XS, S, M, L, XL", 3.0, "Wetsuit" },
                    { 22, "Scubapro", "Suit", "Men/Women", "Definition", 100f, "XS, S, M, L, XL", 5.0, "Wetsuit" },
                    { 23, "Scubapro", "Suit", "Men/Women", "Definition", 100f, "XS, S, M, L, XL", 7.0, "Wetsuit" },
                    { 24, "Waterproof", "Suit", "Men/Women", "W5", 100f, "XS, S, M, L, XL", 3.5, "Wetsuit" },
                    { 25, "Fourth Element", "Suit", "Men/Women", "Proteus", 120f, "XS, S, M, L, XL", 5.0, "Wetsuit" },
                    { 26, "Scubapro", "Suit", "Men/Women", "Exodry 4.0", 300f, "XS, S, M, L, XL", null, "Drysuit" },
                    { 27, "Waterproof", "Suit", "Men/Women", "D7 Evo", 320f, "XS, S, M, L, XL", null, "Drysuit" },
                    { 28, "Santi", "Suit", "Men/Women", "E.Lite Plus", 350f, "XS, S, M, L, XL", null, "Drysuit" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Brand", "EquipmentType", "PricePerDay", "Volume" },
                values: new object[,]
                {
                    { 29, "Scubapro", "Tank", 150f, 5 },
                    { 30, "Scubapro", "Tank", 160f, 10 },
                    { 31, "Scubapro", "Tank", 170f, 12 },
                    { 32, "Scubapro", "Tank", 180f, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BookingId",
                table: "BasketItems",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_EquipmentId",
                table: "BasketItems",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Equipments");
        }
    }
}
