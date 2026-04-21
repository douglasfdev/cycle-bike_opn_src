using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class add_accesscontrol_context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1543),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "surcharges",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "surcharges",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1198),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "surcharges",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6725),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "profiles",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "profiles",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6335),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "profiles",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "profiles",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3696),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "products",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3325),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "products",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2650),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "phones",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "phones",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2268),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "phones",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "phones",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1789),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethodId",
                table: "payments",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "payments",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "payments",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1456),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payments",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6709),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "payment_methods",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "payment_methods",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "payment_methods",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6327),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "payment_methods",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payment_methods",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4710),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "orders",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "orders",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "orders",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "orders",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "orders",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4340),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "orders",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(9032),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "customers",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "customers",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(8599),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "customers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(2373),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "contacts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "contacts",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(1977),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "contacts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(1283),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "cards",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "cards",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "cards",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(6122),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "addresses",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(5700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "addresses",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "addresses",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(8496),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "accounts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "accounts",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(6143),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "accounts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Username = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 27, DateTimeKind.Utc).AddTicks(1987)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 27, DateTimeKind.Utc).AddTicks(2323))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "accesscontrols",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LastAccess = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 33, DateTimeKind.Utc).AddTicks(6262)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 33, DateTimeKind.Utc).AddTicks(6646))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accesscontrols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accesscontrols_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TrialStartDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 40, nullable: false),
                    TrialEndDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 40, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    TrialDays = table.Column<int>(type: "integer", maxLength: 3, nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 35, DateTimeKind.Utc).AddTicks(1914)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 35, DateTimeKind.Utc).AddTicks(2318))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trials_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accesscontrols_UserId",
                table: "accesscontrols",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_trials_UserId",
                table: "trials",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accesscontrols");

            migrationBuilder.DropTable(
                name: "trials");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1543));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "surcharges",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "surcharges",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "surcharges",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "profiles",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "profiles",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "profiles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "profiles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3696));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "products",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "products",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3325));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "phones",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "phones",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2268));

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "phones",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "phones",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1789));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethodId",
                table: "payments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "payments",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "payments",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "payment_methods",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "payment_methods",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "payment_methods",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "payment_methods",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payment_methods",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "orders",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "orders",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "customers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "customers",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(8599));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "customers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "contacts",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "contacts",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "contacts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(1283));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "cards",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "cards",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "cards",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "addresses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "addresses",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "addresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "addresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "accounts",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "accounts",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "accounts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}
