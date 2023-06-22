using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteVagaDevPleno.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "categoryid",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fk_category",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryid",
                table: "Product",
                column: "categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryid",
                table: "Product",
                column: "categoryid",
                principalTable: "Category",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_categoryid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "categoryid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "fk_category",
                table: "Product");
        }
    }
}
