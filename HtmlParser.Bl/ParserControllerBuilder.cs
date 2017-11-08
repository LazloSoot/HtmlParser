using System;
using System.Collections.Generic;
using System.Data;

namespace HtmlParser.Bl
{
    public static class ParserControllerBuilder
    {
        static List<StringParserController> _parserControllers;
        public static IParserController GetController<ResultType>(string url, string source,ParserSettings settings, ParserType parserType) where ResultType : class 
            {
            if (typeof(ResultType) == typeof(DataTable))
                try
                {
                    return new StringParserController(
                         url, source, settings, parserType)
                         as IParserController;
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