using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Dtos
{
    public class UpdateDtos
    {
        public string Quotes { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public int LikeUp { get; set; } 
        public int LikeDown { get; set; }  
        public int DislikeUp { get; set; } 
        public int DislikeDown { get; set; } 

    }
}