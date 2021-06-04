using Telegram.Bot;
using Console_TelegramBot.Classes.Commands;

namespace Console_TelegramBot.Classes
{
    static class CommandList
    {
        //создаём объект Bot, который получаем из Program.cs
        static public TelegramBotClient Bot { get; set; }

        //метод, который сравнивает полученное из Program.cs сообщение со списком заданных комманд
        //делаем его асинхронным для параллельной обработки разных запросов
        static public async void Comparison(Telegram.Bot.Types.Message message)
        {
            if (message.Text == "/start")
            {
                //создание объекта класса Command_Start, передача в него бота и сообщения и выполнение метода Execute
                Command_Start command_Start = new Command_Start();
                command_Start.Execute(message, Bot);
            }

            else if (message.Text == "/easteregg")
            {
                //создание объекта класса Command_Easteregg, передача в него бота и сообщения и выполнение метода Execute
                Command_Easteregg command_Easteregg = new Command_Easteregg();
                command_Easteregg.Execute(message, Bot);
            }

            else if (message.Text == "/getinfo")
            {
                //создание объекта класса Command_Getinfo, передача в него бота и сообщения и выполнение метода Execute
                Command_Getinfo command_Getinfo = new Command_Getinfo();
                command_Getinfo.Execute(message, Bot);
            }

            else if (message.Text == "/random")
            {
                //создание объекта класса Command_Random, передача в него бота и сообщения и выполнение метода Execute
                Command_Random command_Random = new Command_Random();
                command_Random.Execute(message, Bot);
            }

            //Если совпадений не найдено, значит производим поиск блюда по названию
            else
            {
                //создание объекта класса Command_Search, передача в него бота и сообщения и выполнение метода Execute
                Command_Search command_Search = new Command_Search();
                command_Search.Execute(message, Bot);
            }
        }
    }
}
