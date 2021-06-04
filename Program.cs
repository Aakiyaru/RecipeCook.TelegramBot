using System;
using Console_TelegramBot.Classes;
using Telegram.Bot;

namespace Console_TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Water Balancer Telegram Bot v0.2\n" +
                "Bot token: 1781096051:AAHiP8-skOHpnhaur5ibn4dYAVkgCQjyAb4\n\n" +
                "Write /start to begin\n");

            while (true)
            {
                Console.Write("Console_Terminal: ");
                string exit = Console.ReadLine();
                if (exit == "/start") { break; }
            }

            Console.WriteLine("\nStarting bot...\n");

            Working();

            while (true)
            {
                Console.WriteLine("Write /stop to stop bot\n");
                string exit = Console.ReadLine();
                if (exit == "/stop") { break; }
            }
        }

        static public async void Working()
        {
            try
            {
                TelegramBotClient Bot = new TelegramBotClient(BotSettings.Token);

                var me = Bot.GetMeAsync();
                await Bot.SetWebhookAsync("");
                int offset = 0;

                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset);

                    foreach(var update in updates)
                    {
                        var message = update.Message;

                        if (message != null)
                        {
                            Console.WriteLine("[" + DateTime.Now.ToString() + "] #" + message.Chat.Id + " - @" + message.Chat.Username + ": " + message.Text);

                            CommandList.Bot = Bot;
                            CommandList.Comparison(message);

                            offset = update.Id + 1;
                        }
                    }
                }
            }

            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.ErrorCode + ex.Message);
            }
        }
    }
}
