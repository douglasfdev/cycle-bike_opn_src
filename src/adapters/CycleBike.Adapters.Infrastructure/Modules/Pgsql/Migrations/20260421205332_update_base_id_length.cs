using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class update_base_id_length : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6976),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 954, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6609),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 954, DateTimeKind.Utc).AddTicks(8015));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(5072),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(4711),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "trials",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(2200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(1865),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "surcharges",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(1309),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(935),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "profiles",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "profiles",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(9720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(7848),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "products",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(7317),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(6968),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "phones",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "phones",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1927),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethodId",
                table: "payments",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1555),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payments",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(6253),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "payment_methods",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(5904),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "payment_methods",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payment_methods",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9808),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3833));

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "orders",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "orders",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "orders",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9416),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "orders",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4436),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4081),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "customers",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(6196),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(5796),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "contacts",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9687),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9351),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "cards",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 643, DateTimeKind.Utc).AddTicks(9941),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "addresses",
                type: "character varying(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "addresses",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(9221),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(6613),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "accounts",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1642),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1251),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(2799));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "accesscontrols",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 954, DateTimeKind.Utc).AddTicks(8348),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 954, DateTimeKind.Utc).AddTicks(8015),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6609));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(7332),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(6951),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(4711));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "trials",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1319),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1000),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(1865));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "surcharges",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8393),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(1309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8008),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(935));

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "profiles",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "profiles",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4971),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4629),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(7848));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "products",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8923),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(7317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8566),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "phones",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "phones",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2776),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethodId",
                table: "payments",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2448),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payments",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(7127),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.AlterColumn<string>(
                name: "ProfileId",
                table: "payment_methods",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(6768),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(5904));

            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "payment_methods",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "payment_methods",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3833),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9808));

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "orders",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "orders",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "orders",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3485),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "orders",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7926),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7428),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "customers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8459),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8081),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "contacts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(2274),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(1916),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "cards",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(2076),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(1669),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 643, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "addresses",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "addresses",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(5155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(2512),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "accounts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(3211),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(2799),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1251));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "accesscontrols",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);
        }
    }
}
