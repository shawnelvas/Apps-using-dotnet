using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Models
{
    public class Quote
    {
        public int id { get; set; }
        public string Quotes { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }

}