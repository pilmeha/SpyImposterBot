using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class AddWordPairId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "pair_id",
                table: "words",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "word_packs",
                columns: new[] { "Id", "HasImage", "IsPublic", "Name", "SpyImageFileId", "UserId" },
                values: new object[] { 4L, false, true, "Парные слова", null, null });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 1L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 2L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 3L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 4L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 5L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 6L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 7L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 8L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 9L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 10L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 11L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 12L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 13L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 14L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 15L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 16L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 17L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 18L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 19L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 20L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 21L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 22L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 23L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 24L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 25L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 26L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 27L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 28L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 29L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 30L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 31L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 32L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 33L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 34L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 35L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 36L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 37L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 38L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 39L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 40L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 41L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 42L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 43L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 44L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 45L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 46L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 47L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 48L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 49L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 50L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 51L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 52L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 53L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 54L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 55L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 56L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 57L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 58L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 59L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 60L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 61L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 62L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 63L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 64L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 65L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 66L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 67L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 68L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 69L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 70L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 71L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 72L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 73L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 74L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 75L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 76L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 77L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 78L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 79L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 80L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 81L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 82L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 83L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 84L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 85L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 86L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 87L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 88L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 89L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 90L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 91L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 92L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 93L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 94L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 95L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 96L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 97L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 98L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 99L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 100L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 101L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 102L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 103L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 104L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 105L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 106L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 107L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 108L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 109L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 110L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 111L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 112L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 113L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 114L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 115L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 116L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 117L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 118L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 119L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 120L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 121L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 122L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 123L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 124L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 125L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 126L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 127L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 128L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 129L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 130L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 131L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 132L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 133L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 134L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 135L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 136L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 137L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 138L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 139L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 140L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 141L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 142L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 143L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 144L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 145L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 146L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 147L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 148L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 149L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 150L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 151L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 152L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 153L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 154L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 155L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 156L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 157L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 158L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 159L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 160L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 161L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 162L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 163L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 164L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 165L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 166L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 167L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 168L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 169L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 170L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 171L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 172L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 173L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 174L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 175L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 176L,
                column: "pair_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 177L,
                column: "pair_id",
                value: null);

            migrationBuilder.InsertData(
                table: "words",
                columns: new[] { "Id", "ImageFileId", "PackId", "pair_id", "word" },
                values: new object[,]
                {
                    { 178L, null, 4L, 1L, "Кошка" },
                    { 179L, null, 4L, 1L, "Собака" },
                    { 180L, null, 4L, 2L, "Чай" },
                    { 181L, null, 4L, 2L, "Кофе" },
                    { 182L, null, 4L, 3L, "Море" },
                    { 183L, null, 4L, 3L, "Океан" },
                    { 184L, null, 4L, 4L, "Самолет" },
                    { 185L, null, 4L, 4L, "Вертолет" },
                    { 186L, null, 4L, 5L, "Зима" },
                    { 187L, null, 4L, 5L, "Лето" },
                    { 188L, null, 4L, 6L, "Книга" },
                    { 189L, null, 4L, 6L, "Журнал" },
                    { 190L, null, 4L, 7L, "Кино" },
                    { 191L, null, 4L, 7L, "Сериал" },
                    { 192L, null, 4L, 8L, "Врач" },
                    { 193L, null, 4L, 8L, "Медсестра" },
                    { 194L, null, 4L, 9L, "Пицца" },
                    { 195L, null, 4L, 9L, "Бургер" },
                    { 196L, null, 4L, 10L, "Лев" },
                    { 197L, null, 4L, 10L, "Тигр" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "word_packs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 178L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 179L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 180L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 181L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 182L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 183L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 184L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 185L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 186L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 187L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 188L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 189L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 190L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 191L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 192L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 193L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 194L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 195L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 196L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 197L);

            migrationBuilder.DropColumn(
                name: "pair_id",
                table: "words");
        }
    }
}
