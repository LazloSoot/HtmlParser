using System;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public interface IParserController
    {
        event EventHandler<ParsingData> NewDataReceived;
        string Url { get; set; }
        string Source { get; set; }
        Task ParseAsync();
        Task SaveDataAsync();
        Task ReadDataAsync();
    }
}
