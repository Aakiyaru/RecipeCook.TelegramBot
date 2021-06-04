///Скачиваем NuGet пакеты Newtonsoft.JSON и Telegram.Bot
using System;
using Console_TelegramBot.Classes;
using Telegram.Bot;

namespace Console_TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выводим в консоль информацию о боте
            Console.WriteLine("Cook Recipe Telegram Bot v1.0\n" +
                "Bot token: 1781096051:AAHiP8-skOHpnhaur5ibn4dYAVkgCQjyAb4\n\n" +
                "Write /start to begin\n");

            //Запрашиваем команду /start на запуск бота
            while (true)
            {
                Console.Write("Console_Terminal: ");
                string exit = Console.ReadLine();
                if (exit == "/start") { break; }
            }

            Console.WriteLine("\nStarting bot...\n");

            //Метод работы бота
            Working();

            //Запрашиваем команду /stop на остановку бота
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
                //создаём новый объект Bot класса TelegramBotClient с токеном, который берём из класса BotSettings
                TelegramBotClient Bot = new TelegramBotClient(BotSettings.Token);

                //переменная информации о боте
                var me = Bot.GetMeAsync();

                //вебхук пустой, т.к. не используется в моей программе
                await Bot.SetWebhookAsync("");

                //счётчик каждого конкретного обновления
                int offset = 0;

                while (true)
                {
                    //переменная updates в которую приходят обновления, получаемые от API
                    var updates = await Bot.GetUpdatesAsync(offset);

                    //перебор всех обновлений
                    foreach(var update in updates)
                    {
                        //создание переменной message, которая содержит в себе сообщение пользователя
                        var message = update.Message;

                        //если сообщение не пустое, то
                        if (message != null)
                        {
                            //в консоль выводятся данные о времени сообщения, id чата, username и текст сообщения
                            Console.WriteLine("[" + DateTime.Now.ToString() + "] #" + message.Chat.Id + " - @" + message.Chat.Username + ": " + message.Text);

                            //передаём статичному классу CommandList объект Bot и выполняем метод Comparision, передавая в него сообщение пользователя
                            CommandList.Bot = Bot;
                            CommandList.Comparison(message);

                            //прибавление счётчика обновлений
                            offset = update.Id + 1;
                        }
                    }
                }
            }

            //в случае ошибки выводим её в консоль
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.ErrorCode + ex.Message);
            }
        }
    }
}
