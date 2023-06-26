using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteVagaDevPleno.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "is_enabled", "name", "password" },
                values: new object[] { "e495bb91-4646-4403-a485-0c7c80f0878f", "bugas@gmail.com", true, "bugas", "$2a$11$hjKPMV.DGEhofuBjo4ac2.43dpfWg.MLrhJEa60wdCRsdUwfpLwja" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "e495bb91-4646-4403-a485-0c7c80f0878f");
        }
    }
}
