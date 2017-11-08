using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmlParser.Data
{
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string Name { get; set; }
        public virtual Parsing Parsing { get; set; }
        public ICollection<TagAttribute> Attributes { get; set; }
        public Tag()
        {
            Attributes = new List<TagAttribute>();
        }
    }
}
