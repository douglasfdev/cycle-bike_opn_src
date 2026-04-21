using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class update_hax_length_user_id_on_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 27, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 954, DateTimeKind.Utc).AddTicks(8015),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 27, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "trials",
                type: "character varying(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(7332),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 35, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(6951),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 35, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1319),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1000),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8393),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8008),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4971),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4629),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8923),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8566),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2776),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2448),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(7127),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(6768),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3833),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3485),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7926),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7428),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(8599));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8459),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8081),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(2274),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(1283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(1916),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(2076),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(1669),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(5155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(2512),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "accesscontrols",
                type: "character varying(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(3211),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 33, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(2799),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 33, DateTimeKind.Utc).AddTicks(6262));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 27, DateTimeKind.Utc).AddTicks(2323),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 954, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 27, DateTimeKind.Utc).AddTicks(1987),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 954, DateTimeKind.Utc).AddTicks(8015));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "trials",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 35, DateTimeKind.Utc).AddTicks(2318),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 35, DateTimeKind.Utc).AddTicks(1914),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 962, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1543),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 51, DateTimeKind.Utc).AddTicks(1198),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 979, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6725),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 18, DateTimeKind.Utc).AddTicks(6335),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 945, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3696),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 45, DateTimeKind.Utc).AddTicks(3325),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 973, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2650),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 32, DateTimeKind.Utc).AddTicks(2268),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 959, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1789),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 48, DateTimeKind.Utc).AddTicks(1456),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 976, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6709),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 49, DateTimeKind.Utc).AddTicks(6327),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 977, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4710),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 43, DateTimeKind.Utc).AddTicks(4340),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 971, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(9032),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 9, DateTimeKind.Utc).AddTicks(8599),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 937, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(2373),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 31, DateTimeKind.Utc).AddTicks(1977),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(1283),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 47, DateTimeKind.Utc).AddTicks(920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 975, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(6122),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 30, DateTimeKind.Utc).AddTicks(5700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 958, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(8496),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 2, DateTimeKind.Utc).AddTicks(6143),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 930, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "accesscontrols",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 33, DateTimeKind.Utc).AddTicks(6646),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 34, 55, 33, DateTimeKind.Utc).AddTicks(6262),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 47, 49, 961, DateTimeKind.Utc).AddTicks(2799));
        }
    }
}
