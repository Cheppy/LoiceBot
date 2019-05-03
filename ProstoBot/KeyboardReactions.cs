using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using ProstoBot.Commands;
using Telegram.Bot.Types.InputFiles;

namespace ProstoBot
{
    class KeyboardReactions : TelegramBotClient
    {

         KeyboardReactions(string API_key) :base(API_key)

        {
            string[] inLineKeyboardData = { "like", "dislike" };


        }
    }
}
