using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.NetStandardCore;
using Xamarin.Forms;
using Watson.XFApp.Models;

namespace Watson.XFApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Message> _messages = new ObservableCollection<Message>();
        WatsonAssistantClient client = new WatsonAssistantClient();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = _messages;
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            // インプットメッセージを追加
            var input = new Message
            {
                Text = entry.Text,
                Time = DateTime.Now,
                Type = "input"
            };

            // アウトプットメッセージを取得
            var output = new Message
            {
                Text = client.GetResponse(entry.Text),
                Time = DateTime.Now
            };
            _messages.Add(input);
            _messages.Add(output);
        }
    }





    
}
