using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public sealed class ParserSettings
    {
        public string[] Tags { get; }
        public string[] Attrs { get; }
        public ParserSettings(string[] tags, string[] attrs)
        {
            Tags = tags;
            Attrs = attrs;
        }
    }
}
