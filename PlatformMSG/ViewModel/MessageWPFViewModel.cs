using GalaSoft.MvvmLight;
using PlatformMSG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformMSG.ViewModel
{
    public class MessageWPFViewModel : ChatMessageViewModel
    {
        public MessageWPFViewModel(ChatMessage chatMessage)
            : base(chatMessage)
        {

        }
    }
}
