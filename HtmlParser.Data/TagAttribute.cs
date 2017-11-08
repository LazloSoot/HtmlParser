using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmlParser.Data
{
    public class TagAttribute
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagAttributeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
