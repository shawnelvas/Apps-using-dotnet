using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Dtos
{
    public class GetDtos
    {
        public int id { get; set; }
        public string Quotes { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
         public string Tags { get; set; } = string.Empty;
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}