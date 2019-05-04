 using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using System;


namespace ProstoBot.Commands
{
   public static class CommandController
    {
        public static readonly TelegramBotClient Bot_ClientAPI = new TelegramBotClient(BotSettings.Key);

        public static void vCommandHandler(TelegramBotClient telegram)
        { CommandsList commandsList = new CommandsList();
           
          
            telegram.OnMessage += CommandsList.WriteShit;
            telegram.OnMessage += BotController.Message_Type;
            telegram.OnCallbackQuery += CommandsList.ProcessCallbackQuery;

            //telegram.OnMessage += BotOnMessageReceived;
            //telegram.OnMessageEdited += BotOnMessageReceived;
            //telegram.OnCallbackQuery += BotOnCallbackQueryReceived;
            //telegram.OnInlineQuery += BotOnInlineQueryReceived;
            //telegram.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            //telegram.OnReceiveError += BotOnReceiveError;

        }


    }
}