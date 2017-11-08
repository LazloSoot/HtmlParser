using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public interface IParserController<ResultType> where ResultType : class
    {
        event EventHandler<ParseResult<ResultType>> ParsingCompleted;
        event EventHandler<Response> ResponseReceived;
        string Url { get; set; }
        string Source { get; set; }
        Task Parse();
        void SaveData();
    }
}
