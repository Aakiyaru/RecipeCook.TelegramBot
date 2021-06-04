using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Console_TelegramBot.Classes.Commands
{
    class Command_Search : Command
    {
        public override string Name => throw new NotImplementedException();

        public override async void Execute(Message message, TelegramBotClient Bot)
        {
            string zapros = message.Text;

            Console.WriteLine($"    #Request: "+ zapros);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.spoonacular.com/recipes/complexSearch?apiKey=eaaa3a4d5e9046d0800682645d0a4cd2&number=1&query=" + zapros);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string SReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JsonConvert.DeserializeObject(SReadData);
            var id = 0;
            try
            {
                id = d.results[0].id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("    #Error: " + ex.Message);
                await Bot.SendTextMessageAsync(message.Chat.Id, "Nothing found");
                Console.WriteLine("");
            }

            if (id == 0)
            {

            }
            else
            {
                try
                {
                    Console.WriteLine("    #Response: " + d.results[0].title);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("    #Error: " + ex.Message);
                }

                Console.WriteLine("    #Searching for recipe...");

                HttpWebRequest recipe_request = (HttpWebRequest)WebRequest.Create("https://api.spoonacular.com/recipes/" + id + "/information?apiKey=eaaa3a4d5e9046d0800682645d0a4cd2");
                HttpWebResponse recipe_response = (HttpWebResponse)recipe_request.GetResponse();

                Stream recipe_stream = recipe_response.GetResponseStream();
                StreamReader recipe_sr = new StreamReader(recipe_stream);

                string recipe_SReadData = recipe_sr.ReadToEnd();
                recipe_response.Close();

                dynamic recipe_d = JsonConvert.DeserializeObject(recipe_SReadData);

                await Bot.SendPhotoAsync(message.Chat.Id, d.results[0].image.ToString());

                bool vegetarian = recipe_d.vegetarian;
                Console.WriteLine("        #Vegetarian: " + vegetarian);

                bool vegan = recipe_d.vegan;
                Console.WriteLine("        #Vegan: " + vegan);

                bool glutenFree = recipe_d.glutenFree;
                Console.WriteLine("        #GlutenFree: " + glutenFree);

                bool dairyFree = recipe_d.dairyFree;
                Console.WriteLine("        #dairyFree: " + dairyFree);

                int weightWatcherSmartPoints = recipe_d.weightWatcherSmartPoints;
                Console.WriteLine("        #weightWatcherSmartPoints: " + weightWatcherSmartPoints);

                int aggregateLikes = recipe_d.aggregateLikes;
                Console.WriteLine("        #aggregateLikes: " + aggregateLikes);

                int healthScore = recipe_d.healthScore;
                Console.WriteLine("        #healthScore: " + healthScore);

                string recipe_Scores = d.results[0].title + "\n\n";

                recipe_Scores += (char.ConvertFromUtf32(0x1F44D) + " Aggregate Likes: " + aggregateLikes + "\n");
                recipe_Scores += (char.ConvertFromUtf32(0x2764) + " Health Score: " + healthScore + "\n");
                recipe_Scores += (char.ConvertFromUtf32(0x1F354) + " Weight Watcher Smart Points: " + weightWatcherSmartPoints + "\n");
                recipe_Scores += ("\n");

                if (glutenFree == true)
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F35E) + " Is gluten free\n");
                }
                else
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F35E) + " Is NOT gluten free\n");
                }

                if (dairyFree == true)
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F95B) + " Is dairy free\n");
                }
                else
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F95B) + " Is NOT dairy free\n");
                }

                if (vegetarian && vegan == true)
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F34F) + " Suitable for vegetarians and vegans\n");
                }
                else if (vegetarian)
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F34F) + " Suitable for vegetarians but not vegans\n");
                }
                else if (vegan)
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F34F) + " Suitable for vegans but not vegetarians\n");
                }
                else
                {
                    recipe_Scores += (char.ConvertFromUtf32(0x1F34F) + " Not suitable for vegetarians and vegans\n");
                }

                await Bot.SendTextMessageAsync(message.Chat.Id, recipe_Scores);

                Console.WriteLine("        #Getting recipe...");
                string instructions = recipe_d.instructions;
                Regex ol = new Regex(@"<ol>");
                Regex ol2 = new Regex(@"</ol>");
                Regex li = new Regex(@"<li>");
                Regex li2 = new Regex(@"</li>");

                instructions = ol.Replace(instructions, "");
                instructions = ol2.Replace(instructions, "");
                instructions = li.Replace(instructions, "");
                instructions = li2.Replace(instructions, "");


                Console.WriteLine("        #Recipe sended");
                Console.WriteLine("        #Task complete\n");
                await Bot.SendTextMessageAsync(message.Chat.Id, instructions);

                
                

            }
        }
    }
}
