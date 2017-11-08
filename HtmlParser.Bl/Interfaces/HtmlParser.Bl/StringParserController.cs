using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Bl.Interfaces;
using HtmlParser.Data;

namespace HtmlParser.Bl
{
    class StringParserController : IParserController<Dictionary<string, List<StringDictionary>>>
    {
        string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                lock (_block)
                {
                    _url = value;
                   _loader = new StringLoader(_url);
                    _loader.ResponseReceived += _loader_ResponseReceived;
                }
                
            }
        }

        private readonly object _block = new object();
        public string Source { get; set; }
        bool isUrl;
        readonly IParser<Dictionary<string, List<StringDictionary>>> _parser;
        ILoader _loader;
        IDataController<Dictionary<string, List<StringDictionary>>> _dataController;
        Dictionary<string, List<StringDictionary>> _result;
        public event EventHandler<ParseResult<Dictionary<string, List<StringDictionary>>>> ParsingCompleted;
        public event EventHandler<Response> ResponseReceived;

        public StringParserController(string url,string source ,ParserSettings settings)
        {
            _parser = new StringParser(settings) as IParser<Dictionary<string, List<StringDictionary>>>;

            if (string.IsNullOrWhiteSpace(source))
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new NullReferenceException("URL и текст разметки пуст!Нечего парсить");
                }
                Url = url;
                isUrl = true;
            }else
            {
                Source = source;
                isUrl = false;
            }
            
        }
        public StringParserController(string url, string source, ParserSettings settings, IDataController<Dictionary<string, List<StringDictionary>>> dataController)
            :this (url, source, settings)
        {
            _dataController = dataController;
        }

        public async Task Parse()
        {
            string source;
            if (isUrl)
                source = await _loader.GetPage();
            else
                source = Source;
            Console.WriteLine("loader");
            var domParser = new AngleSharp.Parser.Html.HtmlParser();
            var document = await domParser.ParseAsync(source);
            Console.WriteLine("parser");
             _result = await _parser.Parse(document);
            ParsingCompleted?.Invoke(this, new ParseResult<Dictionary<string, List<StringDictionary>>>() { Res = _result });
            //OnNewData?.Invoke(this, result);
        }
        public void SaveData()
        {
            _dataController.SaveData(_result);
        }
        private void _loader_ResponseReceived(object sender, Response e)
        {
            ResponseReceived?.Invoke(this, e);
        }

    }

    public class ParseResult<ResultType> : EventArgs
    {
        public ResultType Res { get; internal set; }
    }


}
