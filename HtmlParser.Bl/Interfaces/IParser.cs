using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public interface IParser<T> 
        where T : class
    {
        ParserSettings Settings { get;}
        /// <summary>
        /// Parses the certain html document and returns result of parsing
        /// </summary>
        /// <param name="source">source text of html document</param>
        /// <returns>Parsed data of T</returns>
        Task<T> ParseAsync(string source);
    }

}
