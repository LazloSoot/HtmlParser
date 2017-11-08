using AngleSharp.Dom.Html;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public interface IParser<T> where T : class
    {
        ParserSettings Settings { get; set; }
        Task<T> Parse(IHtmlDocument document);
    }

}
