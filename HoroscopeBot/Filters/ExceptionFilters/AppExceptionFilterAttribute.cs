using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoroscopeBot.Filters.ExceptionFilters
{
    public class AppExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<AppExceptionFilterAttribute> logger;

        public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().IsSubclassOf(typeof(AppException)))
            {
                int? chatId = (context.Exception as AppException).ChatId;
                if (chatId != null)
                {
                    //birthdayBot.BotClient.SendTextMessageAsync(chatId, context.Exception.Message);
                    this.logger.LogError($"Error for user {chatId}");
                }
                ObjectResult result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = StatusCodes.Status200OK
                };

                context.Result = result;
            }
            else
            {
                this.logger.LogError(context.Exception.Message, context.Exception.StackTrace);

                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }

            context.ExceptionHandled = true;
        }
    }
}
