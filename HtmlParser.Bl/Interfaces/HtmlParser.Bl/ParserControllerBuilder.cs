using HtmlParser.Bl.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using HtmlParser.Data;
using HtmlParser.Data.Entities;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HtmlParser.Data.Contexts;

namespace HtmlParser.Bl
{
    public static class ParserControllerBuilder
    {
        static DbContext _contect = new DefaultContext("");
        public static IParserController<ResultType> GetController<ResultType>(string url, string source,ParserSettings settings) where ResultType : class 
            {
            if (typeof(ResultType) == typeof(Dictionary < string, List < StringDictionary >>))
                try
                {
                    return new StringParserController(
                        url, source, settings,
                        new ParserDataController<Tag, TagAttribute, HttpResponce, Parsing>(
                            new ParserRepository<Tag>(_contect) as IRepository<Tag>,
                            new ParserRepository<TagAttribute>(_contect) as IRepository<TagAttribute>,
                            new ParserRepository<HttpResponce>(_contect) as IRepository<HttpResponce>,
                            new ParserRepository<Parsing>(_contect) as IRepository<Parsing>
                            )
                        as IDataController<Dictionary<string, List<StringDictionary>>>)
                        as IParserController<ResultType>;
                }
                catch(NullReferenceException ex)
                {
                    throw ex;
                }
            else
                throw new NotSupportedException("Не поддерживаемый тип парсера!");
            }
    }
}
