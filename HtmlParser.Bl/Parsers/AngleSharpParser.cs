using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using HtmlParser.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public class AngleSharpParser : IParser<Parsing>
    {
        IHtmlDocument _document;
        string _source;
        public ParserSettings Settings { get; internal set; }
        public AngleSharpParser(ParserSettings settings)
        {
            Settings = settings;
        }

        public async Task<Parsing> ParseAsync(string source)
        {
            if (string.IsNullOrWhiteSpace(_source) || !Equals(_source, source))
            {
                _source = source;
                var domParser = new AngleSharp.Parser.Html.HtmlParser();
                _document = await domParser.ParseAsync(source);
            }
            
            Parsing result = new Parsing();
            List<Tag> tags = new List<Tag>();
            IHtmlCollection<IElement> parsedTags;

            await Task.Run(() =>
            {
                foreach (string element in Settings.Tags)
                {
                    parsedTags = _document?.QuerySelectorAll(element);
                    foreach (IElement tag in parsedTags)
                    {
                        tags.Add(new Tag() { Name = tag.TagName.ToLower(), Attributes = ParseTag(tag), Parsing = result });
                    }
                }
                result.Date = DateTime.UtcNow;
                result.Tags = tags;
            });
            return result;
        }

        List<TagAttribute> ParseTag(IElement element)
        {
            List<TagAttribute> attrsList = new List<TagAttribute>();

            if (element == null)
                throw new ArgumentNullException("Элемент DOM не получен");
            else
            {
                string value = "";
                foreach (string attr in Settings.Attrs)
                {
                    switch (attr)
                    {
                        case "TagId":
                            {
                                value = element.Id;
                                break;
                            }
                        case "Class":
                            {
                                value = element.ClassList.ToString();
                                break;
                            }
                        case "TextContent":
                            {

                                value = element.TextContent;
                                break;
                            }
                        default:
                            {
                                value = element.GetAttribute(attr);
                                break;
                            }
                    }
                    attrsList.Add(new TagAttribute() { Name = attr, Value = value });
                }
                if (String.Equals(element.GetAttribute("name")?.ToLower(), "description"))
                    value = element.GetAttribute("Content");
                else
                    value = "";
                attrsList.Add(new TagAttribute() { Name = "Description", Value = value });
            }


            return attrsList;
        }

    }
}
