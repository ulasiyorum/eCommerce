using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce_backend.Migrations
{
    /// <inheritdoc />
    public partial class NewCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActorsMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActorsMovies");
        }
    }
}
