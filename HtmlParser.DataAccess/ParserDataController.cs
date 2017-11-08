using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Data.Entity;
using HtmlParser.Data;
using HtmlParser.DataAccess.Interfaces;
using HtmlParser.DataAccess.Contexts;
using System.Threading.Tasks;

namespace HtmlParser.DataAccess
{
    public class ParserDataController : IDataController<Parsing, Tag>
    {
        IRepository<Tag> _tags;
        IRepository<TagAttribute> _attrs;
        IRepository<HttpResponce> _httpResponce;
        IRepository<Parsing> _parsing;
        static DbContext _context;

        public ParserDataController()
        {
            _context = new DefaultContext();
            Initialize();
        }

        public ParserDataController(DbContext context)
        {
            _context = context;
            Initialize();
        }

        void Initialize()
        {
            _parsing = new ParserRepository<Parsing>(_context) as IRepository<Parsing>;
            _attrs = new ParserRepository<TagAttribute>(_context) as IRepository<TagAttribute>;
            _tags = new ParserRepository<Tag>(_context) as IRepository<Tag>;
            _httpResponce = new ParserRepository<HttpResponce>(_context) as IRepository<HttpResponce>;
        }

        public async Task AddDataAsync(Parsing parsing)
        {
            await _parsing.AddAsync(parsing);
        }
        public async Task<IEnumerable<Parsing>> GetAllDataAsync()
        {
            List < Parsing > parsings = await _parsing.GetAsync() as List<Parsing>;
            List<TagAttribute> attrs = await _attrs.GetAsync() as List<TagAttribute>;
            List<Tag> tags = await _tags.GetAsync() as List<Tag>;
            List<HttpResponce> responces = await _httpResponce.GetAsync() as List<HttpResponce>;

            List<Tag> tempTags;
            List<TagAttribute> tempAttrs;

            await Task.Run(() => {
                for (int i = 0; i < parsings.Count; i++)
                {
                    tempTags = tags.Where(t => t.Parsing.ParsingID == parsings[i].ParsingID).ToList<Tag>();

                    for (int j = 0; j < tempTags.Count; j++)
                    {
                        tempAttrs = attrs.Where(a => a.Tag.TagId == tempTags[j].TagId).ToList();
                        tempTags[j].Attributes = tempAttrs;
                    }

                    parsings[i].Tags = tempTags;
                    parsings[i].Responces = responces.Where(r => r.Parsing.ParsingID == parsings[i].ParsingID).ToList();
                }
            });
            
            return parsings;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _tags.GetAsync();
        }

        public async Task<Tag> GetTagByIdAsync(long tagId)
        {
            return await _tags.FindByIdAsync(tagId);
        }

        public async Task RemoveDataAsync<TEntity>(long elementId) where TEntity : class
        {
            if(typeof(TEntity) == typeof(Tag))
            {
                Tag tag = await _tags.FindByIdAsync(elementId);
                ICollection<TagAttribute> attrs = tag.Attributes;
                await _tags.RemoveAsync(tag);
                await _attrs.RemoveRangeAsync(attrs as IEnumerable<TagAttribute>);
                ////////////////////////////////////////////////////////ОБНОВИТЬ ДАННЫЕ
                
            }else if(typeof(TEntity) == typeof(Parsing))
            {
                Parsing parsing = await _parsing.FindByIdAsync(elementId);
                ICollection<HttpResponce> httpResponces = parsing.Responces;
                ICollection<Tag> tags = parsing.Tags;
                ICollection<TagAttribute> attrs;
                foreach (var tag in tags)
                {
                    attrs = tag.Attributes;
                    await _attrs.RemoveRangeAsync(attrs as IEnumerable<TagAttribute>);
                }
                await _tags.RemoveRangeAsync(tags as IEnumerable<Tag>);
                await _httpResponce.RemoveRangeAsync(httpResponces as IEnumerable<HttpResponce>);
                await _parsing.RemoveAsync(parsing);
                ////////////////////////////////////////////////////////ОБНОВИТЬ ДАННЫЕ
            }
            else if(typeof(TEntity) == typeof(HttpResponce))
            {
                await _httpResponce.RemoveAsync(await _httpResponce.FindByIdAsync(elementId));
                ////////////////////////////////////////////////////////ОБНОВИТЬ ДАННЫЕ
            }
            else if(typeof(TEntity) == typeof(TagAttribute))
            {
                await _attrs.RemoveAsync(await _attrs.FindByIdAsync(elementId));
                ////////////////////////////////////////////////////////ОБНОВИТЬ ДАННЫЕ
            }
            else
            {
                throw new InvalidOperationException("Не поддерживаемый тип данных");
            }
        }
        
    }
}
