using HtmlParser.Data.Contexts;
using HtmlParser.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Bl.Interfaces;
using System.Collections.Specialized;
using System.Data.Entity;
using HtmlParser.Data;

namespace HtmlParser.Bl
{
    class ParserDataController<T, A, H, P> : IDataController<Dictionary<string, List<StringDictionary>>>
        where T : Tag
        where A : TagAttribute
        where H : HttpResponce
        where P : Parsing
    {
        IRepository<T> _tags;
        IRepository<A> _attrs;
        IRepository<H> _httpResponce;
        IRepository<P> _parsing;
        DbContext _context;

        public ParserDataController(IRepository<T> tags, IRepository<A> attrs, IRepository<H> httpResponce, IRepository<P> parsing)
        {
            _tags = tags;
            _attrs = attrs;
            _httpResponce = httpResponce;
            _parsing = parsing;
            _context = new DefaultContext("");
        }

        public ParserDataController(IRepository<T> tags, IRepository<A> attrs, IRepository<H> httpResponce, IRepository<P> parsing, DbContext context)
            :this(tags, attrs, httpResponce, parsing)
        {
            _context = context;
        }
        public Dictionary<string, List<StringDictionary>> ReadData()
        {
            throw new NotImplementedException();
        }

        public bool SaveData(Dictionary<string, List<StringDictionary>> data)
        {
            var parsing = new Parsing() { Date = DateTime.UtcNow }; // номер считать с лог файла
            var httpResponce = new HttpResponce();

            T _tag;
            A _attr;

            List<StringDictionary> attrs;

            foreach (var tags in data)
            {
               _tag = new Tag { Name = tags.Key, Parsing = parsing } as T;

                _tags.Create(_tag);

                attrs = tags.Value;

                foreach (var attribute in attrs)
                {
                    foreach (var attr in attribute.Keys)
                    {
                        _attr = new TagAttribute() { Name = attr.ToString(), Value = attribute[attr.ToString()], Tag = _tag } as A;
                        _attrs.Create(_attr);
                    }

                }
            }
            return true;
        }
    }
}
