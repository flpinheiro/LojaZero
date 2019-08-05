using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaZero.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LojaZero");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    DtStart = table.Column<DateTime>(nullable: false),
                    DtEnd = table.Column<DateTime>(nullable: false),
                    Cod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPromotion",
                schema: "LojaZero",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    PromotionId = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPromotion", x => new { x.ProductId, x.PromotionId });
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "LojaZero",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalSchema: "LojaZero",
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                schema: "LojaZero",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTag_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "LojaZero",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "LojaZero",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "LojaZero",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DtBirthDay = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "LojaZero",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZipCode = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "LojaZero",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "LojaZero",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<int>(nullable: false),
                    AreaCode = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "LojaZero",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "LojaZero",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                schema: "LojaZero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtShop = table.Column<DateTime>(nullable: false),
                    DtSend = table.Column<DateTime>(nullable: false),
                    ShippingTax = table.Column<decimal>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    DeliveryAddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Person_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "LojaZero",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalSchema: "LojaZero",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSelect",
                schema: "LojaZero",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<int>(nullable: false),
                    Qtd = table.Column<int>(nullable: false),
                    UnitValue = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSelect", x => new { x.ProductId, x.ShoppingCartId });
                    table.ForeignKey(
                        name: "FK_ProductSelect_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "LojaZero",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSelect_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "LojaZero",
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartStatus",
                schema: "LojaZero",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false),
                    TrackCod = table.Column<string>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    Selected = table.Column<bool>(nullable: false),
                    SelectEmployeeId = table.Column<int>(nullable: true),
                    Dispatch = table.Column<bool>(nullable: false),
                    DispatchEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartStatus", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartStatus_Person_DispatchEmployeeId",
                        column: x => x.DispatchEmployeeId,
                        principalSchema: "LojaZero",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartStatus_Person_SelectEmployeeId",
                        column: x => x.SelectEmployeeId,
                        principalSchema: "LojaZero",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartStatus_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "LojaZero",
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                schema: "LojaZero",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                schema: "LojaZero",
                table: "Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                schema: "LojaZero",
                table: "Companies",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                schema: "LojaZero",
                table: "Person",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_CompanyId",
                schema: "LojaZero",
                table: "Phone",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_PersonId",
                schema: "LojaZero",
                table: "Phone",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotion_PromotionId",
                schema: "LojaZero",
                table: "ProductPromotion",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSelect_ShoppingCartId",
                schema: "LojaZero",
                table: "ProductSelect",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagId",
                schema: "LojaZero",
                table: "ProductTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ClientId",
                schema: "LojaZero",
                table: "ShoppingCarts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_DeliveryAddressId",
                schema: "LojaZero",
                table: "ShoppingCarts",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartStatus_DispatchEmployeeId",
                schema: "LojaZero",
                table: "ShoppingCartStatus",
                column: "DispatchEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartStatus_SelectEmployeeId",
                schema: "LojaZero",
                table: "ShoppingCartStatus",
                column: "SelectEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phone",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "ProductPromotion",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "ProductSelect",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "ProductTag",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "ShoppingCartStatus",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "Promotions",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "ShoppingCarts",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "LojaZero");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "LojaZero");
        }
    }
}
