using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteVagaDevPleno.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFkInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fk_category",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fk_category",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
