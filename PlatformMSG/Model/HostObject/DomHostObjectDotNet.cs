using Newtonsoft.Json;
using PlatformMSG.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlatformMSG.Model.HostObject
{
    /// <summary>
    /// Класс для глобавльного объекта страницы
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class DomHostObjectDotNet
    {
        /// <summary>
        /// Приватное поле универсального провайдера сообщений
        /// </summary>
        IMessageDataProvider _provider;

        /// <summary>
        /// Конструктор с указанием провайдера сообщений 
        /// </summary>
        /// <param name="provider"></param>
        public DomHostObjectDotNet(IMessageDataProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        /// <summary>
        /// Глобальный метод вызываемый из JS и возвращающий 
        /// </summary>
        /// <returns></returns>
        public ChatMessage GetMessage(int index, bool test)
        {
            switch (index)
            {
                case 1:
                    return _provider.GetMessage1();
                case 2:
                    return _provider.GetMessage2();
                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Асинхронный глобальный метод вызываемый из JS и возвращающий 
        /// </summary>
        /// <returns></returns>
        public async Task<ChatMessage> GetMessageAsync(int index, bool test)
        {
            switch (index)
            {
                case 1:
                    return _provider.GetMessage1();
                case 2:
                    return _provider.GetMessage2();
                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}
