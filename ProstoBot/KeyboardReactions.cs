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
    public static class KeyboardReactions
    {

        public static InlineKeyboardMarkup InlineKeyboard_React = 
                        new InlineKeyboardMarkup(new[]
                        {
                          new [] 
                          {
                            InlineKeyboardButton.WithCallbackData("👍"),
                            InlineKeyboardButton.WithCallbackData("👎🏿"),
                           }

                        });
    }



}
