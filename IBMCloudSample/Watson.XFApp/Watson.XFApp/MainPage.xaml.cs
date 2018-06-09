//#define IBM
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.NetStandardCore;
using Xamarin.Forms;
using Watson.XFApp.Models;
using CloudServices.Core;
using Azure.NetStandardCore;

namespace Watson.XFApp
{
    public partial class MainPage : ContentPage
    {
#if IBM
        private readonly ICloudService cloudService = new WatsonAssistantClient();
#else
        private readonly ICloudService cloudService = new CognitiveClient();
#endif
        ObservableCollection<Message> _messages = new ObservableCollection<Message>();
        //WatsonAssistantClient client = new WatsonAssistantClient();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = _messages;
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            // インプットメッセージを追加
            var input = new Message
            {
                Text = entry.Text,
                Time = DateTime.Now,
                Type = "input"
            };
            _messages.Add(input);

            // アウトプットメッセージを取得
            var output = new Message
            {
                Text = await cloudService.GetResponseAsync(entry.Text),
                Time = DateTime.Now,
#if IBM
                Type = "watson",
#else
                Type = "azure",
#endif
            };
            _messages.Add(output);
        }
    }





    
}
