using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Console_TelegramBot.Classes.Commands
{
    class Command_Easteregg : Command
    {
        public override string Name => "/easteregg";

        public override async void Execute(Message message, TelegramBotClient Bot)
        {
            Thread.Sleep(500);

            await Bot.SendPhotoAsync(message.Chat.Id,
                "https://avatars.mds.yandex.net/get-vthumb/3381838/7456cbc965c8a8a13547011a786876c1/564x318_1",
                "Тикайте, хлопцы, айлбибэк");
        }
    }
}
