 using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot;
//using Telegram.Bot.TelegramBotClient;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using System;


namespace ProstoBot.Commands  
{
    public class CommandsList
    {      // public int affs=3;
        public static readonly TelegramBotClient Bot_ClientAPI = new TelegramBotClient(BotSettings.Key);


       public static async void WriteShit(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await Bot_ClientAPI.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "You said:\n" + e.Message.Text
                );
            }
        }

        async public static void ProcessCallbackQuery(object sender, CallbackQueryEventArgs e)

        {

            Console.WriteLine("Pressed button " + e.CallbackQuery.Data);


            // byte buttonNumber = Byte.Parse(e.CallbackQuery.Data);

            Message message = e.CallbackQuery.Message;


                await Bot_ClientAPI.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "У вас нет прав", true);

        }
    }
}
