using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class changeGameSessionAndAddWordPacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "word_packs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Word",
                table: "game_sessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "word_packs",
                columns: new[] { "Id", "IsPublic", "Name", "UserId" },
                values: new object[,]
                {
                    { 1L, true, "Классика", null },
                    { 2L, true, "Мемы", null }
                });

            migrationBuilder.InsertData(
                table: "words",
                columns: new[] { "Id", "PackId", "word" },
                values: new object[,]
                {
                    { 1L, 1L, "Париж" },
                    { 2L, 1L, "Самолет" },
                    { 3L, 1L, "Школа" },
                    { 4L, 1L, "Космос" },
                    { 5L, 1L, "Компьютер" },
                    { 6L, 2L, "Ждун" },
                    { 7L, 2L, "Чел хорош" },
                    { 8L, 2L, "Кринж" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DropColumn(
                name: "Word",
                table: "game_sessions");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "word_packs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
