using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmlParser.Data
{
    public class HttpResponce
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HttpResponceId { get; set; }
        public long Durration { get; set; }
        public DateTime Date { get; set; }
        public long TimeFirstByte { get; set; }
        public int StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string Content { get; set; }
        public string Headers { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public string Version { get; set; }
        public virtual int ParsingID { get; set; }
        public virtual Parsing Parsing { get; set; }
    }
}