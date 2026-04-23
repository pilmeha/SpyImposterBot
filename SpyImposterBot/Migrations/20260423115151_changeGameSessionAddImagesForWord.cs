using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class changeGameSessionAddImagesForWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "game_mode",
                table: "game_sessions");

            migrationBuilder.RenameColumn(
                name: "Word",
                table: "game_sessions",
                newName: "word");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileId",
                table: "words",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasImage",
                table: "word_packs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SpyImageFileId",
                table: "word_packs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_image",
                table: "game_sessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "image_file_id",
                table: "game_sessions",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HasImage", "SpyImageFileId" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "HasImage", "SpyImageFileId" },
                values: new object[] { true, null });

            migrationBuilder.InsertData(
                table: "word_packs",
                columns: new[] { "Id", "HasImage", "IsPublic", "Name", "SpyImageFileId", "UserId" },
                values: new object[] { 3L, true, true, "Гравити Фолз", null, null });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 5L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 6L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 7L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 8L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 9L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 10L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 11L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 12L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 13L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 14L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 15L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 16L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 17L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 18L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 19L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 20L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 21L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 22L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 23L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 24L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 25L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 26L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 27L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 28L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 29L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 30L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 31L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 32L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 33L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 34L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 35L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 36L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 37L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 38L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 39L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 40L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 41L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 42L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 43L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 44L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 45L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 46L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 47L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 48L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 49L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 50L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 51L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 52L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 53L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 54L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 55L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 56L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 57L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 58L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 59L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 60L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 61L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 62L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 63L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 64L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 65L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 66L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 67L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 68L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 69L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 70L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 71L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 72L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 73L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 74L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 75L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 76L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 77L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 78L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 79L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 80L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 81L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 82L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 83L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 84L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 85L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 86L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 87L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 88L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 89L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 90L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 91L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 92L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 93L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 94L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 95L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 96L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 97L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 98L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 99L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 100L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 101L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 102L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 103L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 104L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 105L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 106L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 107L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 108L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 109L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 110L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 111L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 112L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 113L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 114L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 115L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 116L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 117L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 118L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 119L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 120L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 121L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 122L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 123L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 124L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 125L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 126L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 127L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 128L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 129L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 130L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 131L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 132L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 133L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 134L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 135L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 136L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 137L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 138L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 139L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 140L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 141L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 142L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 143L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 144L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 145L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 146L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 147L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 148L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 149L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 150L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 151L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 152L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 153L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 154L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 155L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 156L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 157L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 158L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 159L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 160L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 161L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 162L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 163L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 164L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 165L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 166L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 167L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 168L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 169L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 170L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 171L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 172L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 173L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 174L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 175L,
                column: "ImageFileId",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 176L,
                column: "ImageFileId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "ImageFileId",
                table: "words");

            migrationBuilder.DropColumn(
                name: "HasImage",
                table: "word_packs");

            migrationBuilder.DropColumn(
                name: "SpyImageFileId",
                table: "word_packs");

            migrationBuilder.DropColumn(
                name: "has_image",
                table: "game_sessions");

            migrationBuilder.DropColumn(
                name: "image_file_id",
                table: "game_sessions");

            migrationBuilder.RenameColumn(
                name: "word",
                table: "game_sessions",
                newName: "Word");

            migrationBuilder.AddColumn<string>(
                name: "game_mode",
                table: "game_sessions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
