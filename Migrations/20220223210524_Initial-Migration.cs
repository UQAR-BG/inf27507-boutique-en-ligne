using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INF27507_Boutique_En_Ligne.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories_id", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<double>(type: "double", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firstname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients_id", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_colours_id", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genders_id", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paymentmethods_id", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firstname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sellers_id", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usages_id", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subcategories_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_carts_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_producttypes_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageURL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    UsageId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Usages_UsageId",
                        column: x => x.UsageId,
                        principalTable: "Usages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<double>(type: "double", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartitems_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apparel" },
                    { 2, "Footwear" }
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "Blue" },
                    { 3, "Yellow" },
                    { 4, "White" },
                    { 5, "Green" },
                    { 6, "Pink" },
                    { 7, "Brown" },
                    { 8, "Red" },
                    { 9, "Olive" },
                    { 10, "Beige" },
                    { 11, "Silver" },
                    { 12, "Grey" },
                    { 13, "Peach" },
                    { 14, "Orange" },
                    { 15, "Gold" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boys" },
                    { 2, "Girls" },
                    { 3, "Men" },
                    { 4, "Women" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Credits" },
                    { 2, "PayPal" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Firstname", "Lastname", "Username" },
                values: new object[,]
                {
                    { 1, "Albert", "", "Albert" },
                    { 2, "Amélie", "", "Amélie" },
                    { 3, "Julie", "", "Julie" },
                    { 4, "Xavier", "", "Xavier" }
                });

            migrationBuilder.InsertData(
                table: "Usages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Casual" },
                    { 2, "Formal" },
                    { 3, "Sports" },
                    { 4, "Ethnic" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Topwear" },
                    { 2, 1, "Bottomwear" },
                    { 3, 2, "Shoes" },
                    { 4, 2, "Flip Flops" },
                    { 5, 2, "Sandal" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, "Tshirts", 1 },
                    { 2, "Tops", 1 },
                    { 3, "Skirts", 2 },
                    { 4, "Formal Shoes", 3 },
                    { 5, "Casual Shoes", 3 },
                    { 6, "Sports Shoes", 3 },
                    { 7, "Flats", 3 },
                    { 8, "Heels", 3 },
                    { 9, "Shorts", 2 },
                    { 10, "Flip Flops", 4 },
                    { 11, "Kurtas", 1 },
                    { 12, "Capris", 2 },
                    { 13, "Sandals", 5 },
                    { 14, "Sports Sandals", 5 },
                    { 15, "Rompers", 1 },
                    { 16, "Shirts", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ColourId", "GenderId", "Image", "ImageURL", "Price", "ProductTypeId", "SellerId", "SubCategoryId", "Title", "UsageId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "39855.jpg", "http://assets.myntassets.com/v1/images/style/properties/6fa45d21a0d6194932652bfcaf4c0e2b_images.jpg", 20.0, 1, 1, 1, "Gini and Jony Boys Printed Black T-Shirt", 1 },
                    { 2, 1, 2, 1, "35881.jpg", "http://assets.myntassets.com/v1/images/style/properties/2ea8c6ea0765fca46041647c5ce1c514_images.jpg", 10.75, 1, 1, 1, "Jungle Book Boys Jungle Friends Blue T-shirt", 1 },
                    { 3, 1, 3, 1, "39859.jpg", "http://assets.myntassets.com/v1/images/style/properties/a3c0711f3d54240e227c7c615d8d46c5_images.jpg", 20.0, 1, 1, 1, "Palm Tree Boys Printed Yellow T-Shirt", 1 },
                    { 4, 1, 4, 2, "2700.jpg", "http://assets.myntassets.com/v1/images/style/properties/d2c388bcd6a795e0d0cea56392d352a6_images.jpg", 49.990000000000002, 2, 1, 1, "Disney Kids Girl's White Kidswear", 1 },
                    { 5, 1, 5, 2, "18171.jpg", "http://assets.myntassets.com/v1/images/style/properties/f1dbb13abb1efd3ba19bd4108f1a6703_images.jpg", 15.5, 2, 1, 1, "Doodle Kids Girls Ballon Green Top", 1 },
                    { 6, 1, 2, 2, "34148.jpg", "http://assets.myntassets.com/v1/images/style/properties/c90319b0bf114581aa3dc692239a0607_images.jpg", 20.0, 3, 1, 2, "Gini and Jony Girls Washed Blue Skirt", 1 },
                    { 7, 2, 1, 3, "54529.jpg", "http://assets.myntassets.com/v1/images/style/properties/F-Sports-Men-Black-Shoes_f4920f8c2dd4277191a4468e5acf397d_images.jpg", 10.0, 5, 1, 3, "F Sports Men Black Shoes", 1 },
                    { 8, 2, 1, 3, "13072.jpg", "http://assets.myntassets.com/v1/images/style/properties/2fc766a7415035d5855a236326c01366_images.jpg", 15.0, 5, 1, 3, "Numero Uno Men Black Casual Shoes", 1 },
                    { 9, 2, 1, 3, "13080.jpg", "http://assets.myntassets.com/v1/images/style/properties/efef30c05460e90a1e170998dde8f92c_images.jpg", 15.0, 5, 1, 3, "Numero Uno Men Black Casual Shoes", 1 },
                    { 10, 2, 1, 4, "56943.jpg", "http://assets.myntassets.com/v1/images/style/properties/HM-Women-Black-Sandals_a9da5e1e341b17a3eb061f783c01ca21_images.jpg", 49.990000000000002, 7, 1, 3, "HM Women Black Sandals", 1 },
                    { 11, 2, 6, 4, "45324.jpg", "http://assets.myntassets.com/v1/images/style/properties/31414b116179349f43cf4a558a05de25_images.jpg", 49.990000000000002, 8, 1, 3, "Cobblerz Women Pink & White Wedges", 1 },
                    { 12, 2, 7, 4, "10292.jpg", "http://assets.myntassets.com/v1/images/style/properties/Clarks-Women-Dolphin-Splash-Leather-Silver-Sandals_e55a6fa02cca3f6b6f3fa750619911d4_images.jpg", 55.75, 8, 1, 3, "Clarks Women Brown Leather Heels", 1 },
                    { 13, 1, 8, 1, "38249.jpg", "http://assets.myntassets.com/v1/images/style/properties/91b690cee7977353b5fa29ae56bf22d4_images.jpg", 10.0, 1, 2, 1, "Ben 10 Boys Red Printed T-shirt", 1 },
                    { 14, 1, 9, 1, "15571.jpg", "http://assets.myntassets.com/v1/images/style/properties/ba3659da8365d5f255ab9b992fec690f_images.jpg", 49.990000000000002, 1, 2, 1, "Chhota Bheem Kids Boys Spare Me TShirt", 1 },
                    { 15, 1, 5, 1, "39861.jpg", "http://assets.myntassets.com/v1/images/style/properties/f61e63af58565cb07fba8b5d54db3994_images.jpg", 55.75, 1, 2, 1, "Gini and Jony Boys Polo Green T-Shirt", 1 },
                    { 16, 1, 6, 2, "38766.jpg", "http://assets.myntassets.com/v1/images/style/properties/9097ddc9c0e1272023976f8e8da00617_images.jpg", 30.850000000000001, 9, 2, 2, "Gini and Jony Girls Pink Shorts", 1 },
                    { 17, 1, 8, 2, "35448.jpg", "http://assets.myntassets.com/v1/images/style/properties/bdcb051154afdf6da0a6b1010e116c35_images.jpg", 15.5, 2, 2, 1, "Doodle Girls Printed Red Top", 1 },
                    { 18, 1, 6, 2, "24941.jpg", "http://assets.myntassets.com/v1/images/style/properties/c1a5e415fd0e4f4945aa965729de43c1_images.jpg", 15.0, 2, 2, 1, "United Colors of Benetton Kids Girls Pink Top", 1 },
                    { 19, 2, 4, 3, "40785.jpg", "http://assets.myntassets.com/v1/images/style/properties/3ac1a2f48ba5767e13a5cb112da62654_images.jpg", 15.5, 10, 2, 4, "Quiksilver Men White Flip Flops", 1 },
                    { 20, 2, 2, 3, "26553.jpg", "http://assets.myntassets.com/v1/images/style/properties/a02747a571130ca2d2aa6f491d8b5fc2_images.jpg", 15.0, 5, 2, 3, "ID Men Blue Shoes", 1 },
                    { 21, 2, 1, 3, "45603.jpg", "http://assets.myntassets.com/v1/images/style/properties/8f3b9f4c5f554e39681567b22985966e_images.jpg", 20.0, 4, 2, 3, "Arrow Men Black Formal Shoes", 2 },
                    { 22, 2, 10, 4, "45322.jpg", "http://assets.myntassets.com/v1/images/style/properties/04bf5738b8d46cc9a768caf2a35f9451_images.jpg", 15.5, 8, 2, 3, "Cobblerz Women Beige & Blue Wedges", 1 },
                    { 23, 2, 11, 4, "41669.jpg", "http://assets.myntassets.com/v1/images/style/properties/a87cc5ed84c4882d76413571787cad2f_images.jpg", 10.0, 8, 2, 3, "Catwalk Women Silver Heels", 1 },
                    { 24, 2, 2, 4, "7595.jpg", "http://assets.myntassets.com/v1/images/style/properties/b3f3d37c936ee1b487eb6ed3ef399e0b_images.jpg", 30.850000000000001, 6, 2, 3, "Nike Women Ten Blue White Shoe", 3 },
                    { 25, 1, 6, 1, "46831.jpg", "http://assets.myntassets.com/v1/images/style/properties/943d9b272c042d8b06ee6b1d277de5be_images.jpg", 30.0, 16, 3, 1, "Gini and Jony Boys Pink Shirt", 1 },
                    { 26, 1, 2, 1, "30720.jpg", "http://assets.myntassets.com/v1/images/style/properties/e95357480c6acea8e7bcdce602a0a532_images.jpg", 10.0, 11, 3, 1, "Fabindia Boys Printed Blue Kurta", 4 },
                    { 27, 1, 5, 1, "40974.jpg", "http://assets.myntassets.com/v1/images/style/properties/c534bd1e6aef81fafe5fddf41bff6401_images.jpg", 15.0, 1, 3, 1, "Gini and Jony Boys United Green T-shirt", 1 },
                    { 28, 1, 6, 2, "42002.jpg", "http://assets.myntassets.com/v1/images/style/properties/d07f3c84fe3df82e98b46ba9a55cc866_images.jpg", 15.5, 12, 3, 2, "Gini and Jony Girls Kinky Pink Capris", 1 },
                    { 29, 1, 6, 2, "8359.jpg", "http://assets.myntassets.com/v1/images/style/properties/705333ff633393a22cb5c229128afcc2_images.jpg", 30.850000000000001, 1, 3, 1, "Doodle Girl's Princess Cute Little Pink Kidswear", 1 },
                    { 30, 1, 4, 2, "40972.jpg", "http://assets.myntassets.com/v1/images/style/properties/6ad4e27d85073205cafdd1edbd1d86f6_images.jpg", 55.75, 2, 3, 1, "Palm Tree Girls Knits White Tops", 1 },
                    { 31, 2, 4, 3, "23500.jpg", "http://assets.myntassets.com/v1/images/style/properties/0734fd1f8aea4117ff2f3810a8d7d30b_images.jpg", 49.990000000000002, 6, 3, 3, "FILA Men Hostile White Sports Shoes", 3 },
                    { 32, 2, 12, 3, "41455.jpg", "http://assets.myntassets.com/v1/images/style/properties/788847bb37bf3ba404eeebcb290c8746_images.jpg", 19.989999999999998, 13, 3, 5, "Lee Cooper Men Grey Sandals", 1 },
                    { 33, 2, 7, 3, "7364.jpg", "http://assets.myntassets.com/v1/images/style/properties/e1f82da932e688fe0f59740369c59b97_images.jpg", 20.0, 5, 3, 3, "Red Tape Men's Brown casual Shoe", 1 },
                    { 34, 2, 4, 4, "5319.jpg", "http://assets.myntassets.com/v1/images/style/properties/54a68221353b667c1aa1c17631a6e534_images.jpg", 15.5, 6, 3, 3, "ADIDAS Women's Duramo Luxury White Shoe", 3 },
                    { 35, 2, 1, 4, "54118.jpg", "http://assets.myntassets.com/v1/images/style/properties/8d6fd53f28e010658cdf5c14c43d0cb0_images.jpg", 10.0, 8, 3, 3, "Rocia Women Black Flats", 1 },
                    { 36, 2, 8, 4, "49608.jpg", "http://assets.myntassets.com/v1/images/style/properties/5055777a92b6b46240d58dd31eb46ba8_images.jpg", 30.0, 5, 3, 3, "Catwalk Women Red Shoes", 1 },
                    { 37, 1, 8, 1, "40956.jpg", "http://assets.myntassets.com/v1/images/style/properties/a913999991c21e8233f1d5fd1ab20802_images.jpg", 10.0, 1, 4, 1, "Gini and Jony Boys Comics Red T-shirt", 1 },
                    { 38, 1, 8, 1, "48250.jpg", "http://assets.myntassets.com/v1/images/style/properties/edc6d691eeab51c01264064be592e390_images.jpg", 20.0, 1, 4, 1, "The Amazing Spiderman Boys Red T-Shirt", 1 },
                    { 39, 1, 2, 1, "37524.jpg", "http://assets.myntassets.com/v1/images/style/properties/1ed5e3016f7bf021add2fd67ac735d80_images.jpg", 24.989999999999998, 15, 4, 1, "Madagascar3 Infant Boys Light Blue Snapsuit Romper", 1 },
                    { 40, 1, 8, 2, "35448.jpg", "http://assets.myntassets.com/v1/images/style/properties/bdcb051154afdf6da0a6b1010e116c35_images.jpg", 15.5, 2, 4, 1, "Doodle Girls Printed Red Top", 1 },
                    { 41, 1, 3, 2, "2701.jpg", "http://assets.myntassets.com/v1/images/style/properties/9f0369e7d1bb5beabf1071dcd6f15867_images.jpg", 30.850000000000001, 2, 4, 1, "Disney Kids Girl's Yellow Daisy Kidswear", 1 },
                    { 42, 1, 13, 2, "39835.jpg", "http://assets.myntassets.com/v1/images/style/properties/a7e6fca57d133337f6e76e3b5e74fd20_images.jpg", 20.0, 2, 4, 1, "Gini and Jony Girls Printed Peach Top", 1 },
                    { 43, 2, 9, 3, "11947.jpg", "http://assets.myntassets.com/v1/images/style/properties/464879391de4e1a7b881dad3b7bd83a8_images.jpg", 24.989999999999998, 13, 4, 5, "Ganuchi Men Casual Olive Sandals", 1 },
                    { 44, 2, 1, 3, "3790.jpg", "http://assets.myntassets.com/v1/images/style/properties/2cbba1cd60b44011accb7c099a859ec4_images.jpg", 55.75, 5, 4, 3, "Converse Men's AS Canvas HI Black Shoe", 1 },
                    { 45, 2, 7, 3, "33848.jpg", "http://assets.myntassets.com/v1/images/style/properties/Puma-Men-Drift-Cat-Brown-Shoes_b37c89652031b205bcd19c36d6c686bd_images.jpg", 20.0, 5, 4, 3, "Puma Men Drift Cat Brown Shoes", 1 },
                    { 46, 2, 14, 4, "44725.jpg", "http://assets.myntassets.com/v1/images/style/properties/839c627c80dba9ac4412db3f35a52bb7_images.jpg", 30.850000000000001, 10, 4, 4, "Lotto Women Coral Elegant Flip Flops", 1 },
                    { 47, 2, 1, 4, "16995.jpg", "http://assets.myntassets.com/v1/images/style/properties/2e68ca2646690a4bf4ed092bf44cc6df_images.jpg", 24.989999999999998, 14, 4, 5, "Rocia Women Casual Black Sandal", 1 },
                    { 48, 2, 15, 4, "13027.jpg", "http://assets.myntassets.com/v1/images/style/properties/9d70af39b13503d1ae27c581dc5e711d_images.jpg", 30.850000000000001, 8, 4, 3, "Inc 5 Women Casual Gold Flats", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientId",
                table: "Cart",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColourId",
                table: "Products",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenderId",
                table: "Products",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsageId",
                table: "Products",
                column: "UsageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_SubCategoryId",
                table: "ProductTypes",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Usages");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
