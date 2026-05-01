using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpyImposterBot.Migrations
{
    /// <inheritdoc />
    public partial class addMemsImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 31L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIEuGnxd5EmGZNV6BDjcU8V59bup4diAAKcGGsbY6CJS3v4KcybGiPCAQADAgADeQADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 32L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIEvGnxeFClfZVSC9hvIudGtYL7Cl1WAAKdGGsbY6CJSx7Gm_Pz_EaPAQADAgADeQADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 33L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIEwGnxeLwKs5F8AbTBWNvI3gh-L4qUAAKeGGsbY6CJS7UbUf6rX1BIAQADAgADeAADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 34L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIExGnxeP7Y8jMnc0X8d67RU4P35TWoAAKfGGsbY6CJS85f6AGh1UaGAQADAgADeQADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 35L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIEyGnxeT7iKOIv1GcAAYK6cvgzatTY0AACoRhrG2OgiUvfmJAcNvPnhgEAAwIAA3kAAzsE");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 36L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIEzGnxeYJPtZS5IfSWG3iZRKSrGpO7AAKjGGsbY6CJS1rBHrK9yFpBAQADAgADeQADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 37L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIE0GnxebQLpaJ7j9GCTlXFdOUc0riBAAKkGGsbY6CJS210Dub6A9WdAQADAgADeAADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "ImageFileId", "word" },
                values: new object[] { "AgACAgIAAxkBAAIE1GnxefjcEOOpGtuCHFRJ3N9Pq64rAAKlGGsbY6CJSy803qjoyQtIAQADAgADeAADOwQ", "Я мою посуду" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "ImageFileId", "word" },
                values: new object[] { "AgACAgIAAxkBAAIE2GnxejSWTYjXGQ5-gnil4RKlgRbaAAKpGGsbY6CJS_f300jBemV3AQADAgADeAADOwQ", "Я уже красный, культурно не получиться" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 40L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIE3GnxemEmIKcKKznSietNPIw-VDFIAAKqGGsbY6CJSyBoGOJZQPZTAQADAgADbQADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 41L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIE4Gnxen7Lb_89K352CfPg2OOk4KFzAAKrGGsbY6CJS-kfwzObiQJYAQADAgADeAADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 42L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIE5GnxeqwWSZyjAAFjHkXP4hKg8VNZDgACrBhrG2OgiUvoHr3XNnv46gEAAwIAA3kAAzsE");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 44L,
                column: "word",
                value: "Он тебе что, тапок порвал, пацан? ... Нет, я все склею! ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 45L,
                column: "word",
                value: "Пацаны Владивостока, ГАЗ знакомиться А чето скучненько");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 47L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIE6GnxfFoi3rsj4sY_03VK7FFOwvTUAAKuGGsbY6CJS66IjEbqWl4xAQADAgADeQADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 50L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIE7GnxfRESD7pszsOZRrvIO1wERwRHAAKwGGsbY6CJSyXvOGEH7yhnAQADAgADeAADOwQ");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 51L,
                column: "ImageFileId",
                value: "AgACAgIAAxkBAAIE8GnxfS-wyJpIqVPJxLphvwJ3MlmwAAKxGGsbY6CJSyIi9rMjApLFAQADAgADeAADOwQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ImageFileId", "word" },
                values: new object[] { null, "Я мою посуду, я мою посуду" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "ImageFileId", "word" },
                values: new object[] { null, "Я уже красный" });

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
                keyValue: 44L,
                column: "word",
                value: "Пацан он тебе тапок разорвал... я все склею");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 45L,
                column: "word",
                value: "Пацаны Владивостока. ГАЗ знакомиться");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "Id",
                keyValue: 47L,
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
        }
    }
}
