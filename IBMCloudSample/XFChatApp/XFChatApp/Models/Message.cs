using System;
using System.Collections.Generic;
using System.Text;

namespace XFChatApp.Models
{
    class Message
    {
        public string Text { get; set; }
        // inputか、どのoutputかを指定
        public string Type { get; set; }
        public DateTime Time { get; set; }
    }
}
