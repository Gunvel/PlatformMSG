using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformMSG.Model.Service
{
    /// <summary>
    /// Класс-провайдер сообщений
    /// </summary>
    internal class MessageDataProvider : IMessageDataProvider
    {
        /// <summary>
        /// Метод возвращает сообщение 1
        /// </summary>
        /// <returns></returns>
        public ChatMessage GetMessage1()
        {
            return new ChatMessage("DotNet", "This is message1");
        }

        /// <summary>
        /// Метод возвращает сообщение 2
        /// </summary>
        /// <returns></returns>
        public ChatMessage GetMessage2()
        {
            return new ChatMessage("DotNet", "This is message2");
        }
    }
}
