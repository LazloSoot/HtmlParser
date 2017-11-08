using HtmlAgilityPack;
using HtmlParser.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Bl
{
    public class AgilityPackParser : IParser<Parsing>
    {
        public ParserSettings Settings { get; internal set; }
        HtmlDocument _document;
        StringBuilder _stringBuilder;
        public AgilityPackParser(ParserSettings settings)
        {
            Settings = settings;
            _document = new HtmlDocument();
            _stringBuilder = new StringBuilder();
        }
        public async Task<Parsing> ParseAsync(string source)
        {
            _document.LoadHtml(source);

            Parsing result = new Parsing();
            List<Tag> tags = new List<Tag>();
            
            await Task.Run(() =>
            {
                
                foreach (string tagName in Settings.Tags)
                {
                    var foundTags = _document.DocumentNode.Descendants(tagName);//.SelectNodes($"//{tagName}");

                    foreach (HtmlNode tag in foundTags)
                    {
                        if (tag.NodeType == HtmlNodeType.Element)
                        {
                            tags.Add(new Tag() { Name = tag.Name, Attributes = ParseTag(tag), Parsing = result });
                        }
                    }
                }
                result.Date = DateTime.UtcNow;
                result.Tags = tags;
            });

            return result;
        }

        List<TagAttribute> ParseTag(HtmlNode tag)
        {
            List<TagAttribute> attrsList = new List<TagAttribute>();

            if (tag == null)
                throw new ArgumentNullException("Элемент DOM не получен");

                string value = "";
                foreach (string attr in Settings.Attrs)
                {
                    switch (attr)
                    {
                        case "TagId":
                            {
                                value = tag.Id;
                                break;
                            }
                        case "Class":
                            {
                                if(tag.Attributes.Contains("class"))
                                {
                                    var classes = tag.Attributes.Where(a => a.Name == "class");
                                    _stringBuilder.Clear();

                                    foreach (var @class in classes)
                                    {
                                        _stringBuilder.Append(@class.Value + " ");
                                    }
                                    value = _stringBuilder.ToString();
                                    break;
                                }
                                value = "";
                                break;
                            }
                        case "TextContent":
                            {

                                value = tag.InnerText;
                                break;
                            }
                        default:
                            {
                                value = tag.GetAttributeValue(attr, "");
                                break;
                            }
                    }
                    attrsList.Add(new TagAttribute() { Name = attr, Value = value });
                }
                if (String.Equals(tag.GetAttributeValue("name", "")?.ToLower(), "description"))
                    value = tag.GetAttributeValue("Content", "");
                else
                    value = "";
                attrsList.Add(new TagAttribute() { Name = "Description", Value = value });

            return attrsList;
        }

        
    }
}
