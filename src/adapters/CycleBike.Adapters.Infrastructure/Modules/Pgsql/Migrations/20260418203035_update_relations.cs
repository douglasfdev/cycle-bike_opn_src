using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleBike.Adapters.Infrastructure.Modules.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class update_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phones_contacts_ContactId1",
                table: "phones");

            migrationBuilder.DropIndex(
                name: "IX_phones_ContactId",
                table: "phones");

            migrationBuilder.DropIndex(
                name: "IX_phones_ContactId1",
                table: "phones");

            migrationBuilder.DropColumn(
                name: "ContactId1",
                table: "phones");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "contacts",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);

            migrationBuilder.CreateIndex(
                name: "IX_phones_ContactId",
                table: "phones",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_phones_ContactId",
                table: "phones");

            migrationBuilder.AddColumn<string>(
                name: "ContactId1",
                table: "phones",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "contacts",
                type: "character varying(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50);

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

            migrationBuilder.AddForeignKey(
                name: "FK_phones_contacts_ContactId1",
                table: "phones",
                column: "ContactId1",
                principalTable: "contacts",
                principalColumn: "Id");
        }
    }
}
