using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce_backend.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaComment_Cinemas_CinemaId",
                table: "CinemaComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaComment",
                table: "CinemaComment");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "MovieComments");

            migrationBuilder.RenameTable(
                name: "CinemaComment",
                newName: "CinemaComments");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "MovieComments",
                newName: "IX_MovieComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieId",
                table: "MovieComments",
                newName: "IX_MovieComments_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaComment_CinemaId",
                table: "CinemaComments",
                newName: "IX_CinemaComments_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieComments",
                table: "MovieComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaComments",
                table: "CinemaComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaComments_Cinemas_CinemaId",
                table: "CinemaComments",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Users_UserId",
                table: "MovieComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaComments_Cinemas_CinemaId",
                table: "CinemaComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Users_UserId",
                table: "MovieComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieComments",
                table: "MovieComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaComments",
                table: "CinemaComments");

            migrationBuilder.RenameTable(
                name: "MovieComments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "CinemaComments",
                newName: "CinemaComment");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComments_MovieId",
                table: "Comments",
                newName: "IX_Comments_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaComments_CinemaId",
                table: "CinemaComment",
                newName: "IX_CinemaComment_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaComment",
                table: "CinemaComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaComment_Cinemas_CinemaId",
                table: "CinemaComment",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
