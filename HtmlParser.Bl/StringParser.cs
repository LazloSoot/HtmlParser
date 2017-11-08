using System;
using System.Collections.Generic;
using AngleSharp.Dom.Html;
using HtmlParser.Data;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public class StringParser : IParser<Parsing>
    {
        public ParserSettings Settings { get; set; }
        public StringParser(ParserSettings settings)
        {
            Settings = settings;
        }
        public async Task<Parsing> ParseAsync(IHtmlDocument document)
        {
            Parsing result = new Parsing();
            List<Tag> tags = new List<Tag>();
            AngleSharp.Dom.IHtmlCollection<AngleSharp.Dom.IElement> parsedTags;

            await Task.Run(() => 
            {
                foreach (string element in Settings.Tags)
                {
                    parsedTags = document?.QuerySelectorAll(element);
                    foreach (AngleSharp.Dom.IElement tag in parsedTags)
                    {
                        tags.Add(new Tag() { Name = tag.TagName, Attributes = ParseTag(tag), Parsing = result });
                    }
                }
                result.Date = DateTime.UtcNow;
                result.Tags = tags;
            });
            return result;
        }
        List<TagAttribute> ParseTag(AngleSharp.Dom.IElement element)
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
                        case "Id":
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
                        case "BaseUrl":
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
