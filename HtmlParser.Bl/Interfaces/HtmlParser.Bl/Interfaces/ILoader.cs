using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public interface ILoader
    {
        int ResponseCode { get;}
        Task<string> GetPage();
        event EventHandler<Response> ResponseReceived;
    }

    public class Response
    {
        public int StatusCode { get; }
        public string ReasonPhrase { get; }
        public string Content { get; }
        public string Headers { get; }
        public bool IsSuccessStatusCode { get; }
        public string Version { get; }

        public Response(int code, string reasonPhrase, string content, string headers, bool isSuccess, string version)
        {
            StatusCode = code;
            ReasonPhrase = reasonPhrase;
            Content = content;
            Headers = headers;
            IsSuccessStatusCode = isSuccess;
            Version = version;
        }
    }
}
