using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System;

namespace HtmlParser.Bl
{
    class StringLoader : ILoader
    {
        readonly HttpClient _client;
        readonly string _url;

        public event EventHandler<Response> ResponseReceived;

        public int ResponseCode { get; private set;}
        public StringLoader(string url)
        {
            _client = new HttpClient();
            _url = url;
        }

        public async Task<string> GetPage()
        {
            var responce = await _client.GetAsync(_url);
            string source = null;
            Console.WriteLine("responce");
            source = await responce?.Content.ReadAsStringAsync();
            ResponseCode = (int)responce?.StatusCode;
            Console.WriteLine("received");
            ResponseReceived?.Invoke(this, new Response(ResponseCode, responce?.ReasonPhrase, responce?.Content.ToString(), responce?.Headers.ToString(), responce.IsSuccessStatusCode, responce?.Version.ToString()));
            Console.WriteLine("received");
            return source;
        }
    }
}
