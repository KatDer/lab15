using Microsoft.VisualBasic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    static ITelegramBotClient bot = new TelegramBotClient("6251591558:AAHIT9WgnmyBwvf-YeiqN1ROhy80FgWKM**");

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

        String message = update.Message.Text;
        String selfName = update.Message.Chat.FirstName;
        long chatId = update.Message.Chat.Id;

        Boolean isFind = false;
        if (message.Equals("/start") || message.ToLower().Equals("главное меню"))
        {
            ReplyKeyboardMarkup Start = new(new[]
                  {
                    new KeyboardButton[] { "Привет", "Пока" },
                    new KeyboardButton[] { "Для девочки", "Для мальчика"},
                    new KeyboardButton[] { "Еще костюм для девочки", "Еще костюм для мальчика" }

                });


            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Привет!!",
               replyMarkup: Start
           );
        }

        if (message.ToLower().Contains("привет"))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Для кого ты бы хотел подобрать костюм?"
           );
        }

       

        if (message.ToLower().Equals("для девочки"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\d1.jpg");
          

            var photo = new InputOnlineFile(sr.BaseStream, "d1.jpg");
                

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo,
                 caption: $"Держи варианты костюмов для девочки,{selfName}!"
           );
        }

        if (message.ToLower().Equals("еще костюм для девочки"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\d2.jpg");


            var photo = new InputOnlineFile(sr.BaseStream, "d2.jpg");


            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo
                 
           );
        }

        if (message.ToLower().Equals("для девочки"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\d3.jpg");


            var photo = new InputOnlineFile(sr.BaseStream, "d3.jpg");


            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo
                 
           );
        }
        if (message.ToLower().Equals("для девочки"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\d4.jpg");


            var photo = new InputOnlineFile(sr.BaseStream, "d4.jpg");


            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo
                
           );
        }

        if (message.ToLower().Equals("для девочки"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\d5.jpg");


            var photo = new InputOnlineFile(sr.BaseStream, "d5.jpg");


            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo,
                 caption: $"Держи еще костюмы для девочки,{selfName}!"
           );
        }

        if (message.ToLower().Equals("для мальчика"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\m1.jpg");

            var photo = new InputOnlineFile(sr.BaseStream, "m1.jpg");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo,
                 caption: $"Держи варианты костюмов для мальчика,{selfName}!"
                );

        }
        if (message.ToLower().Equals("для мальчика"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\m2.jpg");

            var photo = new InputOnlineFile(sr.BaseStream, "m2.jpg");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo
                 
                );

        }
        if (message.ToLower().Equals("для мальчика"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\m3.jpg");

            var photo = new InputOnlineFile(sr.BaseStream, "m3.jpg");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo
               
                );

        }
        if (message.ToLower().Equals("для мальчика"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\m4.jpg");

            var photo = new InputOnlineFile(sr.BaseStream, "m4.jpg");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo
                 
                );

        }

        if (message.ToLower().Equals("еще костюм для мальчика"))
        {
            isFind = true;

            StreamReader sr = new StreamReader("d:\\m5.jpg");

            var photo = new InputOnlineFile(sr.BaseStream, "m5.jpg");

            await botClient.SendPhotoAsync(
                 chatId: chatId,
                 photo: photo,
                 caption: $"Держи еще костюмы для мальчика,{selfName}!"
                );

        }
        if (message.ToLower().Contains("пока"))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Пока!!"
           );
        }

        if (message.ToLower().Contains("спасибо"))
        {
            isFind = true;
            await botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Всегда пожалуйста)"
           );
        }



        if (!isFind)
        {
            await botClient.SendTextMessageAsync(
              chatId: chatId,
              text: "Извини, я тебя не понимаю("
          );
        }

    }

    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

        var cts = new CancellationTokenSource();

        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // разрешено получать все виды апдейтов
        };

        bot.StartReceiving(
        HandleUpdateAsync,
            HandleErrorAsync,
             receiverOptions,
            cancellationToken

        );
        Console.ReadLine();
    }
}
