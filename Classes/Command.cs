using Telegram.Bot;
using Telegram.Bot.Types;

namespace Console_TelegramBot.Classes
{
    public abstract class Command
    {
        //абстрактный класс Command от которого будут наследовать свойства все остальные команды
        
        //имя команды
        public abstract string Name { get; }

        //метод выполнения команды
        public abstract void Execute(Message message, TelegramBotClient Bot);

    }
}
