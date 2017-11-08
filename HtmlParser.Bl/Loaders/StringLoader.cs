using System.Threading.Tasks;
using System.Net.Http;
using System;
using HtmlParser.Data;
using System.Diagnostics;

namespace HtmlParser.Bl
{
    class StringLoader : ILoader
    {
        readonly HttpClient _client;
        readonly string _url;

        public event EventHandler<HttpResponce> ResponseReceived;

        public int ResponseCode { get; private set;}
        public StringLoader(string url)
        {
            _client = new HttpClient();
            _url = url;
        }

        public async Task<string> GetPage()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var responce = await _client.GetAsync(_url);
            timer.Stop();
            string source = null;
            source = await responce?.Content.ReadAsStringAsync();
            ResponseCode = (int)responce?.StatusCode;
            ResponseReceived?.Invoke(this, new HttpResponce()
            {
                Content = responce.Content.ToString(), IsSuccessStatusCode = responce.IsSuccessStatusCode,
                Headers = responce.Headers.ToString(), ReasonPhrase = responce.ReasonPhrase.ToString(),
                StatusCode = ResponseCode, Version = responce.Version.ToString(),
                Durration = timer.ElapsedMilliseconds,
                Date = responce.Headers.Date.Value.DateTime
                
            });
            return source;
        }
    }
}
