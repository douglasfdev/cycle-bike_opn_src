using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class add_trial_and_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "surcharges",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "surcharges",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "profiles",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "profiles",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "products",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "products",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "phones",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "phones",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "payments",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "payments",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "payment_methods",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "payment_methods",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "orders",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "orders",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "customers",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "customers",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "contacts",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "contacts",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "cards",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "cards",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "addresses",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "addresses",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "accounts",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "accounts",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "surcharges");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "surcharges");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "phones");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "phones");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "payment_methods");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "payment_methods");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "accounts");
        }
    }
}
