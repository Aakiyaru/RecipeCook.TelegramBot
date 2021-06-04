using Telegram.Bot;
using Telegram.Bot.Types;

namespace Console_TelegramBot.Classes
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient Bot);

        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }
    }
}
