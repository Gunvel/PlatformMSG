using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformMSG.Model.Service
{
    /// <summary>
    /// Интерфейс провайдера сообщений
    /// </summary>
    public interface IMessageDataProvider
    {
        /// <summary>
        /// Метод возвращает сообщение 1
        /// </summary>
        /// <returns></returns>
        ChatMessage GetMessage1();

        /// <summary>
        /// Метод возвращает сообщение 2
        /// </summary>
        /// <returns></returns>
        ChatMessage GetMessage2();
    }
}
