using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;

namespace Console_TelegramBot.Classes.Commands
{
    class Command_Start : Command
    {
        //наследование от абстрактного класса Command
        public override string Name => "/start";

        public override async void Execute(Message message, TelegramBotClient Bot)
        {
            //отправляем пользователю фото и текст

            await Bot.SendPhotoAsync(message.Chat.Id,
                "https://culinaryschool.ru/wp-content/uploads/2016/07/10.-%D0%A1%D1%83-%D1%88%D0%B5%D1%84-%D0%BF%D0%BE%D0%B2%D0%B0%D1%80.jpg",
                "Hi there! I am Recipe Cook Bot and I will help you with your cooking! I know many different recipes.");

            Thread.Sleep(3000);

            await Bot.SendTextMessageAsync(message.Chat.Id,
                "All you need to do is just write the name of the dish you want to cook, or use commands!");

            Thread.Sleep(1500);

            await Bot.SendTextMessageAsync(message.Chat.Id,
                "Let's start!");
        }
    }
}
