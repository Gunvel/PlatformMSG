using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlatformMSG.Model
{
    /// <summary>
    /// Объект сообщения чата
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class ChatMessage
    {
        /// <summary>
        /// Автор сообщения
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ChatMessage()
        {
        }

        /// <summary>
        /// Конструктор с указанием автора и сообщения
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        public ChatMessage(string owner, string message)
        {
            Owner = owner;
            Message = message;
        }
    }
}
