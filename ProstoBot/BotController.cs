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
    class BotController
    {
        public static readonly TelegramBotClient Bot_ClientAPI = new TelegramBotClient(BotSettings.Key);

        private static InlineKeyboardMarkup InlineKeyboard_React = new InlineKeyboardMarkup(new[]
                  {
                        new [] // first row
                        {
                            InlineKeyboardButton.WithCallbackData("👍"),
                            InlineKeyboardButton.WithCallbackData("👎🏿"),
                        }
                     
});

        public static void Main(string[] args)
            {   
           // var botSettings = BotSettings.Bot_Client;

            var me = Bot_ClientAPI.GetMeAsync().Result;
            Console.Title = me.Username;

            CommandController.vCommandHandler(Bot_ClientAPI);
            // Bot_ClientAPI.OnMessage += WriteShit;

            Bot_ClientAPI.OnMessage += Message_Type;
            //Bot.OnMessageEdited += BotOnMessageReceived;
            //Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            //Bot.OnInlineQuery += BotOnInlineQueryReceived;
            //Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            //Bot.OnReceiveError += BotOnReceiveError;

            Bot_ClientAPI.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
            Bot_ClientAPI.StopReceiving();
        }



        async static void AddInlineKeyboards(Message message)

        {
            PhotoSize[] photoSize = message.Photo;
            var photo = photoSize[0].FileId;
            var chatID = message.Chat.Id;
            ReplyKeyboardMarkup MyButton = new ReplyKeyboardMarkup();
            await Bot_ClientAPI.SendPhotoAsync(chatID, photo, replyMarkup: InlineKeyboard_React);
                 


        }


        async static void Message_Type(object sender, MessageEventArgs e)

        {
            //Debug line
            Console.WriteLine(e.Message.MessageId + "@" + e.Message.Chat.Id + " : " + e.Message.Type);

            switch (e.Message.Type)

            {
                case MessageType.Voice:

                    await Bot_ClientAPI.SendTextMessageAsync( chatId: e.Message.Chat,
                                                              text: "fuck you dumb voicefag" + e.Message.Text
                                                             );
                break;

                case MessageType.Photo:
                     AddInlineKeyboards(e.Message);
                     await Bot_ClientAPI.SendTextMessageAsync( chatId: e.Message.Chat,
                                                               text: "this is photo" + e.Message.Text
                                                              );
               break;



            }

        }
    }
}
