using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using AngleSharp.Dom.Html;
using HtmlParser.Data;
using System.Threading.Tasks;
using System.Threading;

namespace HtmlParser.Bl
{
    public class StringParser : IParser<Dictionary<string, List<StringDictionary>>>
    {
        public ParserSettings Settings { get; set; }

        public StringParser(ParserSettings settings)
        {
            Settings = settings;
        }
        public async Task<Dictionary<string, List<StringDictionary>>> Parse(IHtmlDocument document)
        {
            Dictionary<string, List<StringDictionary>> result = new Dictionary<string, List<StringDictionary>>();
            foreach (string tag in Settings.Tags)
            {
                AngleSharp.Dom.IHtmlCollection<AngleSharp.Dom.IElement> items = document?.QuerySelectorAll(tag); //.Where(item => item.ClassName != null && item.ClassName.Contains(""));
                List<StringDictionary> elements = new List<StringDictionary>();
                foreach (AngleSharp.Dom.IElement item in items)
                {
                    elements.Add(ParseTag(item));
                }
                result.Add(tag, elements);
            }
            return result;
        }

        // возвращает коллекцию атрибутов и их значений для тега
        StringDictionary ParseTag(AngleSharp.Dom.IElement element)
        {
            StringDictionary attrsList = new StringDictionary();

                if (element == null )// || string.IsNullOrEmpty(element.TextContent))
                    attrsList.Add( "emptyAttribute", "emptyValue");
                else
            {
                string value = "";
                //string[] attrs = Settings.Attrs;
                //string attr;
                //for (int i = 0; i < attrs.Length; i++)
                //{
                //    attr = attrs[i];
                //    switch (attr)
                //    {
                //        case "Id":
                //            {
                //                value = element.Id;
                //                break;
                //            }
                //        case "Class":
                //            {
                //                value = element.ClassList.ToString();
                //                break;
                //            }
                //        case "TextContent":
                //            {

                //                value = element.TextContent;
                //                break;
                //            }
                //        case "InnerHtml":
                //            {
                //                value = element.InnerHtml;
                //                break;
                //            }
                //        case "BaseUrl":
                //            {
                //                value = element.BaseUrl.ToString();
                //                break;
                //            }
                //        default:
                //            {
                //                value = element.GetAttribute(attr);
                //                break;
                //            }
                //    }
                //    attrsList.Add($"{attr}", $"{value}");
                //}
                foreach (string attr in Settings.Attrs)
                {
                    // if(element.)
                    switch (attr)
                    {
                        case "id":
                            {
                                value = element.Id;
                                break;
                            }
                        case "сlass":
                            {
                                value = element.ClassList.ToString();
                                break;
                            }
                        case "textContent":
                            {

                                value = element.TextContent;
                                break;
                            }
                        case "innerHtml":
                            {
                                value = element.InnerHtml;
                                break;
                            }
                        case "baseUrl":
                            {
                                value = element.BaseUrl.ToString();
                                break;
                            }
                        default:
                            {
                                value = element.GetAttribute(attr);
                                break;
                            }
                    }
                    attrsList.Add($"{attr}", $"{value}");
                }
            }
                 
                        
            return attrsList;
        }

        //Dictionary<string, StringDictionary> PPP(IHtmlDocument document)

        public string[] PP(IHtmlDocument document)
        {
            StringDictionary attrs = new StringDictionary();
          
            return null;
        }
        static T CastType<T>(object obj, T type) {
            return (T)obj;
        }

        static object GetElemetnsList(string tag, string[] attrs) {
            return new { Name = tag, Attrs = attrs , AttrsVal = "" };
        }
    }
}
