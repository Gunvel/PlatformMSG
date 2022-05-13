using GalaSoft.MvvmLight;
using PlatformMSG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformMSG.ViewModel
{
    public abstract class ChatMessageViewModel : ViewModelBase
    {
        private ChatMessage _chatMessage;

        public string Owner
        {
            get
            {
                return _chatMessage.Owner;
            }
        }

        public string Message
        {
            get
            {
                return _chatMessage.Message;
            }
        }

        public ChatMessageViewModel(ChatMessage chatMessage)
        {
            _chatMessage = chatMessage ?? throw new ArgumentNullException(nameof(chatMessage));
        }
    }
}
