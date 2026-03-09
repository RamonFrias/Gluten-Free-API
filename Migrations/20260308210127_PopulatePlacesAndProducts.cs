using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlutenFreeApi.Migrations
{
    /// <inheritdoc />
    public partial class PopulatePlacesAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Places(PlaceName, PlaceDescription, PlaceImageUrl, PlaceAddress, PlacePostalCode) " +
                                    "VALUES ('Ficos Burguer', 'Hamburguers, hot-dogs, tacos, and more, all gluten-free itens', 'ImageUrl', 'Rua dos Ficos 120, Salto SP', '13321312')," +
                                    "('Ficos Gourmet Candies', 'Cakes, chocolates, and more, all gluten-free and lactose-free itens', 'ImageUrl', 'Rua dos Ficos Doces 140, Salto SP', '13321333')," +
                                    "('Ficos Pizzeria', 'Diversity of pizzas, Portions, and mora, all gluten-free pizzas', 'ImageUrl', 'Rua dos Ficos Pizza 150, Salto SP', '13321312')");

            migrationBuilder.Sql("INSERT INTO Products(ProductName, ProductDescription, ProductType, ProductPrice, QuantityInStock, ExpirationDate, ProductionDate, PlaceId) " +
                                    "VALUES ('Salad Burguer', 'Gluten-free bread with two 200g hamburguers, lactose-free cheddar cheese, letuce and tomato, .', 'Hamburguer', 35.90, 5, now(), now(), 1),"+
                                    "('Salad Double Bacon', 'Gluten-free bread with 200g hamburguers, lactose-free cheddar cheese, letuce, tomato and a lot of bacon.', 'Hamburguer', 45.90, 5, now(), now(), 1)," +
                                    "('Chocolate Cake', 'Delicious chocolate cake without gluten and lactose', 'Cake', 15.90, 3, now(), now(), 2)," +
                                    "('Blackberry pie', 'Delicious blackberry pie without gluten and lactose', 'Pie', 10.90, 3, now(), now(), 2)," +
                                    "('Chicken with catupiry cheese pizza', 'A delicious chicken with catupiry cheese pizza withou gluten and lactose', 'Pizza', 85.90, 5, now(), now(), 3)," +
                                    "('Pepperoni Pizza', 'A delicious pepperoni pizza withou gluten and lactose', 'Pizza', 85.90, 5, now(), now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
            migrationBuilder.Sql("DELETE FROM Places");
        }
    }
}
