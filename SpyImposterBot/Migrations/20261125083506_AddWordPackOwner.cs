using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class AddWordPackOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_word_packs_UserId",
                table: "word_packs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_word_packs_users_UserId",
                table: "word_packs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_word_packs_users_UserId",
                table: "word_packs");

            migrationBuilder.DropIndex(
                name: "IX_word_packs_UserId",
                table: "word_packs");
        }
    }
}
