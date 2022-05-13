﻿using CommonServiceLocator;
using Microsoft.Web.WebView2.Core;
using PlatformMSG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using PlatformMSG.Model;

namespace PlatformMSG.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Модель представления
        /// </summary>
        MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = ServiceLocator.Current.GetInstance<MainViewModel>(); //Получаем модель представления из локатора

            webView.NavigationStarting += WebView_NavigationStarting; //Начало загрузки страницы
            webView.NavigationCompleted += WebView_NavigationCompleted; //Конец загрузки страницы

            InitializeAsync();
        }

        private void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            wpfChatRoom.IsEnabled = false; //Отключаем чат WPF пока идет загрузка страницы
            _viewModel.Messages.Clear(); //Очищаем сообщения если они были
        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            wpfChatRoom.IsEnabled = true; //Включаем чат WPF
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async();
            webView.CoreWebView2.SetVirtualHostNameToFolderMapping("html", "html", CoreWebView2HostResourceAccessKind.Allow);
            webView.Source = new Uri("http://html/index.html");

            webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived; //Прослушиваем сообщения от страницы
        }

        /// <summary>
        /// Получаем сообщение от странцицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string data = e.WebMessageAsJson;

            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
                return;

            ChatMessage cm = JsonConvert.DeserializeObject<ChatMessage>(data);

            _viewModel.Messages.Add(new MessageHTMLViewModel(cm));
        }

        /// <summary>
        /// Отправляем сообщение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_viewModel.MessageText) || string.IsNullOrWhiteSpace(_viewModel.MessageText))
                return;

            ChatMessage ms = new ChatMessage("WPF", _viewModel.MessageText);
            _viewModel.Messages.Add(new MessageWPFViewModel(ms));

            _viewModel.MessageText = "";

            string json = JsonConvert.SerializeObject(ms);

            webView.CoreWebView2.PostWebMessageAsString(json); //Отправляем сообщение на страницу
        }

        /// <summary>
        /// Обработка нажатия Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Button_Click(null, null); //Из-за кривых биндингов _viewModel.MessageText = null и это не работает
        }
    }
}
