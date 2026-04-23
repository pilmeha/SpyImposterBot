using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class changeSpyImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "SpyImageFileId",
                value: "AgACAgIAAxkBAAIDcWnqFF73-ck3yCkIGaC-ILiGbz8vAAIfE2sbeT1ZS65DyBa6QXhIAQADAgADeQADOwQ");

            migrationBuilder.UpdateData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "SpyImageFileId",
                value: "AgACAgIAAxkBAAIDcWnqFF73-ck3yCkIGaC-ILiGbz8vAAIfE2sbeT1ZS65DyBa6QXhIAQADAgADeQADOwQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "SpyImageFileId",
                value: "AgACAgIAAxkBAAIDQ2nqCqRYOei03WQwOZ3j9zocjy-3AALdEmsbeT1ZSzDbq3D730zzAQADAgADeAADOwQ");

            migrationBuilder.UpdateData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "SpyImageFileId",
                value: "AgACAgIAAxkBAAIDQ2nqCqRYOei03WQwOZ3j9zocjy-3AALdEmsbeT1ZSzDbq3D730zzAQADAgADeAADOwQ");
        }
    }
}
