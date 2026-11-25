using Telegram.Bot.Types.ReplyMarkups;

static class Keyboards
{
    public static InlineKeyboardMarkup Show =>
        new(InlineKeyboardButton.WithCallbackData("Показать", "show"));

    public static InlineKeyboardMarkup Next =>
        new(InlineKeyboardButton.WithCallbackData("Следующий", "next"));

    public static InlineKeyboardMarkup PlayAgainMenu =>
          new(new[]
          {
            new [] { InlineKeyboardButton.WithCallbackData("Сыграть ещё раз", "playAgain") },
            new [] { InlineKeyboardButton.WithCallbackData("Вернуться к выбору темы", "goGameType") },
          });

    public static InlineKeyboardMarkup PlayerCount =>
        new(new[] 
        {
            new[] 
            {
                InlineKeyboardButton.WithCallbackData("3", "players_3"),
                InlineKeyboardButton.WithCallbackData("4", "players_4"),
                InlineKeyboardButton.WithCallbackData("5", "players_5"),
                InlineKeyboardButton.WithCallbackData("6", "players_6"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("7", "players_7"),
                InlineKeyboardButton.WithCallbackData("8", "players_8"),
                InlineKeyboardButton.WithCallbackData("9", "players_9"),
                InlineKeyboardButton.WithCallbackData("10", "players_10"),
            },
        });

    public static InlineKeyboardMarkup GameType =>
        new(new[]
        {
                new[] { InlineKeyboardButton.WithCallbackData("Классика", "pack_1") },
                new[] { InlineKeyboardButton.WithCallbackData("Мемы", "pack_2") },
                new[] { InlineKeyboardButton.WithCallbackData("Гравити Фолз", "pack_3") },
                new[] { InlineKeyboardButton.WithCallbackData("Парные слова", "pack_4") },
                new[] { InlineKeyboardButton.WithCallbackData("Кастомные подборки", "customPacks") }
        });

    public static InlineKeyboardMarkup CustomPacksMenu =>
        new(
            new[] {
                new[] { InlineKeyboardButton.WithCallbackData("Мои подборки", "myPacks") },
                new[] { InlineKeyboardButton.WithCallbackData("Создать подборку", "createPack") },
                new[] { InlineKeyboardButton.WithCallbackData("Назад", "goGameType") }
            }
        );

    public static InlineKeyboardMarkup MyPacks(IEnumerable<WordPack> packs)
    {
        var rows = packs
            .Select(pack => new[]
            {
                InlineKeyboardButton.WithCallbackData(pack.Name, $"selectCustomPack_{pack.Id}")
            })
            .ToList();

        rows.Add(new[]
        {
            InlineKeyboardButton.WithCallbackData("Назад", "customPacks")
        });

        return new InlineKeyboardMarkup(rows);
    }

    public static InlineKeyboardMarkup CustomPackActions(long packId)
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData("Начать игру", $"startCustomPack_{packId}") },
            new[] { InlineKeyboardButton.WithCallbackData("Редактировать набор", $"editCustomPack_{packId}") },
            new[] { InlineKeyboardButton.WithCallbackData("К моим подборкам", "myPacks") }
        });
    }

    public static InlineKeyboardMarkup EditCustomPack(long packId)
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData("Добавить слова", $"addWords_{packId}") },
            new[] { InlineKeyboardButton.WithCallbackData("Удалить слова", $"removeWords_{packId}") },
            new[] { InlineKeyboardButton.WithCallbackData("Переименновать", $"renamePack_{packId}") },
            new[] { InlineKeyboardButton.WithCallbackData("Удалить подборку", $"deleteCustomPack_{packId}") },
            new[] { InlineKeyboardButton.WithCallbackData("Назад", $"selectCustomPack_{packId}") }
        });
    }

    public static InlineKeyboardMarkup ConfirmDeletePack(long packId)
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[] { InlineKeyboardButton.WithCallbackData("Да, удалить", $"confirmDeletePack_{packId}") },
            new[] { InlineKeyboardButton.WithCallbackData("Галя, отмена", $"selectCustomPack_{packId}") }
        });
    }

    public static InlineKeyboardMarkup CancelPackInput => new(
        new[] { InlineKeyboardButton.WithCallbackData("Галя, отмена", "cancelPackInput") }
    );

    public static ReplyKeyboardMarkup MainMenu =>
        new(new[]
        {
            new KeyboardButton[] {"Первая кнопка", "Вторая кнопка" },
            new KeyboardButton[] {"Третья кнопка" }
        })
        {
            ResizeKeyboard = true
        };
}

