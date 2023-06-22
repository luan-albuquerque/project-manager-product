using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteVagaDevPleno.Migrations
{
    /// <inheritdoc />
    public partial class CreateCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Category",
               columns: table => new
               {
                   id = table.Column<string>(type: "text", nullable: false),
                   description = table.Column<string>(type: "text", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Category", x => x.id);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
               name: "Category");

        }
    }
}
