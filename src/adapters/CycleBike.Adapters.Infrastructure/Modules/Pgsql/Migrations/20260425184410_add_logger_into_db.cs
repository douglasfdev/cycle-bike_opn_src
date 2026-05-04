using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class add_logger_into_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 89, DateTimeKind.Utc).AddTicks(7612),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 89, DateTimeKind.Utc).AddTicks(7277),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 98, DateTimeKind.Utc).AddTicks(2989),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 98, DateTimeKind.Utc).AddTicks(2621),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(4711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 118, DateTimeKind.Utc).AddTicks(7656),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 118, DateTimeKind.Utc).AddTicks(7338),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(1865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 81, DateTimeKind.Utc).AddTicks(2376),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(1309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 81, DateTimeKind.Utc).AddTicks(1999),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 112, DateTimeKind.Utc).AddTicks(6697),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 112, DateTimeKind.Utc).AddTicks(6358),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(7848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 95, DateTimeKind.Utc).AddTicks(3921),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(7317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 95, DateTimeKind.Utc).AddTicks(3563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 115, DateTimeKind.Utc).AddTicks(7389),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 115, DateTimeKind.Utc).AddTicks(6433),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 117, DateTimeKind.Utc).AddTicks(3371),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 117, DateTimeKind.Utc).AddTicks(2994),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(5904));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 110, DateTimeKind.Utc).AddTicks(8778),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 110, DateTimeKind.Utc).AddTicks(8423),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 72, DateTimeKind.Utc).AddTicks(1854),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 72, DateTimeKind.Utc).AddTicks(1494),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 94, DateTimeKind.Utc).AddTicks(3441),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 94, DateTimeKind.Utc).AddTicks(3048),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 114, DateTimeKind.Utc).AddTicks(4654),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 114, DateTimeKind.Utc).AddTicks(4251),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 93, DateTimeKind.Utc).AddTicks(6948),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 93, DateTimeKind.Utc).AddTicks(6252),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 643, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 64, DateTimeKind.Utc).AddTicks(3530),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 64, DateTimeKind.Utc).AddTicks(601),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 96, DateTimeKind.Utc).AddTicks(8132),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 96, DateTimeKind.Utc).AddTicks(7752),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1251));

            migrationBuilder.CreateTable(
                name: "logentry",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 50, nullable: false),
                    ApplicationName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Level = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    Category = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    Exception = table.Column<string>(type: "text", unicode: false, maxLength: 1024, nullable: true),
                    Properties = table.Column<IDictionary<string, object>>(type: "jsonb", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(1024)", unicode: false, maxLength: 1024, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 102, DateTimeKind.Utc).AddTicks(6848)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 102, DateTimeKind.Utc).AddTicks(7182))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logentry", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logentry");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6976),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 89, DateTimeKind.Utc).AddTicks(7612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 640, DateTimeKind.Utc).AddTicks(6609),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 89, DateTimeKind.Utc).AddTicks(7277));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(5072),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 98, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "trials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 648, DateTimeKind.Utc).AddTicks(4711),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 98, DateTimeKind.Utc).AddTicks(2621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(2200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 118, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surcharges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 666, DateTimeKind.Utc).AddTicks(1865),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 118, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(1309),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 81, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 632, DateTimeKind.Utc).AddTicks(935),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 81, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(9720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 112, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 658, DateTimeKind.Utc).AddTicks(7848),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 112, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(7317),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 95, DateTimeKind.Utc).AddTicks(3921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "phones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 645, DateTimeKind.Utc).AddTicks(6968),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 95, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1927),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 115, DateTimeKind.Utc).AddTicks(7389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 663, DateTimeKind.Utc).AddTicks(1555),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 115, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(6253),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 117, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "payment_methods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 664, DateTimeKind.Utc).AddTicks(5904),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 117, DateTimeKind.Utc).AddTicks(2994));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9808),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 110, DateTimeKind.Utc).AddTicks(8778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 656, DateTimeKind.Utc).AddTicks(9416),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 110, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4436),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 72, DateTimeKind.Utc).AddTicks(1854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 623, DateTimeKind.Utc).AddTicks(4081),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 72, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(6196),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 94, DateTimeKind.Utc).AddTicks(3441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(5796),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 94, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9687),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 114, DateTimeKind.Utc).AddTicks(4654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 661, DateTimeKind.Utc).AddTicks(9351),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 114, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 644, DateTimeKind.Utc).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 93, DateTimeKind.Utc).AddTicks(6948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 643, DateTimeKind.Utc).AddTicks(9941),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 93, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(9221),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 64, DateTimeKind.Utc).AddTicks(3530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 616, DateTimeKind.Utc).AddTicks(6613),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 64, DateTimeKind.Utc).AddTicks(601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1642),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 96, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "accesscontrols",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 21, 20, 53, 31, 647, DateTimeKind.Utc).AddTicks(1251),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 4, 25, 18, 44, 10, 96, DateTimeKind.Utc).AddTicks(7752));
        }
    }
}
