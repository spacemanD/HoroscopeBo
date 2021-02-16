using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Options
{
    public class BotOptions
    {
        public string Name { get; set; }

        public string Token { get; set; }

        public string WebHookUrl { get; set; } // ngrok http https://localhost:5001 -host-header="localhost:5001"
    }
}
