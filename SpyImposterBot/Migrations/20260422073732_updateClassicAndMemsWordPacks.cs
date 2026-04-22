using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class updateClassicAndMemsWordPacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 5L,
                column: "word",
                value: "Банк");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "PackId", "word" },
                values: new object[] { 1L, "Больница" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "PackId", "word" },
                values: new object[] { 1L, "Дом престарелых" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "PackId", "word" },
                values: new object[] { 1L, "Зоопарк" });

            migrationBuilder.InsertData(
                table: "words",
                columns: new[] { "Id", "PackId", "word" },
                values: new object[,]
                {
                    { 9L, 1L, "Казино" },
                    { 10L, 1L, "Киностудия" },
                    { 11L, 1L, "Кладбище" },
                    { 12L, 1L, "Метро" },
                    { 13L, 1L, "Музей" },
                    { 14L, 1L, "Отель" },
                    { 15L, 1L, "Ночной клуб" },
                    { 16L, 1L, "Пляж" },
                    { 17L, 1L, "Ресторан" },
                    { 18L, 1L, "Свадьба" },
                    { 19L, 1L, "Подводная лодка" },
                    { 20L, 1L, "Полицейский участок" },
                    { 21L, 1L, "Стадион" },
                    { 22L, 1L, "Супермаркет" },
                    { 23L, 1L, "Стадион" },
                    { 24L, 1L, "Театр" },
                    { 25L, 1L, "Тюрма" },
                    { 26L, 1L, "Университет" },
                    { 27L, 1L, "Церковь" },
                    { 28L, 1L, "Цирк-шапито" },
                    { 29L, 1L, "Шахта" },
                    { 30L, 1L, "Компьютер" },
                    { 31L, 2L, "Ждун" },
                    { 32L, 2L, "Орешки бигбоб" },
                    { 33L, 2L, "67" },
                    { 34L, 2L, "Орлица Зубарева" },
                    { 35L, 2L, "Кит ты маму мав" },
                    { 36L, 2L, "Что у вас тут происходит" },
                    { 37L, 2L, "Тетенька с красным кандибобером" },
                    { 38L, 2L, "Я мою посуду, я мою посуду" },
                    { 39L, 2L, "Я уже красный" },
                    { 40L, 2L, "Думайте" },
                    { 41L, 2L, "Что вы делаете в моем холодильнике" },
                    { 42L, 2L, "Шайлушай" },
                    { 43L, 2L, "Подозрения увеличись на 5%" },
                    { 44L, 2L, "Пацан он тебе тапок разорвал... я все склею" },
                    { 45L, 2L, "Пацаны Владивостока. ГАЗ знакомиться" },
                    { 46L, 2L, "Умный человек в очках" },
                    { 47L, 2L, "Сам решу" },
                    { 48L, 2L, "ПИЗ... ахахахххахах" },
                    { 49L, 2L, "52" },
                    { 50L, 2L, "Пацан, можешь дверь открыть от подъезда" },
                    { 51L, 2L, "Ой-ой собака ты куда? Ой песик" },
                    { 52L, 2L, "Сафонов оплатить" },
                    { 53L, 2L, "Оп, пьяный, оп потом такой, оп пьяный" },
                    { 54L, 2L, "Заяц с часами" },
                    { 55L, 2L, "Повар спрашивает повара" },
                    { 56L, 2L, "Арбуз арбуз привет" },
                    { 57L, 2L, "Чиловый чел" },
                    { 58L, 2L, "Humstercombat" },
                    { 59L, 2L, "Здесь черным по белому написано" },
                    { 60L, 2L, "PvZ Disco Zombie" },
                    { 61L, 2L, "Пфф, абоюдно" },
                    { 62L, 2L, "Шоты лысый, плаки плаки" },
                    { 63L, 2L, "Йогурт апетишка, я сбежала от P`Didy" },
                    { 64L, 2L, "До слобады доеду" },
                    { 65L, 2L, "Грустная песня мявмявмявмявмяв" },
                    { 66L, 2L, "Нагетсы Ковбой" },
                    { 67L, 2L, "Sad humster" },
                    { 68L, 2L, "Sigmaboy песня" },
                    { 69L, 2L, "Sigms" },
                    { 70L, 2L, "Дикий огурец" },
                    { 71L, 2L, "Телочку на веранде оу ес" },
                    { 72L, 2L, "Аааа а я думала сова" },
                    { 73L, 2L, "Але мужик ты норм? А.. нормано" },
                    { 74L, 2L, "Дед бомбом" },
                    { 75L, 2L, "Денчик слазиет" },
                    { 76L, 2L, "Книга братан, идика сюда" },
                    { 77L, 2L, "Это мой гриб, я его ем" },
                    { 78L, 2L, "Веном" },
                    { 79L, 2L, "Я не мэстный" },
                    { 80L, 2L, "Окак" },
                    { 81L, 2L, "Толик, это подъезд" },
                    { 82L, 2L, "Это фиаско братан" },
                    { 83L, 2L, "Шампунь Жумайсонба" },
                    { 84L, 2L, "Наталья морская пехота" },
                    { 85L, 2L, "Бэн (игра)" },
                    { 86L, 2L, "Чимин (Брайан Мапс)" },
                    { 87L, 2L, "Кчау Молния МакВин" },
                    { 88L, 2L, "ИванЗоло2004" },
                    { 89L, 2L, "Доброе утро мопсы" },
                    { 90L, 2L, "Широкий Путин" },
                    { 91L, 2L, "О вы из англии" },
                    { 92L, 2L, "Зачем? (лощадь у моря)" },
                    { 93L, 2L, "Гроб (африканцы несту)" },
                    { 94L, 2L, "Да ну нахуй бля - забор закрыт" },
                    { 95L, 2L, "Да яж пошутил" },
                    { 96L, 2L, "Можно, а зачем?" },
                    { 97L, 2L, "Чел хорош" },
                    { 98L, 2L, "Кринж" },
                    { 99L, 2L, "Мем Ок Ок" },
                    { 100L, 2L, "Извинись" },
                    { 101L, 2L, "Ты большая, молодец!" },
                    { 102L, 2L, "Что самое главное в женщине? Душа" },
                    { 103L, 2L, "Чувак это рэпчик" },
                    { 104L, 2L, "Как сказать-то" },
                    { 105L, 2L, "Это печально" },
                    { 106L, 2L, "Веселый/Веселый(перечеркнуто)" },
                    { 107L, 2L, "О он съебался мем про носорога" },
                    { 108L, 2L, "Упал вставай, вставай упай, чокопай" },
                    { 109L, 2L, "Мэлстрой" },
                    { 110L, 2L, "Возьми телефон детка" },
                    { 111L, 2L, "Чипсеки" },
                    { 112L, 2L, "Тише, узбеки спят" },
                    { 113L, 2L, "Мактрахер" },
                    { 114L, 2L, "Пенсия хайпует" },
                    { 115L, 2L, "Спидран по майнкрафту погнали" },
                    { 116L, 2L, "Бургер Кинг говно" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 5L,
                column: "word",
                value: "Компьютер");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "PackId", "word" },
                values: new object[] { 2L, "Ждун" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "PackId", "word" },
                values: new object[] { 2L, "Чел хорош" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "PackId", "word" },
                values: new object[] { 2L, "Кринж" });
        }
    }
}
