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

            modelBuilder.Entity<GameSession>()
                .Property(x => x.PlayersData)
                .HasColumnType("jsonb");

            modelBuilder.Entity<WordPack>().HasData(
                new WordPack { Id = 1, Name = "Классика", IsPublic = true, HasImage = false },
                new WordPack { Id = 2, Name = "Мемы", IsPublic = true, HasImage = true, SpyImageFileId = "AgACAgIAAxkBAAIDcWnqFF73-ck3yCkIGaC-ILiGbz8vAAIfE2sbeT1ZS65DyBa6QXhIAQADAgADeQADOwQ" },
                new WordPack { Id = 3, Name = "Гравити Фолз", IsPublic = true, HasImage = true, SpyImageFileId = "AgACAgIAAxkBAAIDcWnqFF73-ck3yCkIGaC-ILiGbz8vAAIfE2sbeT1ZS65DyBa6QXhIAQADAgADeQADOwQ" }
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
                new Word { Id = 74, PackId = 2, Value = "Дед бомбом" },
                new Word { Id = 75, PackId = 2, Value = "Денчик слазиет" },
                new Word { Id = 76, PackId = 2, Value = "Книга братан, идика сюда" },
                new Word { Id = 77, PackId = 2, Value = "Это мой гриб, я его ем" },
                new Word { Id = 78, PackId = 2, Value = "Веном" },
                new Word { Id = 79, PackId = 2, Value = "Я не мэстный" },

                new Word { Id = 80, PackId = 2, Value = "Окак" },
                new Word { Id = 81, PackId = 2, Value = "Толик, это подъезд" },
                new Word { Id = 82, PackId = 2, Value = "Это фиаско братан" },
                new Word { Id = 83, PackId = 2, Value = "Шампунь Жумайсонба" },
                new Word { Id = 84, PackId = 2, Value = "Наталья морская пехота" },
                new Word { Id = 85, PackId = 2, Value = "Бэн (игра)" },
                new Word { Id = 86, PackId = 2, Value = "Чимин (Брайан Мапс)" },
                new Word { Id = 87, PackId = 2, Value = "Кчау Молния МакВин" },
                new Word { Id = 88, PackId = 2, Value = "ИванЗоло2004" },
                new Word { Id = 89, PackId = 2, Value = "Доброе утро мопсы" },

                new Word { Id = 90, PackId = 2, Value = "Широкий Путин" },
                new Word { Id = 91, PackId = 2, Value = "О вы из англии" },
                new Word { Id = 92, PackId = 2, Value = "Зачем? (лощадь у моря)" },
                new Word { Id = 93, PackId = 2, Value = "Гроб (африканцы несту)" },
                new Word { Id = 94, PackId = 2, Value = "Да ну нахуй бля - забор закрыт" },
                new Word { Id = 95, PackId = 2, Value = "Да яж пошутил" },
                new Word { Id = 96, PackId = 2, Value = "Можно, а зачем?" },
                new Word { Id = 97, PackId = 2, Value = "Чел хорош" },
                new Word { Id = 98, PackId = 2, Value = "Кринж" },
                new Word { Id = 99, PackId = 2, Value = "Мем Ок Ок" },

                new Word { Id = 100, PackId = 2, Value = "Извинись" },
                new Word { Id = 101, PackId = 2, Value = "Ты большая, молодец!" },
                new Word { Id = 102, PackId = 2, Value = "Что самое главное в женщине? Душа" },
                new Word { Id = 103, PackId = 2, Value = "Чувак это рэпчик" },
                new Word { Id = 104, PackId = 2, Value = "Как сказать-то" },
                new Word { Id = 105, PackId = 2, Value = "Это печально" },
                new Word { Id = 106, PackId = 2, Value = "Веселый/Веселый(перечеркнуто)" },
                new Word { Id = 107, PackId = 2, Value = "О он съебался мем про носорога" },
                new Word { Id = 108, PackId = 2, Value = "Упал вставай, вставай упай, чокопай" },
                new Word { Id = 109, PackId = 2, Value = "Мэлстрой" },

                new Word { Id = 110, PackId = 2, Value = "Возьми телефон детка" },
                new Word { Id = 111, PackId = 2, Value = "Чипсеки" },
                new Word { Id = 112, PackId = 2, Value = "Тише, узбеки спят" },
                new Word { Id = 113, PackId = 2, Value = "Мактрахер" },
                new Word { Id = 114, PackId = 2, Value = "Пенсия хайпует" },
                new Word { Id = 115, PackId = 2, Value = "Спидран по майнкрафту погнали" },
                new Word { Id = 116, PackId = 2, Value = "Бургер Кинг говно" },

                // Gravity Falls
                new Word { Id = 117, PackId = 3, Value = "Дипер" },
                new Word { Id = 118, PackId = 3, Value = "Мейбл" },
                new Word { Id = 119, PackId = 3, Value = "Дядя Стен" },

                new Word { Id = 120, PackId = 3, Value = "Венди" },
                new Word { Id = 121, PackId = 3, Value = "Робин" },
                new Word { Id = 122, PackId = 3, Value = "Бил Шифр" },
                new Word { Id = 123, PackId = 3, Value = "Блендин" },
                new Word { Id = 124, PackId = 3, Value = "Стенфорд" },
                new Word { Id = 125, PackId = 3, Value = "Гидеон" },
                new Word { Id = 126, PackId = 3, Value = "Зус" },
                new Word { Id = 127, PackId = 3, Value = "Гренда" },
                new Word { Id = 128, PackId = 3, Value = "Бабулита" },
                new Word { Id = 129, PackId = 3, Value = "Пасификка" },

                new Word { Id = 130, PackId = 3, Value = "Толстый шериф Плапс" },
                new Word { Id = 131, PackId = 3, Value = "Кенди" },
                new Word { Id = 132, PackId = 3, Value = "Худой шериф Дурланд" },
                new Word { Id = 133, PackId = 3, Value = "Старик Макгакет" },
                new Word { Id = 134, PackId = 3, Value = "Пухля" },
                new Word { Id = 135, PackId = 3, Value = "Козел" },
                new Word { Id = 136, PackId = 3, Value = "Тоби решительный" },
                new Word { Id = 137, PackId = 3, Value = "Русалдо" },
                new Word { Id = 138, PackId = 3, Value = "Гифани" },
                new Word { Id = 139, PackId = 3, Value = "Бей его" },

                new Word { Id = 140, PackId = 3, Value = "Тетя из кафе Сьзан" },
                new Word { Id = 141, PackId = 3, Value = "Тембри" },
                new Word { Id = 142, PackId = 3, Value = "Шандра Хименес" },
                new Word { Id = 143, PackId = 3, Value = "Томпсон" },
                new Word { Id = 144, PackId = 3, Value = "Крамбл Макс Кернишь" },
                new Word { Id = 145, PackId = 3, Value = "Мультимедведь" },
                new Word { Id = 146, PackId = 3, Value = "Мужикотавр" },
                new Word { Id = 147, PackId = 3, Value = "Малыш времени" },
                new Word { Id = 148, PackId = 3, Value = "Шмебьюлок" },
                new Word { Id = 149, PackId = 3, Value = "Бтс" },

                new Word { Id = 150, PackId = 3, Value = "Восковые статуи" },
                new Word { Id = 151, PackId = 3, Value = "Единорожки" },
                new Word { Id = 152, PackId = 3, Value = "Агенты ФБР Пауэрс (черные волосы)" },
                new Word { Id = 153, PackId = 3, Value = "Слепой Глазго (из культа)" },
                new Word { Id = 154, PackId = 3, Value = "Святой Валентин" },
                new Word { Id = 155, PackId = 3, Value = "Батя Гидеона Бад" },
                new Word { Id = 156, PackId = 3, Value = "Летувинский ловкач" },
                new Word { Id = 157, PackId = 3, Value = "Ручная ведьма" },
                new Word { Id = 158, PackId = 3, Value = "Циклоп пластилиновый" },
                new Word { Id = 159, PackId = 3, Value = "Татуированный друг Венди" },

                new Word { Id = 160, PackId = 3, Value = "Блондин (друг Венди)" },
                new Word { Id = 161, PackId = 3, Value = "Гигантская рука (Голова с рукой)" },
                new Word { Id = 162, PackId = 3, Value = "Арчибальд (дух лесоруб)" },
                new Word { Id = 163, PackId = 3, Value = "Тетя паук (бывшая Стена)" },
                new Word { Id = 164, PackId = 3, Value = "Замятыш (клон Дипера)" },
                new Word { Id = 165, PackId = 3, Value = "Основатель Гравити Фолз" },
                new Word { Id = 166, PackId = 3, Value = "Утка Холмс" },
                new Word { Id = 167, PackId = 3, Value = "Лилигоферы" },
                new Word { Id = 168, PackId = 3, Value = "Охраник бассейна" },
                new Word { Id = 169, PackId = 3, Value = "Заключенный бассейна" },

                new Word { Id = 170, PackId = 3, Value = "Тед Стрендж (брат Била)" },
                new Word { Id = 171, PackId = 3, Value = "Брат Зуса" },
                new Word { Id = 172, PackId = 3, Value = "Монстр который умеет перевоплощаться" },
                new Word { Id = 173, PackId = 3, Value = "Монстр из заставки, на 1ом кадре" },
                new Word { Id = 174, PackId = 3, Value = "Мирный жител, чувак с пиццей на футболке" },
                new Word { Id = 175, PackId = 3, Value = "Дипер кртуой" },
                new Word { Id = 176, PackId = 3, Value = "Судья кот из мира Мейбл" }


                );
        }

    }
}
