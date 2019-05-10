using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using ProstoBot.Commands;
using Npgsql;
using System.Collections.Generic;


namespace ProstoBot
{
    class BotController
    {
        public static readonly TelegramBotClient Bot_ClientAPI = new TelegramBotClient(BotSettings.Key);


        public static void Main(string[] args)
        {

            var me = Bot_ClientAPI.GetMeAsync().Result;
            Console.Title = me.Username;
            CommandController.vCommandHandler(Bot_ClientAPI);
            Bot_ClientAPI.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.WriteLine(DBConnect.PostgreSQLtestConnection());
            Console.ReadLine();
            Bot_ClientAPI.StopReceiving();
        }


        


        async public static void Message_Type(object sender, MessageEventArgs e)

        {
            //Debug line
            Console.WriteLine(e.Message.MessageId + "@" + e.Message.Chat.Id + " : " + e.Message.Type);

            switch (e.Message.Type)

            {
                case MessageType.Voice:

                    await Bot_ClientAPI.SendTextMessageAsync(chatId: e.Message.Chat,
                                                              text: "fuck you dumb voicefag" + e.Message.Text
                                                             );

                    break;

                case MessageType.Photo:
                    KeyboardReactions.AddInlineKeyboards(e.Message);
                    await Bot_ClientAPI.SendTextMessageAsync(chatId: e.Message.Chat,
                                                              text: "this is photo" + e.Message.Text
                                                             );
                    break;



            }


        }
    }
}
