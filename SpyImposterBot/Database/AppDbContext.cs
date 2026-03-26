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
            modelBuilder.Entity<User>()
                .HasIndex(x => x.TelegramId)
                .IsUnique();

            modelBuilder.Entity<Word>()
                .Property(x => x.Value)
                .HasColumnName("word");

            modelBuilder.Entity<GameSession>()
                .Property(x => x.PlayersData)
                .HasColumnType("jsonb");
        }

    }
}
