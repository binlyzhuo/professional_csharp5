using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt10
{
    public class Document
    {
        public string Title { set; get; }
        public string Content { set; get; }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
}
