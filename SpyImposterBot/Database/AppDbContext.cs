using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace SpyImposterBot.Database
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<WordPack> WordPacks => Set<WordPack>();
        public DbSet<Word> Words => Set<Word>();
        public DbSet<GameSession> GameSessions => Set<GameSession>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameSession>(entity =>
            {
                entity.ToTable("game_sessions");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedBy).HasColumnName("created_by");
                entity.Property(e => e.PackId).HasColumnName("pack_id");
                entity.Property(e => e.PlayersData)
                    .HasColumnName("players_data")
                    .HasColumnType("jsonb");
                entity.Property(e => e.CurrentPlayerIndex).HasColumnName("current_player_index");
                entity.Property(e => e.Status)
                    .HasConversion<string>()
                    .HasColumnName("status");

                entity.Property(e => e.Word).HasColumnName("word");
                entity.Property(e => e.ImageFileId).HasColumnName("image_file_id");
                entity.Property(e => e.HasImages).HasColumnName("has_image");
            });

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Word>().ToTable("words");
            modelBuilder.Entity<WordPack>().ToTable("word_packs");

            modelBuilder.Entity<User>()
                .HasIndex(x => x.TelegramId)
                .IsUnique();

            modelBuilder.Entity<Word>()
                .Property(x => x.Value)
                .HasColumnName("word");
            
            modelBuilder.Entity<Word>()
                .Property(x => x.PairId)
                .HasColumnName("pair_id");

            modelBuilder.Entity<GameSession>()
                .Property(x => x.PlayersData)
                .HasColumnType("jsonb");

            modelBuilder.Entity<WordPack>().HasData(
                new WordPack { Id = 1, Name = "Классика", IsPublic = true, HasImage = false },
                new WordPack { Id = 2, Name = "Мемы", IsPublic = true, HasImage = true, SpyImageFileId = "AgACAgIAAxkBAAIDcWnqFF73-ck3yCkIGaC-ILiGbz8vAAIfE2sbeT1ZS65DyBa6QXhIAQADAgADeQADOwQ" },
                new WordPack { Id = 3, Name = "Гравити Фолз", IsPublic = true, HasImage = true, SpyImageFileId = "AgACAgIAAxkBAAIDcWnqFF73-ck3yCkIGaC-ILiGbz8vAAIfE2sbeT1ZS65DyBa6QXhIAQADAgADeQADOwQ" },
                new WordPack { Id = 4, Name = "Парные слова", IsPublic = true, HasImage = false }
            );

            modelBuilder.Entity<Word>().HasData(
                // classic
                new Word { Id = 1, PackId = 1, Value = "Париж" },
                new Word { Id = 2, PackId = 1, Value = "Самолет" },
                new Word { Id = 3, PackId = 1, Value = "Школа" },
                new Word { Id = 4, PackId = 1, Value = "Космос" },
                new Word { Id = 5, PackId = 1, Value = "Банк" },
                new Word { Id = 6, PackId = 1, Value = "Больница" },
                new Word { Id = 7, PackId = 1, Value = "Дом престарелых" },
                new Word { Id = 8, PackId = 1, Value = "Зоопарк" },
                new Word { Id = 9, PackId = 1, Value = "Казино" },

                new Word { Id = 10, PackId = 1, Value = "Киностудия" },
                new Word { Id = 11, PackId = 1, Value = "Кладбище" },
                new Word { Id = 12, PackId = 1, Value = "Метро" },
                new Word { Id = 13, PackId = 1, Value = "Музей" },
                new Word { Id = 14, PackId = 1, Value = "Отель" },
                new Word { Id = 15, PackId = 1, Value = "Ночной клуб" },
                new Word { Id = 16, PackId = 1, Value = "Пляж" },
                new Word { Id = 17, PackId = 1, Value = "Ресторан" },
                new Word { Id = 18, PackId = 1, Value = "Свадьба" },
                new Word { Id = 19, PackId = 1, Value = "Подводная лодка" },

                new Word { Id = 20, PackId = 1, Value = "Полицейский участок" },
                new Word { Id = 21, PackId = 1, Value = "Стадион" },
                new Word { Id = 22, PackId = 1, Value = "Супермаркет" },
                new Word { Id = 23, PackId = 1, Value = "Стадион" },
                new Word { Id = 24, PackId = 1, Value = "Театр" },
                new Word { Id = 25, PackId = 1, Value = "Тюрма" },
                new Word { Id = 26, PackId = 1, Value = "Университет" },
                new Word { Id = 27, PackId = 1, Value = "Церковь" },
                new Word { Id = 28, PackId = 1, Value = "Цирк-шапито" },
                new Word { Id = 29, PackId = 1, Value = "Шахта" },
                new Word { Id = 30, PackId = 1, Value = "Компьютер" },

                // mems
                new Word { Id = 31, PackId = 2, Value = "Ждун", ImageFileId = "AgACAgIAAxkBAAIEuGnxd5EmGZNV6BDjcU8V59bup4diAAKcGGsbY6CJS3v4KcybGiPCAQADAgADeQADOwQ" },
                new Word { Id = 32, PackId = 2, Value = "Орешки бигбоб", ImageFileId = "AgACAgIAAxkBAAIEvGnxeFClfZVSC9hvIudGtYL7Cl1WAAKdGGsbY6CJSx7Gm_Pz_EaPAQADAgADeQADOwQ" },
                new Word { Id = 33, PackId = 2, Value = "67", ImageFileId = "AgACAgIAAxkBAAIEwGnxeLwKs5F8AbTBWNvI3gh-L4qUAAKeGGsbY6CJS7UbUf6rX1BIAQADAgADeAADOwQ" },
                new Word { Id = 34, PackId = 2, Value = "Орлица Зубарева", ImageFileId = "AgACAgIAAxkBAAIExGnxeP7Y8jMnc0X8d67RU4P35TWoAAKfGGsbY6CJS85f6AGh1UaGAQADAgADeQADOwQ" },
                new Word { Id = 35, PackId = 2, Value = "Кит ты маму мав", ImageFileId = "AgACAgIAAxkBAAIEyGnxeT7iKOIv1GcAAYK6cvgzatTY0AACoRhrG2OgiUvfmJAcNvPnhgEAAwIAA3kAAzsE" },
                new Word { Id = 36, PackId = 2, Value = "Что у вас тут происходит", ImageFileId = "AgACAgIAAxkBAAIEzGnxeYJPtZS5IfSWG3iZRKSrGpO7AAKjGGsbY6CJS1rBHrK9yFpBAQADAgADeQADOwQ" },
                new Word { Id = 37, PackId = 2, Value = "Тетенька с красным кандибобером", ImageFileId = "AgACAgIAAxkBAAIE0GnxebQLpaJ7j9GCTlXFdOUc0riBAAKkGGsbY6CJS210Dub6A9WdAQADAgADeAADOwQ" },
                new Word { Id = 38, PackId = 2, Value = "Я мою посуду", ImageFileId = "AgACAgIAAxkBAAIE1GnxefjcEOOpGtuCHFRJ3N9Pq64rAAKlGGsbY6CJSy803qjoyQtIAQADAgADeAADOwQ" },
                new Word { Id = 39, PackId = 2, Value = "Я уже красный, культурно не получиться", ImageFileId = "AgACAgIAAxkBAAIE2GnxejSWTYjXGQ5-gnil4RKlgRbaAAKpGGsbY6CJS_f300jBemV3AQADAgADeAADOwQ" },

                new Word { Id = 40, PackId = 2, Value = "Думайте", ImageFileId = "AgACAgIAAxkBAAIE3GnxemEmIKcKKznSietNPIw-VDFIAAKqGGsbY6CJSyBoGOJZQPZTAQADAgADbQADOwQ" },
                new Word { Id = 41, PackId = 2, Value = "Что вы делаете в моем холодильнике", ImageFileId = "AgACAgIAAxkBAAIE4Gnxen7Lb_89K352CfPg2OOk4KFzAAKrGGsbY6CJS-kfwzObiQJYAQADAgADeAADOwQ" },
                new Word { Id = 42, PackId = 2, Value = "Шайлушай", ImageFileId = "AgACAgIAAxkBAAIE5GnxeqwWSZyjAAFjHkXP4hKg8VNZDgACrBhrG2OgiUvoHr3XNnv46gEAAwIAA3kAAzsE" },
                new Word { Id = 43, PackId = 2, Value = "Подозрения увеличись на 5%" },
                new Word { Id = 44, PackId = 2, Value = "Он тебе что, тапок порвал, пацан? ... Нет, я все склею! " },
                new Word { Id = 45, PackId = 2, Value = "Пацаны Владивостока, ГАЗ знакомиться А чето скучненько" },
                new Word { Id = 46, PackId = 2, Value = "Умный человек в очках" },
                new Word { Id = 47, PackId = 2, Value = "Сам решу", ImageFileId = "AgACAgIAAxkBAAIE6GnxfFoi3rsj4sY_03VK7FFOwvTUAAKuGGsbY6CJS66IjEbqWl4xAQADAgADeQADOwQ" },
                new Word { Id = 48, PackId = 2, Value = "ПИЗ... ахахахххахах" },
                new Word { Id = 49, PackId = 2, Value = "52" },

                new Word { Id = 50, PackId = 2, Value = "Пацан, можешь дверь открыть от подъезда", ImageFileId = "AgACAgIAAxkBAAIE7GnxfRESD7pszsOZRrvIO1wERwRHAAKwGGsbY6CJSyXvOGEH7yhnAQADAgADeAADOwQ" },
                new Word { Id = 51, PackId = 2, Value = "Ой-ой собака ты куда? Ой песик", ImageFileId = "AgACAgIAAxkBAAIE8GnxfS-wyJpIqVPJxLphvwJ3MlmwAAKxGGsbY6CJSyIi9rMjApLFAQADAgADeAADOwQ" },
                new Word { Id = 52, PackId = 2, Value = "Сафонов оплатить", ImageFileId = "AgACAgIAAxkBAAIFKWnzNrM_ib7ecbAbJL7ZhtWeEx9uAAJZFmsb2UeZS1Yawb-dfLLvAQADAgADeAADOwQ" },
                new Word { Id = 53, PackId = 2, Value = "Оп, пьяный, оп потом такой, оп пьяный", ImageFileId = "AgACAgIAAxkBAAIFLWnzNuKHrHgGX_LW-ritqFQUEx4SAAKYE2sbsmSZSwQfcY4HUHa-AQADAgADeAADOwQ" },
                new Word { Id = 54, PackId = 2, Value = "Заяц с часами", ImageFileId = "AgACAgIAAxkBAAIFMWnzNxC14dxl9aezozWrzug8nsZQAAKZE2sbsmSZS-BvMj_EnhtaAQADAgADeAADOwQ" },
                new Word { Id = 55, PackId = 2, Value = "Повар спрашивает повара", ImageFileId = "AgACAgIAAxkBAAIFNWnzNzj1MLLz4H_PEdOVYNmjRPFXAAKaE2sbsmSZS_knAAHoPKwHEgEAAwIAA3gAAzsE" },
                new Word { Id = 56, PackId = 2, Value = "Арбуз арбуз привет", ImageFileId = "AgACAgIAAxkBAAIFOWnzN1kD_4Dw5NaS1_t34gABPzF-sQACnBNrG7JkmUvJZQH3h9VhCgEAAwIAA3kAAzsE" },
                new Word { Id = 57, PackId = 2, Value = "Чиловый чел", ImageFileId = "AgACAgIAAxkBAAIFPWnzN3qjj5OzlbRpL0ub5vNmBOtOAAKdE2sbsmSZS0pr8sI10N--AQADAgADeQADOwQ" },
                new Word { Id = 58, PackId = 2, Value = "Humstercombat", ImageFileId = "AgACAgIAAxkBAAIFQWnzN8C9njdC5sVsgcNgO3Y-hOfxAAKfE2sbsmSZS8Ty75ZiCUljAQADAgADeQADOwQ" },
                new Word { Id = 59, PackId = 2, Value = "Здесь черным по белому написано", ImageFileId = "AgACAgIAAxkBAAIFRWnzN-SrFX3MvZ6MCZqvuslIg-uZAAKgE2sbsmSZSzfaR4C98jjnAQADAgADeQADOwQ" },

                new Word { Id = 60, PackId = 2, Value = "PvZ Disco Zombie", ImageFileId = "AgACAgIAAxkBAAIFSWnzOAvnppYC3lpLvG8c8UWibHdMAAKhE2sbsmSZS3miFhKNlblCAQADAgADeAADOwQ" },
                new Word { Id = 61, PackId = 2, Value = "Пфф, абоюдно", ImageFileId = "AgACAgIAAxkBAAIFTWnzOFZVCRdhqCLYvXhRDogg1-XqAAKkE2sbsmSZS-OShZMU5c9dAQADAgADeQADOwQ" },
                new Word { Id = 62, PackId = 2, Value = "Шоты лысый, плаки плаки", ImageFileId = "AgACAgIAAxkBAAIFUWnzOJd5Lp0jOV31mEo8W43r0H8GAAKmE2sbsmSZS2l_YIcZ8EXjAQADAgADeQADOwQ" },
                new Word { Id = 63, PackId = 2, Value = "Йогурт апетишка, я сбежала от P`Didy", ImageFileId = "AgACAgIAAxkBAAIFVWnzOLelwQMRrKv-CxWM1SGuKoOUAAKoE2sbsmSZS9eWUlpztwyvAQADAgADeQADOwQ" },
                new Word { Id = 64, PackId = 2, Value = "До слобады доеду", ImageFileId = "AgACAgIAAxkBAAIFWWnzOOk3KIZxpCR5IFV5i2lZoAJGAAKpE2sbsmSZSzhX_vKOCJ7QAQADAgADeQADOwQ" },
                new Word { Id = 65, PackId = 2, Value = "Грустная песня мявмявмявмявмяв", ImageFileId = "AgACAgIAAxkBAAIFXWnzORMt6csmSXQ-dE0VeqieObBIAAKrE2sbsmSZSwi_rXnASk01AQADAgADbQADOwQ" },
                new Word { Id = 66, PackId = 2, Value = "Нагетсы Ковбой", ImageFileId = "AgACAgIAAxkBAAIFYWnzOTCzFYnGR6XyKjTmeJChqRgtAAKsE2sbsmSZS1y6Oh5GYi-dAQADAgADeQADOwQ" },
                new Word { Id = 67, PackId = 2, Value = "Sad humster", ImageFileId = "AgACAgIAAxkBAAIFZWnzOX0Xbl1jeDCGtN9umcNmgMFHAAKtE2sbsmSZS_KcSacmWVtWAQADAgADeQADOwQ" },
                new Word { Id = 68, PackId = 2, Value = "Sigmaboy песня", ImageFileId = "AgACAgIAAxkBAAIFaWnzOcgFyOcnNXEskO45kAKv9feYAAKvE2sbsmSZS5Vv8B1UbyKIAQADAgADeAADOwQ" },
                new Word { Id = 69, PackId = 2, Value = "Sigma", ImageFileId = "AgACAgIAAxkBAAIFbWnzOfnGfMzbeG4W4yz9LgQ3C8xuAAKxE2sbsmSZS8fuG3QhIbxjAQADAgADeQADOwQ" },

                new Word { Id = 70, PackId = 2, Value = "Дикий огурец", ImageFileId = "AgACAgIAAxkBAAIFcWnzOlMr-76nAAE8z7jUecWtSo4kBQACtBNrG7JkmUs0NvVJKOTRhAEAAwIAA3gAAzsE" },
                new Word { Id = 71, PackId = 2, Value = "Телочку на веранде оу ес", ImageFileId = "AgACAgIAAxkBAAIFdWnzOnhaE-PV-Y8DefALRvCQln0tAAK1E2sbsmSZS7hu4_Q2Kmu3AQADAgADeQADOwQ" },
                new Word { Id = 72, PackId = 2, Value = "Аааа а я думала сова", ImageFileId = "AgACAgIAAxkBAAIFeWnzOqAoyroK9Qk1BZCczmeScFbkAAK2E2sbsmSZS4_L9-sOEFHOAQADAgADeQADOwQ" },
                new Word { Id = 73, PackId = 2, Value = "Але мужик ты норм? А.. нормано", ImageFileId = "AgACAgIAAxkBAAIFfWnzOtt_PxrBcYpy6fu2ka_IOrB2AAK3E2sbsmSZS-A21CCuG1hOAQADAgADeQADOwQ" },
                new Word { Id = 74, PackId = 2, Value = "Дед бомбом", ImageFileId = "AgACAgIAAxkBAAIF3Gn0Jprqw6S9e2tvwP-_XXtshAsQAAIBEWsbcEKgS3ZgY8c54BtZAQADAgADeAADOwQ" },
                new Word { Id = 75, PackId = 2, Value = "Денчик слазиет", ImageFileId = "AgACAgIAAxkBAAIF4Gn0JrurpwyE02cQ2T4bcy8Yv9JaAAICEWsbcEKgS-ivyKjQrFwbAQADAgADbQADOwQ" },
                new Word { Id = 76, PackId = 2, Value = "Книга братан, идика сюда", ImageFileId = "AgACAgIAAxkBAAIF5Gn0JwHOl9n6p9ElaP0yVeewjBVPAAIDEWsbcEKgS0YYWt-RIXToAQADAgADeAADOwQ" },
                new Word { Id = 77, PackId = 2, Value = "Это мой гриб, я его ем", ImageFileId = "AgACAgIAAxkBAAIF6Gn0JzDtevnVBG4cg-u0OwSSXwABrgACBBFrG3BCoEspPbSlryUBXgEAAwIAA3gAAzsE" },
                new Word { Id = 78, PackId = 2, Value = "Веном", ImageFileId = "AgACAgIAAxkBAAIF7Gn0J4_gTS1vUxKE_xW5v2IIo5xIAAIGEWsbcEKgS6Tg0-prFGWQAQADAgADbQADOwQ" },
                new Word { Id = 79, PackId = 2, Value = "Я не мэстный", ImageFileId = "AgACAgIAAxkBAAIF8Gn0J6xVnQmIOr3VVYjVHC58BhItAAIHEWsbcEKgS_kDxbauH_EqAQADAgADbQADOwQ" },

                new Word { Id = 80, PackId = 2, Value = "Окак", ImageFileId = "AgACAgIAAxkBAAIF9Gn0J8_5EVEHegtjZnJNNgS_KsOFAAIIEWsbcEKgS-WsIlTX7_elAQADAgADeAADOwQ" },
                new Word { Id = 81, PackId = 2, Value = "Толик, это подъезд", ImageFileId = "AgACAgIAAxkBAAIF-Gn0J-lNfitZ1UeQewABkntCq0_ligACCRFrG3BCoEsN9PfurvQygAEAAwIAA20AAzsE" },
                new Word { Id = 82, PackId = 2, Value = "Это фиаско братан", ImageFileId = "AgACAgIAAxkBAAIF_Gn0KASkaNmw4CTxAAGsUUZ1MRc86AACChFrG3BCoEvK9qrRqbtOVQEAAwIAA20AAzsE" },
                new Word { Id = 83, PackId = 2, Value = "Шампунь Жумайсынба", ImageFileId = "AgACAgIAAxkBAAIGAAFp9ChRu1nDpdi_YdbPQQJ3t8w7hgACDBFrG3BCoEvJCjVgvrrEMgEAAwIAA20AAzsE" },
                new Word { Id = 84, PackId = 2, Value = "Наталья морская пехота", ImageFileId = "AgACAgIAAxkBAAIGBGn0KHAcS4Lm0zq8MVDzdpEX_-HrAAINEWsbcEKgS0Z3da2uNKXdAQADAgADeQADOwQ" },
                new Word { Id = 85, PackId = 2, Value = "Бэн (игра)", ImageFileId = "AgACAgIAAxkBAAIGCGn0KKMp6MggeOhWCmqORTgKrvHsAAIOEWsbcEKgS5PomOBxbp8sAQADAgADeAADOwQ" },
                new Word { Id = 86, PackId = 2, Value = "Чимин (Брайан Мапс)", ImageFileId = "AgACAgIAAxkBAAIGDGn0KL1KXB5QwKdeySMcVE2HVyAUAAIPEWsbcEKgS-ZvzRFttht-AQADAgADbQADOwQ" },
                new Word { Id = 87, PackId = 2, Value = "Кчау Молния МакВин", ImageFileId = "AgACAgIAAxkBAAIGEGn0KNsaW0ogV6Z3-748IcB4b-TpAAIQEWsbcEKgSykIB8tQ8hNtAQADAgADeQADOwQ" },
                new Word { Id = 88, PackId = 2, Value = "ИванЗоло2004", ImageFileId = "AgACAgIAAxkBAAIGFGn0KWJfajoLa_Umm6u7Y7aCDUPqAAITEWsbcEKgS6VW0TzgxUZkAQADAgADeAADOwQ" },
                new Word { Id = 89, PackId = 2, Value = "Доброе утро мопсы", ImageFileId = "AgACAgIAAxkBAAIGGGn0KXrUXy4ldBEH_WTzhgM14_WQAAIUEWsbcEKgS8F_sPovg96oAQADAgADbQADOwQ" },

                new Word { Id = 90, PackId = 2, Value = "Широкий Путин", ImageFileId = "AgACAgIAAxkBAAIGHGn0KZaVwBzOVGh1DthUL__WovnRAAIVEWsbcEKgS9juZLK2da0wAQADAgADbQADOwQ" },
                new Word { Id = 91, PackId = 2, Value = "О вы из англии", ImageFileId = "AgACAgIAAxkBAAIGIGn0KbeEX0HLdeWorfgwEj0hQIllAAIWEWsbcEKgS9dwdoS7ry68AQADAgADbQADOwQ" },
                new Word { Id = 92, PackId = 2, Value = "Зачем/Почему/Man", ImageFileId = "AgACAgIAAxkBAAIGJGn0Kebdc6AaIj9eJsoWvhnzPgnGAAIYEWsbcEKgS0JuyWxvcJBPAQADAgADbQADOwQ" },
                new Word { Id = 93, PackId = 2, Value = "Гроб (африканцы несту)", ImageFileId = "AgACAgIAAxkBAAIGKGn0KhLgmmyjELFfRa_x5g8nV8WGAAIZEWsbcEKgSxJpCZPQ_8iUAQADAgADbQADOwQ" },
                new Word { Id = 94, PackId = 2, Value = "Да ну нахуй бля - забор закрыт" },
                new Word { Id = 95, PackId = 2, Value = "Да яж пошутил", ImageFileId = "AgACAgIAAxkBAAIGLGn0KlEEvalDWIVA1pO-BinuBBTCAAIaEWsbcEKgS88vztcc0U_dAQADAgADbQADOwQ" },
                new Word { Id = 96, PackId = 2, Value = "Можно, а зачем?", ImageFileId = "AgACAgIAAxkBAAIGMGn0Km_gKdTyRkb0TMa7sBzpagmuAAIbEWsbcEKgS1XIRc12cjidAQADAgADbQADOwQ" },
                new Word { Id = 97, PackId = 2, Value = "Чел хорош", ImageFileId = "AgACAgIAAxkBAAIGNGn0Ko3kYvDTQ5q74ub1TFsa97blAAIcEWsbcEKgS-WjGiFsh2lcAQADAgADbQADOwQ" },
                new Word { Id = 98, PackId = 2, Value = "Кринж", ImageFileId = "AgACAgIAAxkBAAIGOGn0KqouDQbNU8dfORsOpzFomqtdAAIeEWsbcEKgSyJP3htfMrgFAQADAgADeAADOwQ" },
                new Word { Id = 99, PackId = 2, Value = "Мем Ок Ок" },

                new Word { Id = 100, PackId = 2, Value = "Извинись", ImageFileId = "AgACAgIAAxkBAAIGPGn0Kt-LXZ34bTUiTGdMNnUZk2h_AAIfEWsbcEKgS11WlpuH-T5iAQADAgADeQADOwQ" },
                new Word { Id = 101, PackId = 2, Value = "Ты большая, молодец!" },
                new Word { Id = 102, PackId = 2, Value = "Что самое главное в женщине? Душа", ImageFileId = "AgACAgIAAxkBAAIGQGn0KySAtIOmAieR29d9fKfeBWEVAAIjEWsbcEKgS9L0gbJKunlyAQADAgADeAADOwQ" },
                new Word { Id = 103, PackId = 2, Value = "Чувак это рэпчик", ImageFileId = "AgACAgIAAxkBAAIGRGn0K1YgWYBKUlN6SS8oadm_2e97AAIkEWsbcEKgS4YPE0_NrmJwAQADAgADbQADOwQ" },
                new Word { Id = 104, PackId = 2, Value = "Как сказать-то", ImageFileId = "AgACAgIAAxkBAAIGSGn0K2-7iTlelFgen3DhgOjramFfAAImEWsbcEKgS3bVT8jp0xuJAQADAgADbQADOwQ" },
                new Word { Id = 105, PackId = 2, Value = "Это печально", ImageFileId = "AgACAgIAAxkBAAIGTGn0K5KysTrrugsEJsnYolqWesciAAIpEWsbcEKgS5JGHPgFvz4KAQADAgADeAADOwQ" },
                new Word { Id = 106, PackId = 2, Value = "Веселый/Веселый(перечеркнуто)", ImageFileId = "AgACAgIAAxkBAAIGUGn0K6qPr4Qe5oGYTZVufzWLtzj2AAIqEWsbcEKgS9WV2Fxi2vO1AQADAgADbQADOwQ" },
                new Word { Id = 107, PackId = 2, Value = "О он c%*&$@#я мем про носорога", ImageFileId = "AgACAgIAAxkBAAIGVGn0K8yMwnRDL25CscQ8SL6VTx1EAAIrEWsbcEKgS97mpGszDYn6AQADAgADbQADOwQ" },
                new Word { Id = 108, PackId = 2, Value = "Упал вставай, вставай упай, чокопай", ImageFileId = "AgACAgIAAxkBAAIGWGn0LCR8VXj66EaPcoCMtDXwsg5aAAIsEWsbcEKgS7q3ke18LQAB4wEAAwIAA20AAzsE" },
                new Word { Id = 109, PackId = 2, Value = "Мэлстрой", ImageFileId = "AgACAgIAAxkBAAIGXGn0LEOuTeE-OsZoRiilNFCwZ1kEAAItEWsbcEKgSyD1KZ8CFiy7AQADAgADeAADOwQ" },

                new Word { Id = 110, PackId = 2, Value = "Возьми телефон детка", ImageFileId = "AgACAgIAAxkBAAIGYGn0LGUTwH0focSWFoIikZQepohEAAIvEWsbcEKgS1Sk6VOaDMfQAQADAgADeAADOwQ" },
                new Word { Id = 111, PackId = 2, Value = "Чипсеки", ImageFileId = "AgACAgIAAxkBAAIGZGn0LH1b6K8dSwITlUoV3BegFNvUAAIwEWsbcEKgS0dDr09JalrNAQADAgADbQADOwQ" },
                new Word { Id = 112, PackId = 2, Value = "Тише, узбеки спят", ImageFileId = "AgACAgIAAxkBAAIGaGn0LKkqXPStVGACUUKOXY5ljtYIAAIyEWsbcEKgSw5HGorvo_upAQADAgADbQADOwQ" },
                new Word { Id = 113, PackId = 2, Value = "Мактрахер", ImageFileId = "AgACAgIAAxkBAAIGbGn0LNAQPqzhP6qh8wIQCHHxontSAAI0EWsbcEKgS3qnbr-yrkWKAQADAgADeAADOwQ" },
                new Word { Id = 114, PackId = 2, Value = "Пенсия хайпует", ImageFileId = "AgACAgIAAxkBAAIGcGn0LOyqqsOuJa4peoWfCbiLu9nvAAI2EWsbcEKgS1KrZohLyA88AQADAgADbQADOwQ" },
                new Word { Id = 115, PackId = 2, Value = "Спидран по майнкрафту погнали", ImageFileId = "AgACAgIAAxkBAAIGdGn0LQe920LZGclBnG-uffVoVcHTAAI3EWsbcEKgS-JG9SlN7C_9AQADAgADbQADOwQ" },
                new Word { Id = 116, PackId = 2, Value = "Бургер Кинг говно", ImageFileId = "AgACAgIAAxkBAAIGeGn0LSQxMdAVnzlCnIUg9rxPspU8AAI5EWsbcEKgS_aZn9VfgAYkAQADAgADbQADOwQ" },

                // Gravity Falls
                new Word { Id = 117, PackId = 3, Value = "Дипер", ImageFileId = "AgACAgIAAxkBAAIGiGn0LiDaFrnUzFIr-nApQc5y-OzfAAI7EWsbcEKgS8fZ8yycTBZvAQADAgADeQADOwQ" },
                new Word { Id = 118, PackId = 3, Value = "Мейбл", ImageFileId = "AgACAgIAAxkBAAIGjGn0LlOizAIYAYXAm47YRklDMIKzAAI8EWsbcEKgS2Fz4BtrFrLWAQADAgADbQADOwQ" },
                new Word { Id = 119, PackId = 3, Value = "Дядя Стэн", ImageFileId = "AgACAgIAAxkBAAIGkGn0Lm4jTzHmWV0SyPBmM2ucZTN5AAI-EWsbcEKgSz2EzcngH5BbAQADAgADeQADOwQ" },

                new Word { Id = 120, PackId = 3, Value = "Венди", ImageFileId = "AgACAgIAAxkBAAIGlGn0LowoF8ARSW1jZTRC8FlgnS6EAAI_EWsbcEKgS2azdp7CLP1_AQADAgADeAADOwQ" },
                new Word { Id = 121, PackId = 3, Value = "Робби", ImageFileId = "AgACAgIAAxkBAAIGmGn0LruzY97VYPGvYG_bDZHhen2fAAJAEWsbcEKgS1EheKOGi9WLAQADAgADeQADOwQ" },
                new Word { Id = 122, PackId = 3, Value = "Бил Шифр", ImageFileId = "AgACAgIAAxkBAAIGnGn0Ls8g6FfuZXtM7R8yF0GJjp2PAAJBEWsbcEKgS_fnHTTqjxMVAQADAgADbQADOwQ" },
                new Word { Id = 123, PackId = 3, Value = "Блендин", ImageFileId = "AgACAgIAAxkBAAIGoGn0LuZd5TxykGFR1yVFxHx4Z35MAAJCEWsbcEKgS1srQghAPsoXAQADAgADeQADOwQ" },
                new Word { Id = 124, PackId = 3, Value = "Стэнфорд", ImageFileId = "AgACAgIAAxkBAAIGpGn0LwAB269f1dyVawSYxW7P2w9vmwACQxFrG3BCoEuWpV4pTWhrOgEAAwIAA20AAzsE" },
                new Word { Id = 125, PackId = 3, Value = "Гидеон", ImageFileId = "AgACAgIAAxkBAAIGqGn0LyoZw-k8cME9q7_mHtjbpjSeAAJFEWsbcEKgSzrbk3SpzEN-AQADAgADeQADOwQ" },
                new Word { Id = 126, PackId = 3, Value = "Зус", ImageFileId = "AgACAgIAAxkBAAIGrGn0L0KAC9NZp9tIhMwdcQM1jCXhAAJGEWsbcEKgS7lPzazhFskbAQADAgADbQADOwQ" },
                new Word { Id = 127, PackId = 3, Value = "Гренда", ImageFileId = "AgACAgIAAxkBAAIGsGn0L1i8k7osIeI0R0P2QKnm7D3FAAJHEWsbcEKgSwuTXBprOEDAAQADAgADeQADOwQ" },
                new Word { Id = 128, PackId = 3, Value = "Бабулита", ImageFileId = "AgACAgIAAxkBAAIGtGn0L2_5nt6icjFtsvPZQc00tlsuAAJJEWsbcEKgS4S-6f4TZ431AQADAgADbQADOwQ" },
                new Word { Id = 129, PackId = 3, Value = "Пасификка", ImageFileId = "AgACAgIAAxkBAAIGuGn0L4RsnqpiER4EdxTcQ7CY6mk4AAJKEWsbcEKgS4CSLY8kAAFVgAEAAwIAA20AAzsE" },

                new Word { Id = 130, PackId = 3, Value = "Толстый шериф Блабс", ImageFileId = "AgACAgIAAxkBAAIGvGn0L51eOSZqHx1dOsaaQ6ho1BnKAAJLEWsbcEKgSxjxr1ReRjwdAQADAgADbQADOwQ" },
                new Word { Id = 131, PackId = 3, Value = "Кенди", ImageFileId = "AgACAgIAAxkBAAIGwGn0L8ha3alJAW2mX6c43CvFhv9IAAJMEWsbcEKgS9v5ntltx-PIAQADAgADbQADOwQ" },
                new Word { Id = 132, PackId = 3, Value = "Худой шериф Дурланд", ImageFileId = "AgACAgIAAxkBAAIGxGn0L-PDIiQcMIJkrlCp3CRtaYx4AAJNEWsbcEKgS0JefBYVXXQeAQADAgADeQADOwQ" },
                new Word { Id = 133, PackId = 3, Value = "Старик Макгакет", ImageFileId = "AgACAgIAAxkBAAIGyGn0MAXXQTqJnnYSCDPYWW8LCf3eAAJOEWsbcEKgS-IQllR_TYLqAQADAgADbQADOwQ" },
                new Word { Id = 134, PackId = 3, Value = "Пухля", ImageFileId = "AgACAgIAAxkBAAIGzGn0MCZlVLT430GYQ4vmRWQ3kBzCAAJPEWsbcEKgS206zpqdSORRAQADAgADbQADOwQ" },
                new Word { Id = 135, PackId = 3, Value = "Козел", ImageFileId = "AgACAgIAAxkBAAIG0Gn0MEFWgNPzubmNYe0SjmNSW8WjAAJQEWsbcEKgSzNIlhe59vC3AQADAgADeAADOwQ" },
                new Word { Id = 136, PackId = 3, Value = "Тоби решительный", ImageFileId = "AgACAgIAAxkBAAIG1Gn0MFje465KyMvBQs_brwhROFdRAAJREWsbcEKgSxdKlhOM8DGmAQADAgADeQADOwQ" },
                new Word { Id = 137, PackId = 3, Value = "Русалдо", ImageFileId = "AgACAgIAAxkBAAIG2Gn0MHYDIC3YQRDA1Vyos2yFZvtpAAJSEWsbcEKgS6vNUJ2RavjVAQADAgADeAADOwQ" },
                new Word { Id = 138, PackId = 3, Value = "Гифани", ImageFileId = "AgACAgIAAxkBAAIG3Gn0MJxp2qdzcIC7gqUYmrR45LdJAAJTEWsbcEKgSyUq9SsPzv4KAQADAgADeQADOwQ" },
                new Word { Id = 139, PackId = 3, Value = "Бей его (Тайлер Кьютбайкер)", ImageFileId = "AgACAgIAAxkBAAIG4Gn0MMT3xV2oeRRu-sQjuYewDsMPAAJVEWsbcEKgSyWbKvFU9llWAQADAgADeQADOwQ" },

                new Word { Id = 140, PackId = 3, Value = "Ленивая Сьюзан", ImageFileId = "AgACAgIAAxkBAAIG5Gn0MO8UiZVVr2FHeGJL1gU3ZVhBAAJWEWsbcEKgSzYg4hjsvJb-AQADAgADeQADOwQ" },
                new Word { Id = 141, PackId = 3, Value = "Тембри", ImageFileId = "AgACAgIAAxkBAAIG6Gn0MQPYuaGSb8KqjLYkOOg94wE2AAJXEWsbcEKgS60W1YkZ6ZGMAQADAgADeAADOwQ" },
                new Word { Id = 142, PackId = 3, Value = "Шандра Хименес", ImageFileId = "AgACAgIAAxkBAAIG7Gn0MSUW48Ou4Bf1OIUeSPHEeCb_AAJYEWsbcEKgS1MWKntx8eWFAQADAgADeQADOwQ" },
                new Word { Id = 143, PackId = 3, Value = "Томпсон", ImageFileId = "AgACAgIAAxkBAAIG8Gn0MT0sxdudLqTZ5OekdWWNqC1dAAJZEWsbcEKgS1X2_5nM-fNYAQADAgADbQADOwQ" },
                new Word { Id = 144, PackId = 3, Value = "Крамбл Макс Кернишь", ImageFileId = "AgACAgIAAxkBAAIG9Gn0MVwfLBEtIEk4E1MKRyDvg6s5AAJaEWsbcEKgS7Rd5j1AUK9OAQADAgADeAADOwQ" },
                new Word { Id = 145, PackId = 3, Value = "Мультимедведь", ImageFileId = "AgACAgIAAxkBAAIG-Gn0MZs4UkV3b4NY70nMV7Qh9jv1AAJbEWsbcEKgSykXsTiS_TuDAQADAgADbQADOwQ" },
                new Word { Id = 146, PackId = 3, Value = "Мужикотавры", ImageFileId = "AgACAgIAAxkBAAIG_Gn0Mb2EeqCX0NVRoqaMcAKoZrmzAAJcEWsbcEKgS3R-J4DkfOM7AQADAgADeQADOwQ" },
                new Word { Id = 147, PackId = 3, Value = "Малыш времени", ImageFileId = "AgACAgIAAxkBAAIHAAFp9DHaXHyPoWlIHjIzocOIeov8SgACYhFrG3BCoEvDeHyCD5OdEAEAAwIAA3kAAzsE" },
                new Word { Id = 148, PackId = 3, Value = "Шмебьюлок", ImageFileId = "AgACAgIAAxkBAAIHBGn0MfSfGZXX90oYh-5KsILN4Uq2AAJkEWsbcEKgS_kagn8nlfg_AQADAgADbQADOwQ" },
                new Word { Id = 149, PackId = 3, Value = "Бтс", ImageFileId = "AgACAgIAAxkBAAIHCGn0MhMchBvNiHHBCcsQi_GG2Jn-AAJnEWsbcEKgS62A4FyYWGvpAQADAgADbQADOwQ" },

                new Word { Id = 150, PackId = 3, Value = "Восковые статуи", ImageFileId = "AgACAgIAAxkBAAIHEGn0Mjmn1FglmHi-4pJ0S9WsStcbAAJpEWsbcEKgS_1ZQWu9g6TnAQADAgADbQADOwQ" },
                new Word { Id = 151, PackId = 3, Value = "Единороги", ImageFileId = "AgACAgIAAxkBAAIHFGn0MmIGXvEryhwyuUlXkzspWmGvAAJqEWsbcEKgS-weW4gp3vblAQADAgADbQADOwQ" },
                new Word { Id = 152, PackId = 3, Value = "Агенты Пауэрс", ImageFileId = "AgACAgIAAxkBAAIHGGn0MofzIj_ZZXbn3y6OFF1AN7ebAAJrEWsbcEKgS03dEG--4i1nAQADAgADbQADOwQ" },
                new Word { Id = 153, PackId = 3, Value = "Слепой Глазго (из культа)", ImageFileId = "AgACAgIAAxkBAAIHHGn0MqgiiL59caereFRtQhaQckSlAAJsEWsbcEKgS7NyKuriWwNtAQADAgADbQADOwQ" },
                new Word { Id = 154, PackId = 3, Value = "Святой Валентин", ImageFileId = "AgACAgIAAxkBAAIHIGn0Mtrfj_i9Cr-2MqfcuW67LKh2AAJuEWsbcEKgS4ubbSw9gfl0AQADAgADeAADOwQ" },
                new Word { Id = 155, PackId = 3, Value = "Батя Гидеона Бад", ImageFileId = "AgACAgIAAxkBAAIHJGn0M3-VCtDSk_bhJoAll8NIgZR6AAJyEWsbcEKgS_X0wNUFpsDFAQADAgADbQADOwQ" },
                new Word { Id = 156, PackId = 3, Value = "Летувинский ловкач", ImageFileId = "AgACAgIAAxkBAAIHLGn0M7neY5ArKhp9hH-r1yNGYihMAAJ0EWsbcEKgS88d2d5r3-SkAQADAgADeAADOwQ" },
                new Word { Id = 157, PackId = 3, Value = "Ручная ведьма", ImageFileId = "AgACAgIAAxkBAAIHMGn0M8_WooxHjpuUAjqQqzA6bDiuAAJ1EWsbcEKgS8eKHI13cX50AQADAgADbQADOwQ" },
                new Word { Id = 158, PackId = 3, Value = "Циклоп пластилиновый", ImageFileId = "AgACAgIAAxkBAAIHOGn0M_j_pPHa2egX86WiOSACfQFTAAJ3EWsbcEKgS6rMF-zk60KtAQADAgADeQADOwQ" },
                new Word { Id = 159, PackId = 3, Value = "Нейт (друг Венди)", ImageFileId = "AgACAgIAAxkBAAIHPGn0NGfq3ClgMmQUuPJrXuzbHNOZAAJ5EWsbcEKgSz19MVCD-qOlAQADAgADeAADOwQ" },

                new Word { Id = 160, PackId = 3, Value = "Ли (друг Венди)", ImageFileId = "AgACAgIAAxkBAAIHQGn0NI43ZZZ53OYmadkTeY7ELAzxAAJ6EWsbcEKgS-KcjCS0IfsqAQADAgADeAADOwQ" },
                new Word { Id = 161, PackId = 3, Value = "Гигантская рука (Голова с рукой)", ImageFileId = "AgACAgIAAxkBAAIHRGn0NLynAX4U7SdRtn9ipREY2mFmAAJ7EWsbcEKgS0uYKtDOosjfAQADAgADbQADOwQ" },
                new Word { Id = 162, PackId = 3, Value = "Арчибальд (дух лесоруб)", ImageFileId = "AgACAgIAAxkBAAIHSGn0NN_1N3e5-kt32PBYs7kgeESxAAJ9EWsbcEKgS9sqkS0okw0TAQADAgADeQADOwQ" },
                new Word { Id = 163, PackId = 3, Value = "Тетя паук (бывшая Стэна)", ImageFileId = "AgACAgIAAxkBAAIHTGn0NQ1B9y1gm7CTzTUc0zLDaVaJAAJ_EWsbcEKgS_7JHOKxZrhGAQADAgADeQADOwQ" },
                new Word { Id = 164, PackId = 3, Value = "Замятыш", ImageFileId = "AgACAgIAAxkBAAIHUGn0NTcOYtLh2XMc5Tordm0VbGaNAAKAEWsbcEKgS4y1Y81m_vpWAQADAgADeAADOwQ" },
                new Word { Id = 165, PackId = 3, Value = "Основатель Гравити Фолз (Квентин Трэмбли)", ImageFileId = "AgACAgIAAxkBAAIHVGn0NWUT28sIEOdZ5viroveB4WJ9AAKCEWsbcEKgS8pZjz4njtRxAQADAgADeQADOwQ" },
                new Word { Id = 166, PackId = 3, Value = "Утка-тив", ImageFileId = "AgACAgIAAxkBAAIHWGn0NYyv5CfJgZLtDepYzSOwPZbjAAKDEWsbcEKgS-zTRM-LXJbcAQADAgADbQADOwQ" },
                new Word { Id = 167, PackId = 3, Value = "Лилигольферы", ImageFileId = "AgACAgIAAxkBAAIHXGn0NcFq9Gukra1mfknVblRRGhkIAAKEEWsbcEKgS0626qiTXUC_AQADAgADbQADOwQ" },
                new Word { Id = 168, PackId = 3, Value = "Охраник бассейна", ImageFileId = "AgACAgIAAxkBAAIHZGn0NjKrNIWtTF_0Rx7GTMdpfszDAAKGEWsbcEKgS0RGJVyGk4MFAQADAgADbQADOwQ" },
                new Word { Id = 169, PackId = 3, Value = "Заключенный бассейна", ImageFileId = "AgACAgIAAxkBAAIHaGn0Nmu6k9eC7eeNgXcTD9IKNt09AAKJEWsbcEKgS4tSDcrpiO1WAQADAgADeAADOwQ" },

                new Word { Id = 170, PackId = 3, Value = "Тед Стрендж (брат Била)", ImageFileId = "AgACAgIAAxkBAAIHbGn0NodrXzQ5e8eLF-seiiAqi2F7AAKKEWsbcEKgSwvWxVzLCjo5AQADAgADeQADOwQ" },
                new Word { Id = 171, PackId = 3, Value = "Рэджм (Брат Зуса)", ImageFileId = "AgACAgIAAxkBAAIHcGn0NqSmGAs6aDyBqyP7T0bK8QikAAKLEWsbcEKgS60vY16GJgpHAQADAgADeQADOwQAgACAgIAAxkBAAIHcGn0NqSmGAs6aDyBqyP7T0bK8QikAAKLEWsbcEKgS60vY16GJgpHAQADAgADeQADOwQ" },
                new Word { Id = 172, PackId = 3, Value = "Монстр который умеет перевоплощаться", ImageFileId = "AgACAgIAAxkBAAIHdGn0NtI33pU439zLnBHKGQVyPwjXAAKMEWsbcEKgS53xPEl8VkJ4AQADAgADbQADOwQ" },
                new Word { Id = 173, PackId = 3, Value = "Монстр из заставки, на 1ом кадре", ImageFileId = "AgACAgIAAxkBAAIHeGn0NxRJ0-uXLkV1-GX1DB0EFNSwAAKOEWsbcEKgSxmk82OdFCN3AQADAgADbQADOwQ" },
                new Word { Id = 174, PackId = 3, Value = "Мирный жител, чувак с пиццей на футболке", ImageFileId = "AgACAgIAAxkBAAIHfGn0Nzgn2zBuU0R18O1emiD16BQTAAKPEWsbcEKgS8ddiA3y-CVHAQADAgADeQADOwQ" },
                new Word { Id = 175, PackId = 3, Value = "Дипер кртуой" },
                new Word { Id = 176, PackId = 3, Value = "Судья кот из мира Мейбл", ImageFileId = "AgACAgIAAxkBAAIHgGn0N2kH9TP-EiPqeDolzGkLmuO3AAKQEWsbcEKgS6WM1Lwoz-4JAQADAgADbQADOwQ" },
                new Word { Id = 177, PackId = 3, Value = "Норман", ImageFileId = "AgACAgIAAxkBAAIHhGn0N8Ouvj9c83V28TVlAAGNBTWCvQACkRFrG3BCoEua0LSnMgKHuQEAAwIAA3gAAzsE" },
            
                // Paired words
                new Word { 
                    Id = 178,
                    PackId = 4,
                    PairId = 1,
                    Value = "Кошка"
                },

                new Word {
                    Id = 179,
                    PackId = 4,
                    PairId = 1,
                    Value = "Собака"
                },

                new Word {
                    Id = 180,
                    PackId = 4,
                    PairId = 2,
                    Value = "Чай"
                },

                new Word {
                    Id = 181,
                    PackId = 4,
                    PairId = 2,
                    Value = "Кофе"
                },

                new Word {
                    Id = 182,
                    PackId = 4,
                    PairId = 3,
                    Value = "Море"
                },

                new Word {
                    Id = 183,
                    PackId = 4,
                    PairId = 3,
                    Value = "Океан"
                },

                new Word {
                    Id = 184,
                    PackId = 4,
                    PairId = 4,
                    Value = "Самолет"
                },

                new Word {
                    Id = 185,
                    PackId = 4,
                    PairId = 4,
                    Value = "Вертолет"
                },

                new Word {
                    Id = 186,
                    PackId = 4,
                    PairId = 5,
                    Value = "Зима"
                },

                new Word {
                    Id = 187,
                    PackId = 4,
                    PairId = 5,
                    Value = "Лето"
                },

                new Word {
                    Id = 188,
                    PackId = 4,
                    PairId = 6,
                    Value = "Книга"
                },

                new Word {
                    Id = 189,
                    PackId = 4,
                    PairId = 6,
                    Value = "Журнал"
                },

                new Word {
                    Id = 190,
                    PackId = 4,
                    PairId = 7,
                    Value = "Кино"
                },

                new Word {
                    Id = 191,
                    PackId = 4,
                    PairId = 7,
                    Value = "Сериал"
                },

                new Word {
                    Id = 192,
                    PackId = 4,
                    PairId = 8,
                    Value = "Врач"
                },

                new Word {
                    Id = 193,
                    PackId = 4,
                    PairId = 8,
                    Value = "Медсестра"
                },

                new Word {
                    Id = 194,
                    PackId = 4,
                    PairId = 9,
                    Value = "Пицца"
                },

                new Word {
                    Id = 195,
                    PackId = 4,
                    PairId = 9,
                    Value = "Бургер"
                },

                new Word {
                    Id = 196,
                    PackId = 4,
                    PairId = 10,
                    Value = "Лев"
                },

                new Word {
                    Id = 197,
                    PackId = 4,
                    PairId = 10,
                    Value = "Тигр"
                }
            );
        }

    }
}
