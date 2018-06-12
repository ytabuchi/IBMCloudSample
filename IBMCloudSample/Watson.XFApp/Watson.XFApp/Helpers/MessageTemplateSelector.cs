using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Watson.XFApp.Models;
using System.Linq;

namespace Watson.XFApp.Helpers
{
    [ContentProperty(nameof(Templates))]
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public List<Template> Templates { get; } = new List<Template>();

        // itemにはセルのデータ、containerにはセルの親(ListViewやTableView)が渡されます
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // outputのMessageを取得する際に、#defineで指定したTypeを取得してテンプレートを指定します
            return Templates.FirstOrDefault(x => x.TemplateType == ((Message)item).Type)?.DataTemplate;
        }

    }

    public class Template
    {
        public string TemplateType { get; set; }
        public DataTemplate DataTemplate { get; set; }
    }
}
