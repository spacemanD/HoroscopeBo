using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions
{
    public class AppException : Exception
    {
        public int? ChatId { get; set; }

        public AppException(string message, int? chatId = null) : base(message)
        {
            ChatId = chatId;
        }
    }
}
