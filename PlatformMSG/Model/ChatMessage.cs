using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformMSG.Model
{
    public class ChatMessage
    {
        public string Owner
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public ChatMessage()
        {
        }

        public ChatMessage(string owner, string message)
        {
            Owner = owner;
            Message = message;
        }
    }
}
