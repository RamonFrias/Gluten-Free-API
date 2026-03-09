using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlutenFreeApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovePlacesColletionAtProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceProduct");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PlaceId",
                table: "Products",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Places_PlaceId",
                table: "Products",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Places_PlaceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PlaceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "PlaceProduct",
                columns: table => new
                {
                    ProductPlacesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceProduct", x => new { x.ProductPlacesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PlaceProduct_Places_ProductPlacesId",
                        column: x => x.ProductPlacesId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceProduct_ProductsId",
                table: "PlaceProduct",
                column: "ProductsId");
        }
    }
}
