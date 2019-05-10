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
    public  class KeyboardReactions
    {
        public static readonly TelegramBotClient Bot_ClientAPI = new TelegramBotClient(BotSettings.Key);


        private string[] reactions = new string[3] { "👍", "👎🏿", "dislike" };
        public static InlineKeyboardMarkup InlineKeyboard_React = 
                        new InlineKeyboardMarkup(new[]
                        {
                          new [] 
                          {
                            InlineKeyboardButton.WithCallbackData("👍"),
                            InlineKeyboardButton.WithCallbackData("👎🏿"),
                           }


                        });

        async public static void AddInlineKeyboards(Message message)

        {
            PhotoSize[] photoSize = message.Photo;
            var photo = photoSize[0].FileId;
            var chatID = message.Chat.Id;
            ReplyKeyboardMarkup MyButton = new ReplyKeyboardMarkup();
            await Bot_ClientAPI.SendPhotoAsync(chatID, photo, replyMarkup: KeyboardReactions.InlineKeyboard_React);
            await Bot_ClientAPI.DeleteMessageAsync(message.Chat.Id, message.MessageId);

        }

    }



}
