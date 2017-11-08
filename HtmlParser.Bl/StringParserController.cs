using HtmlParser.Data;
using HtmlParser.DataAccess;
using HtmlParser.DataAccess.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace HtmlParser.Bl
{
    class StringParserController : IParserController
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
                _url = value;
                _loader = new StringLoader(_url);
                _loader.ResponseReceived += _loader_ResponseReceived;
            }
        }
        public string Source { get; set; }
        bool IsUrl { get => (!string.IsNullOrEmpty(Url)); }
        readonly IParser<Parsing> _parser;
        ILoader _loader;
        IDataController<Parsing, Tag> _dataController;
        Parsing _result;
        List<HttpResponce> _responces;
        static bool isDataRead = false;
        public event EventHandler<ParsingData> NewDataReceived;

        public StringParserController(string url, string source, ParserSettings settings, ParserType parserType)
        {
            _responces = new List<HttpResponce>();
            _dataController = new ParserDataController();
            switch (parserType)
            {
                case ParserType.Agility:
                    {
                        _parser = new AgilityPackParser(settings) as IParser<Parsing>;
                        break;
                    }
                case ParserType.AngleSharp:
                    {
                        _parser = new AngleSharpParser(settings) as IParser<Parsing>;
                        break;
                    }
                default:
                    throw new ArgumentException("Неизвестный тип парсера!");
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new NullReferenceException("URL и текст разметки пуст!Нечего парсить");
                }
                Url = url;
            }
            else
            {
                Source = source;
            }
        }
        public StringParserController(string url, string source, ParserSettings settings, ParserType parserType, IDataController<Parsing, Tag> dataController)
            : this(url, source, settings, parserType)
        {
            _dataController = dataController;
        }

        public async Task ParseAsync()
        {
            isDataRead = false;
            string source;
            if (IsUrl)
                source = await _loader.GetPage();
            else
                source = Source;

            
            _result = await _parser.ParseAsync(source);
            _result.Url = (IsUrl) ? Url : "none";

            if(_responces == null)
                throw new ArgumentNullException("Http ответ не получен!");
            if (_result == null)
                throw new ArgumentNullException("Результат парсинга не получен!");
            if(_result.Tags == null || _result.Tags.Count == 0)
                throw new ArgumentNullException("Не найденно ни одного тега!");

            _result.Responces = _responces;
            for (int i = 0; i < _responces.Count; i++)
            {
                _responces[i].Parsing = _result;
                _responces[i].ParsingID = _result.ParsingID;
            }

            DataTable resultData = await ToDataTableAsync<Parsing>(new List<Parsing>() { _result });
            NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Parsing" });

            resultData = await ToDataTableAsync<HttpResponce>(_result.Responces as List<HttpResponce>);
            NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Responce" });

            resultData = await TagsToDataTableAsync(_result.Tags as List<Tag>);
            NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Result" });
        }
        public async Task SaveDataAsync()
        {
            if (_result == null)
                throw new ArgumentNullException("Результат парсинга пуст!");

            await _dataController.AddDataAsync(_result);
        }

        public async Task ReadDataAsync()
        {
            isDataRead = true;
            List<Parsing> result = await _dataController.GetAllDataAsync() as List<Parsing>;
            if (result.Count == 0)
                throw new ArgumentNullException("База данных пуста");

            DataTable resultData = await ToDataTableAsync<Parsing>(result);
            NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Parsing" });

            resultData = await ToDataTableAsync<HttpResponce>(result[0].Responces as List<HttpResponce>);
            NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Responce" });

            try
            {
                resultData = await TagsToDataTableAsync(result[0].Tags as List<Tag>);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Result" });

            if (result.Count > 1)
            {
                for (int i = 1; i < result.Count; i++)
                {
                    try
                    {
                        resultData = await TagsToDataTableAsync(result[i].Tags as List<Tag>);
                    }
                    catch (ArgumentNullException ex)
                    {
                        throw ex;
                    }
                    NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Result" });
                }

                for (int i = 1; i < result.Count; i++)
                {
                    resultData = await ToDataTableAsync<HttpResponce>(result[i].Responces as List<HttpResponce>);
                    NewDataReceived?.Invoke(this, new ParsingData() { Data = resultData, Name = "Responce" });
                }
            }
        }
        private void _loader_ResponseReceived(object sender, HttpResponce e)
        {
            _responces.Add(e);
        }
        static async Task<DataTable> ToDataTableAsync<T>(List<T> items)
        {
            return await Task<DataTable>.Run(() =>
            {
                DataTable dataTable = new DataTable(typeof(T).Name);

                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    dataTable.Columns.Add(prop.Name, type);
                    if (isDataRead && (prop.Name.Contains("ID") || prop.Name.Contains("Id")))
                        dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[prop.Name] };
                }
                var values = new List<object>();
                object obj;
                foreach (T item in items)
                {
                    for (int i = 0; i < Props.Length; i++)
                    {
                        obj = Props[i].GetValue(item, null);
                        if (obj is ICollection)
                        {
                            if (dataTable.Columns.Contains(Props[i].Name))
                                dataTable.Columns.Remove(Props[i].Name);
                        }
                        else
                            values.Add(obj);
                    }
                    dataTable.Rows.Add(values.ToArray());
                    values = new List<object>();
                }
                return dataTable;
            });

        }
        static async Task<DataTable> TagsToDataTableAsync(List<Tag> tags)
        {
            if (tags == null || tags.Count == 0)
                throw new ArgumentNullException("Коллекция тегов пуста!");
            return await Task.Run(() =>
            {
                DataTable dataTable = new DataTable("Tags");
                string[] keys;
                int keyIndex = 0;
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("ParsingID");
                if (isDataRead)
                {
                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"], dataTable.Columns["ParsingID"] };
                }
                dataTable.Columns.Add("TagName");

                keys = new string[tags[0].Attributes.Count];
                foreach (var attr in tags[0].Attributes)
                {
                    dataTable.Columns.Add(attr.Name);
                    keys[keyIndex++] = attr.Name;
                }
                keyIndex = 0;

                var values = new List<object>();

                foreach (Tag tag in tags)
                {
                    values.Add(tag.TagId);
                    values.Add(tag.Parsing.ParsingID);
                    values.Add(tag.Name);

                    for (int i = 0; i < tag.Attributes.Count; i++)
                    {
                        values.Add(tag.Attributes.Where(a => a.Name == keys[keyIndex]).Select(a => a.Value).First());
                        keyIndex++;
                    }

                    keyIndex = 0;

                    dataTable.Rows.Add(values.ToArray());
                    values = new List<object>();
                }
                return dataTable;
            });
        }

    }
}