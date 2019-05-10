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


        private static List<string> reactions = new List<string>();
       
        public static InlineKeyboardMarkup InlineKeyboard_React = 
                        new InlineKeyboardMarkup(new[]
                        {
                          new [] 
                          {
                            InlineKeyboardButton.WithCallbackData("👍"),
                            InlineKeyboardButton.WithCallbackData("👎🏿"),
                           }


                        });




        public static InlineKeyboardMarkup Reactions_List(List<string> reactions)
        {
            var buttons = new List<InlineKeyboardButton>();

            foreach (string reaction in reactions)
            {

                var button = new InlineKeyboardButton();
                button.Text = reaction;

                buttons.Add(button);


            }

            return new InlineKeyboardMarkup(buttons);
        }

            async public static void AddInlineKeyboards(Message message)

        {
            PhotoSize[] photoSize = message.Photo;
            var photo = photoSize[0].FileId;
            var chatID = message.Chat.Id;
            reactions.Add("👍");
            reactions.Add("👎🏿");
            ReplyKeyboardMarkup MyButton = new ReplyKeyboardMarkup();
            await Bot_ClientAPI.SendPhotoAsync(chatID, photo, replyMarkup: Reactions_List(reactions));
            await Bot_ClientAPI.DeleteMessageAsync(message.Chat.Id, message.MessageId);

        }

    }



}
