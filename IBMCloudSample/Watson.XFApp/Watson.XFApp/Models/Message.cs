﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Watson.XFApp.Models
{
    class Message
    {
        public string Text { get; set; }
        // inputかoutputかを指定
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string ChatSource { get; set; } = "watson";
    }
}
