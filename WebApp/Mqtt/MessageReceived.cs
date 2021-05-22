using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Mqtt
{
    public class MessageReceived
    {
        public MessageReceived()
        {

        }
        public string Message { get; set; }
        public string Topic { get; set; }
    }
}
