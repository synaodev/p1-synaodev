using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class mgn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    CrustID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CrustID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<long>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<long>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaID = table.Column<long>(nullable: false),
                    CrustID = table.Column<long>(nullable: false),
                    SizeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaID);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustID",
                        column: x => x.CrustID,
                        principalTable: "Crusts",
                        principalColumn: "CrustID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<long>(nullable: false),
                    UserID = table.Column<long>(nullable: false),
                    StoreID = table.Column<long>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzaID = table.Column<long>(nullable: false),
                    ToppingID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzaID, x.ToppingID });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Toppings",
                        principalColumn: "ToppingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    OrderPizzaID = table.Column<long>(nullable: false),
                    OrderID = table.Column<long>(nullable: false),
                    PizzaID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => x.OrderPizzaID);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Deep Dish", 3.50m },
                    { 2L, "New York Style", 2.50m },
                    { 3L, "Thin Crust", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Large", 12.00m },
                    { 2L, "Medium", 10.00m },
                    { 3L, "Small", 8.00m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreID", "Location", "Password", "Username" },
                values: new object[,]
                {
                    { 4L, "Kalamazoo", "Mario", "Johnny" },
                    { 3L, "New Mexico", "Mario", "Whatever" },
                    { 1L, "Albequerque", "Cadena", "Tyler" },
                    { 2L, "New York", "Benjamin", "MuggyPizza" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "Name", "Price" },
                values: new object[,]
                {
                    { 637205996367975938L, "Cheese", 0.25m },
                    { 637205996367976396L, "Tomato Sauce", 0.75m },
                    { 637205996367976412L, "Pepperoni", 0.50m },
                    { 637205996367976415L, "Bacon", 0.45m },
                    { 637205996367976420L, "Anchovies", 1.00m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Password", "Username" },
                values: new object[,]
                {
                    { 2L, "Benjamin", "Cody" },
                    { 1L, "Cadena", "Tyler" },
                    { 3L, "Mario", "Mario" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaID", "CrustID", "SizeID" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaID", "CrustID", "SizeID" },
                values: new object[] { 2L, 2L, 2L });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaID", "CrustID", "SizeID" },
                values: new object[] { 3L, 3L, 3L });

            migrationBuilder.InsertData(
                table: "PizzaTopping",
                columns: new[] { "PizzaID", "ToppingID" },
                values: new object[,]
                {
                    { 1L, 637205996367975938L },
                    { 1L, 637205996367976396L },
                    { 1L, 637205996367976412L },
                    { 2L, 637205996367975938L },
                    { 2L, 637205996367976396L },
                    { 2L, 637205996367976415L },
                    { 3L, 637205996367975938L },
                    { 3L, 637205996367976396L },
                    { 3L, 637205996367976420L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_OrderID",
                table: "OrderPizza",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzaID",
                table: "OrderPizza",
                column: "PizzaID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreID",
                table: "Orders",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustID",
                table: "Pizzas",
                column: "CrustID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeID",
                table: "Pizzas",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingID",
                table: "PizzaTopping",
                column: "ToppingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
