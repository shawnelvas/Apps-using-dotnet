using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesApi.Dtos;
using QuotesApi.Models;

namespace QuotesApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
        CreateMap<Quote , GetDtos>();
        CreateMap<AddDtos , Quote>();
    }
}
}