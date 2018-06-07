using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Watson.XFApp.Models;

namespace Watson.XFApp.Helpers
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate inputTmpl { get; set; }
        public DataTemplate outputTmpl { get; set; }

        // itemにはセルのデータ、containerにはセルの親(ListViewやTableView)が渡される
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Message)item).Type == "input" ? inputTmpl : outputTmpl;
        }

    }
}
