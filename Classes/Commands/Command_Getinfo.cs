using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Console_TelegramBot.Classes.Commands
{
    class Command_Getinfo : Command
    {
        public override string Name => "/getinfo";

        public override async void Execute(Message message, TelegramBotClient Bot)
        {
            Thread.Sleep(500);
            var button_1 = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton();
            var button_2 = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton();
            var button_3 = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton();
            var button_4 = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton();

            button_1.Text = "Spoonacular.com";
            button_1.Url = "https://spoonacular.com/food-api";

            button_2.Text = "C# Telegram API";
            button_2.Url = "https://github.com/TelegramBots/Telegram.Bot";

            button_3.Text = "My GitHub";
            button_3.Url = "https://github.com/ZLobbster";

            button_4.Text = "My YouTube";
            button_4.Url = "https://www.youtube.com/c/Denixon";

            var row_1 = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[] { button_1, button_2 };
            var row_2 = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[] { button_3, button_4 };

            var buttons = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[][] { row_1, row_2 };

            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(buttons);

            Console.WriteLine("    #Sending info...\n");
            await Bot.SendTextMessageAsync(message.Chat.Id, "This bot was created by Zlobbster using the Spoonacular API and C# Telegram Bot API",
                Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
        }
    }
}
