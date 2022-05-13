using GalaSoft.MvvmLight;
using PlatformMSG.Model;
using PlatformMSG.View.Util;
using System.Collections.ObjectModel;

namespace PlatformMSG.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ChatMessageViewModel> _messages;
        private string _messageText;
        private RelayCommand _sendCommand;

        public ObservableCollection<ChatMessageViewModel> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                Set(ref _messages, value);
            }
        }

        public string MessageText
        {
            get
            {
                return _messageText;
            }
            set
            {
                Set(ref _messageText, value);
            }
        }

        public RelayCommand SendCommand
        {
            get
            {
                return _sendCommand;
            }
            set
            {
                Set(ref _sendCommand, value);
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<ChatMessageViewModel>();

            SendCommand = new RelayCommand(Send);
        }

        private void Send()
        {
            if (string.IsNullOrEmpty(_messageText) || string.IsNullOrWhiteSpace(_messageText))
                return;

            ChatMessage ms = new ChatMessage("WPF", _messageText);
            Messages.Add(new MessageWPFViewModel(ms));

            //MessageHTML ms = new MessageHTML(_messageText);
            //Messages.Add(new MessageHTMLViewModel(ms));

            MessageText = "";
        }
    }
}