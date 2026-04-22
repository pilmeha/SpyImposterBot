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
                entity.Property(e => e.GameMode).HasColumnName("game_mode");
                entity.Property(e => e.PlayersData).HasColumnName("players_data");
                entity.Property(e => e.CurrentPlayerIndex).HasColumnName("current_player_index");
                entity.Property(e => e.Status).HasConversion<string>().HasColumnName("status");
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
                new WordPack { Id = 1, Name = "Классика", IsPublic = true },
                new WordPack { Id = 2, Name = "Мемы", IsPublic = true }
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
                new Word { Id = 31, PackId = 2, Value = "Ждун" },
                new Word { Id = 32, PackId = 2, Value = "Орешки бигбоб" },
                new Word { Id = 33, PackId = 2, Value = "67" },
                new Word { Id = 34, PackId = 2, Value = "Орлица Зубарева" },
                new Word { Id = 35, PackId = 2, Value = "Кит ты маму мав" },
                new Word { Id = 36, PackId = 2, Value = "Что у вас тут происходит" },
                new Word { Id = 37, PackId = 2, Value = "Тетенька с красным кандибобером" },
                new Word { Id = 38, PackId = 2, Value = "Я мою посуду, я мою посуду" },
                new Word { Id = 39, PackId = 2, Value = "Я уже красный" },

                new Word { Id = 40, PackId = 2, Value = "Думайте" },
                new Word { Id = 41, PackId = 2, Value = "Что вы делаете в моем холодильнике" },
                new Word { Id = 42, PackId = 2, Value = "Шайлушай" },
                new Word { Id = 43, PackId = 2, Value = "Подозрения увеличись на 5%" },
                new Word { Id = 44, PackId = 2, Value = "Пацан он тебе тапок разорвал... я все склею" },
                new Word { Id = 45, PackId = 2, Value = "Пацаны Владивостока. ГАЗ знакомиться" },
                new Word { Id = 46, PackId = 2, Value = "Умный человек в очках" },
                new Word { Id = 47, PackId = 2, Value = "Сам решу" },
                new Word { Id = 48, PackId = 2, Value = "ПИЗ... ахахахххахах" },
                new Word { Id = 49, PackId = 2, Value = "52" },

                new Word { Id = 50, PackId = 2, Value = "Пацан, можешь дверь открыть от подъезда" },
                new Word { Id = 51, PackId = 2, Value = "Ой-ой собака ты куда? Ой песик" },
                new Word { Id = 52, PackId = 2, Value = "Сафонов оплатить" },
                new Word { Id = 53, PackId = 2, Value = "Оп, пьяный, оп потом такой, оп пьяный" },
                new Word { Id = 54, PackId = 2, Value = "Заяц с часами" },
                new Word { Id = 55, PackId = 2, Value = "Повар спрашивает повара" },
                new Word { Id = 56, PackId = 2, Value = "Арбуз арбуз привет" },
                new Word { Id = 57, PackId = 2, Value = "Чиловый чел" },
                new Word { Id = 58, PackId = 2, Value = "Humstercombat" },
                new Word { Id = 59, PackId = 2, Value = "Здесь черным по белому написано" },

                new Word { Id = 60, PackId = 2, Value = "PvZ Disco Zombie" },
                new Word { Id = 61, PackId = 2, Value = "Пфф, абоюдно" },
                new Word { Id = 62, PackId = 2, Value = "Шоты лысый, плаки плаки" },
                new Word { Id = 63, PackId = 2, Value = "Йогурт апетишка, я сбежала от P`Didy" },
                new Word { Id = 64, PackId = 2, Value = "До слобады доеду" },
                new Word { Id = 65, PackId = 2, Value = "Грустная песня мявмявмявмявмяв" },
                new Word { Id = 66, PackId = 2, Value = "Нагетсы Ковбой" },
                new Word { Id = 67, PackId = 2, Value = "Sad humster" },
                new Word { Id = 68, PackId = 2, Value = "Sigmaboy песня" },
                new Word { Id = 69, PackId = 2, Value = "Sigms" },

                new Word { Id = 70, PackId = 2, Value = "Дикий огурец" },
                new Word { Id = 71, PackId = 2, Value = "Телочку на веранде оу ес" },
                new Word { Id = 72, PackId = 2, Value = "Аааа а я думала сова" },
                new Word { Id = 73, PackId = 2, Value = "Але мужик ты норм? А.. нормано" },
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
                new Word { Id = 116, PackId = 2, Value = "Бургер Кинг говно" }
                );
        }

    }
}
