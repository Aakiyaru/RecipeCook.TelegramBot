using Telegram.Bot;
using Console_TelegramBot.Classes.Commands;

namespace Console_TelegramBot.Classes
{
    static class CommandList
    {
        static public TelegramBotClient Bot { get; set; }

        static public async void Comparison(Telegram.Bot.Types.Message message)
        {
            if (message.Text == "/start")
            {
                Command_Start command_Start = new Command_Start();
                command_Start.Execute(message, Bot);
            }

            else if (message.Text == "/easteregg")
            {
                Command_Easteregg command_Easteregg = new Command_Easteregg();
                command_Easteregg.Execute(message, Bot);
            }

            else if (message.Text == "/getinfo")
            {
                Command_Getinfo command_Getinfo = new Command_Getinfo();
                command_Getinfo.Execute(message, Bot);
            }

            else if (message.Text == "/random")
            {
                Command_Random command_Random = new Command_Random();
                command_Random.Execute(message, Bot);
            }

            else
            {
                Command_Search command_Search = new Command_Search();
                command_Search.Execute(message, Bot);
            }
        }
    }
}
