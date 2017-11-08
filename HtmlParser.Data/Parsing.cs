using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmlParser.Data
{
    public class Parsing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParsingID { get; set; }
        public DateTime? Date { get; set; }
        public string Url { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<HttpResponce> Responces { get; set; }

        public Parsing()
        {
            Tags = new List<Tag>();
            Responces = new List<HttpResponce>();
        }
    }
}
