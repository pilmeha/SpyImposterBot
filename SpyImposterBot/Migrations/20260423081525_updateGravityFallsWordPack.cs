using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class updateGravityFallsWordPack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "words",
                columns: new[] { "Id", "PackId", "word" },
                values: new object[,]
                {
                    { 117L, 3L, "Дипер" },
                    { 118L, 3L, "Мейбл" },
                    { 119L, 3L, "Дядя Стен" },
                    { 120L, 3L, "Венди" },
                    { 121L, 3L, "Робин" },
                    { 122L, 3L, "Бил Шифр" },
                    { 123L, 3L, "Блендин" },
                    { 124L, 3L, "Стенфорд" },
                    { 125L, 3L, "Гидеон" },
                    { 126L, 3L, "Зус" },
                    { 127L, 3L, "Гренда" },
                    { 128L, 3L, "Бабулита" },
                    { 129L, 3L, "Пасификка" },
                    { 130L, 3L, "Толстый шериф Плапс" },
                    { 131L, 3L, "Кенди" },
                    { 132L, 3L, "Худой шериф Дурланд" },
                    { 133L, 3L, "Старик Макгакет" },
                    { 134L, 3L, "Пухля" },
                    { 135L, 3L, "Козел" },
                    { 136L, 3L, "Тоби решительный" },
                    { 137L, 3L, "Русалдо" },
                    { 138L, 3L, "Гифани" },
                    { 139L, 3L, "Бей его" },
                    { 140L, 3L, "Тетя из кафе Сьзан" },
                    { 141L, 3L, "Тембри" },
                    { 142L, 3L, "Шандра Хименес" },
                    { 143L, 3L, "Томпсон" },
                    { 144L, 3L, "Крамбл Макс Кернишь" },
                    { 145L, 3L, "Мультимедведь" },
                    { 146L, 3L, "Мужикотавр" },
                    { 147L, 3L, "Малыш времени" },
                    { 148L, 3L, "Шмебьюлок" },
                    { 149L, 3L, "Бтс" },
                    { 150L, 3L, "Восковые статуи" },
                    { 151L, 3L, "Единорожки" },
                    { 152L, 3L, "Агенты ФБР Пауэрс (черные волосы)" },
                    { 153L, 3L, "Слепой Глазго (из культа)" },
                    { 154L, 3L, "Святой Валентин" },
                    { 155L, 3L, "Батя Гидеона Бад" },
                    { 156L, 3L, "Летувинский ловкая" },
                    { 157L, 3L, "Ручная ведьма" },
                    { 158L, 3L, "Циклоп пластилиновый" },
                    { 159L, 3L, "Татуированный друг Венди" },
                    { 160L, 3L, "Блондин (друг Венди)" },
                    { 161L, 3L, "Гигантская рука (Голова с рукой)" },
                    { 162L, 3L, "Арчибальд (дух лесоруб)" },
                    { 163L, 3L, "Тетя паук (бывшая Стена)" },
                    { 164L, 3L, "Замятыш (клон Дипера)" },
                    { 165L, 3L, "Основатель Гравити Фолз" },
                    { 166L, 3L, "Утка Холмс" },
                    { 167L, 3L, "Лилигоферы" },
                    { 168L, 3L, "Охраник бассейна" },
                    { 169L, 3L, "Заключенный бассейна" },
                    { 170L, 3L, "Тед Стрендж (брат Била)" },
                    { 171L, 3L, "Брат Зуса" },
                    { 172L, 3L, "Монстр который умеет перевоплощаться" },
                    { 173L, 3L, "Монстр из заставки, на 1ом кадре" },
                    { 174L, 3L, "Мирный жител, чувак с пиццей на футболке" },
                    { 175L, 3L, "Дипер кртуой" },
                    { 176L, 3L, "Судья кот из мира Мейбл" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 162L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 163L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 164L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 165L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 166L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 167L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 168L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 169L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 170L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 171L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 172L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 173L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 174L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 175L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 176L);
        }
    }
}
