using BLL;
using HoroscopeBot.Filters.ExceptionFilters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using ApiAiSDK;
using ApiAiSDK.Model;
using Telegram.Bot;

namespace HoroscopeBot.Controllers
{
    [Route("/")]
    [ServiceFilter(typeof(AppExceptionFilterAttribute))]
    public class HomeController : ControllerBase
    { 
        private readonly AppBot bot;

       public HomeController(AppBot bot)
       {
            this.bot = bot;
       }


        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            return Ok("Ok!");
        }
       

        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> Post([FromBody] Update update)
        {

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {


                if (update.Message.Text?.StartsWith('/') ?? false)
                {
                    string text =
            @"/start - Для старта программы
/button - для доп функций";
                    await this.bot.BotClient.SendTextMessageAsync(update.Message.Chat.Id, text);
                    #region inlinebuttons
                    switch (update.Message.Text)
                    {
                        case "/start":
                            {

                                var startMarkup = new InlineKeyboardMarkup(new[]
                                {
                                            new[] //first row
                                            {
                                                new InlineKeyboardButton { Text = "Show my horoscope today", CallbackData = "horoscopeToday" },
                                                 new InlineKeyboardButton { Text = "I wanna just have a talk", CallbackData = "havetalk" },

                                            }
                                });

                                await this.bot.BotClient.SendTextMessageAsync(update.Message.Chat.Id, "Hello", replyMarkup: startMarkup);

                                break;

                            }
                        case "/buttom":
                            {

                                break;
                            }
                    }
                }

                else if (update.Message.Text != null)
                {
                    switch (update.Message.Text)
                    {
                        case "Horoscope":
                            {
                                var keyboard = new ReplyKeyboardMarkup(new[]
                                       {
                                        new []{new KeyboardButton {Text = "Aries, Mar 21- Ap 19"} },
                                        new []{new KeyboardButton {Text = "Taurus, Apr 20 - May 20"} },
                                        new []{new KeyboardButton { Text = "Gemini, MAy 21 - Jun 21" } },
                                        new []{new KeyboardButton { Text = "Cancer, Jun 22 - Jul 22" } },
                                        new []{new KeyboardButton { Text = "Leo, Jul 23 - Aug 22" } },
                                        new []{new KeyboardButton { Text = "Libra, Sep 23 - Oct 23" } },
                                        new []{new KeyboardButton { Text = "Scorpio, Oct 24 - Nov 22" } },
                                        new []{new KeyboardButton { Text = "Saggittarius, Nov 23 - Dec 21" } },
                                        new []{new KeyboardButton { Text = "Capricorn, Dec 22 - Jan 19" } },
                                        new []{new KeyboardButton { Text = "Aquaruis, Jan 20 - Feb 19" } },
                                        new []{new KeyboardButton { Text = "Pisces, Feb 20 - Mar 20" } },
                                        new []{new KeyboardButton { Text = "Back" } },

                                    });
                                await this.bot.BotClient.SendTextMessageAsync(update.Message.Chat.Id, "Opt out!", replyMarkup: keyboard);

                                break;
                            }
                        case "Aries, Mar 21- Ap 19":
                            {

                                await this.bot.BotClient.SendTextMessageAsync(update.Message.Chat.Id,"Hey,friend",replyToMessageId: update.Message.MessageId);
                                break;
                            }

                        default:
                            break;
                    }
                }
                    }

            else if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {

                switch (update.CallbackQuery.Data)
                {
                    case "horoscopeToday":
                        {
                            var replyKeyboard = new ReplyKeyboardMarkup(new[]
                                        {
                                        new[]
                                        {
                                            new KeyboardButton("шалом!"),
                                            new KeyboardButton("Horoscope")
                                        },
                                        new[]
                                        {
                                            new KeyboardButton("Contact") { RequestContact = true},
                                           new KeyboardButton("Location") { RequestLocation = true }

                                        }
                                        });
                            await this.bot.BotClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Firstly, You need to choose Location, If you want to recieve the horoscope daily ", replyMarkup: replyKeyboard);

                            break;
                        }
                    case "havetalk":
                        {
                            await this.bot.BotClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "You can speak with google assistant, write something pleasant in chat");
                            break;
                        }
                    default:
                        await this.bot.BotClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id, "I handled this!", true);
                        break;
                }


            }
                    #endregion
                   
           
          
            // TODO: kIRILL=DOLBODATEL

            return Ok();
        }

    }

}