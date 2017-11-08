using System;
using System.Data;

namespace HtmlParser.Bl
{
    public class ParsingData : EventArgs
    {
        public DataTable Data { get; set; }
        public string Name { get; set; }
    }
}
