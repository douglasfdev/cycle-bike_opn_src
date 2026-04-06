using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "character varying(16)", unicode: false, maxLength: 16, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    LastFourDigits = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: false),
                    CardToken = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: false),
                    HolderName = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    ExpirationDate = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    Cvv = table.Column<string>(type: "character varying(4)", unicode: false, maxLength: 4, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "surcharges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Fee = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surcharges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profiles_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_profiles_Id",
                        column: x => x.Id,
                        principalTable: "profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    Document = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    DocumentType = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false, defaultValue: "CPF"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customers_profiles_Id",
                        column: x => x.Id,
                        principalTable: "profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_methods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProfileId = table.Column<string>(type: "text", nullable: false),
                    PaymentType = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CardId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payment_methods_cards_CardId",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payment_methods_profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    Number = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Complement = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    Neighborhood = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    Country = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false, defaultValue: "BRL"),
                    PostalCode = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    ContactId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_addresses_profiles_Id",
                        column: x => x.Id,
                        principalTable: "profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    AreaCode = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    CountryCode = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false, defaultValue: "55"),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Mobile"),
                    ContactId = table.Column<string>(type: "text", nullable: false),
                    ContactId1 = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phones_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phones_contacts_ContactId1",
                        column: x => x.ContactId1,
                        principalTable: "contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    PaymentMethodId = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    TransactionDetails = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    TransactionId = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_payment_methods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "payment_methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    PaymentId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_ContactId",
                table: "addresses",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_PaymentId",
                table: "orders",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_ProductId",
                table: "orders",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payment_methods_CardId",
                table: "payment_methods",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payment_methods_ProfileId",
                table: "payment_methods",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_PaymentMethodId",
                table: "payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_phones_ContactId",
                table: "phones",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phones_ContactId1",
                table: "phones",
                column: "ContactId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_AccountId",
                table: "profiles",
                column: "AccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "phones");

            migrationBuilder.DropTable(
                name: "surcharges");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "payment_methods");

            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
