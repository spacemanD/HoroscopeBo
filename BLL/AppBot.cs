using Core.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BLL
{
    public class AppBot
    {
        public TelegramBotClient BotClient { get; private set; }

        public AppBot(BotOptions botOptions)
        {
            this.BotClient = InitializeBot(botOptions).Result;
        }

        private async Task<TelegramBotClient> InitializeBot(BotOptions botOptions)
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient(botOptions.Token);
            string hook = botOptions.WebHookUrl;    // Setting the webhook for telegram
            Console.WriteLine(hook);
            await telegramBotClient.SetWebhookAsync(hook);
            return telegramBotClient;
        }
    }
}
