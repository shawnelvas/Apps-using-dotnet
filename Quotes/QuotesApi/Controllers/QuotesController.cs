using Microsoft.AspNetCore.Mvc;
using QuotesApp.Services;

namespace QuotesApp.Controllers
{
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesServices _quotesService;
      


         public QuotesController(IQuotesServices quotesService)
        {
            _quotesService = quotesService;

        }
        [HttpGet("Quotes")]
        public async Task<ServiceResponse<List<GetDtos>>> GetAllQuotes(string? quote,string? author)
        {
            return await _quotesService.GetAllQuotes(quote , author);
        }

        [HttpGet("QuotesById")]
        public async Task<ServiceResponse<GetDtos>> GetQuotesById(int id)
        {
            return await _quotesService.GetQuotesById(id);
        }

        [HttpGet("QuotesByTags")]

        public async Task<ServiceResponse<GetDtos>> GetByTags()
        {
            return await _quotesService.GetByTags();

        }

        [HttpPost("AddQuotes")]

        public async Task<ServiceResponse<GetDtos>> AddQuotes(AddDtos addQuote) 
        {
            return await _quotesService.AddQuotes(addQuote);

        }

        [HttpPut("UpdateQuotes")]

        public async Task<ServiceResponse<GetDtos>> UpdateQuote(int id, UpdateDtos updateQuote)
        {
            return await _quotesService.UpdateQuote(id,updateQuote);

        }
        
        
        [HttpDelete("DeleteQuotes")]

        public async Task<ServiceResponse<GetDtos>> DeleteQuote(int id)
        {
            return await _quotesService.DeleteQuote(id);

        }

        [HttpPatch("LikeUp")]
 
        public async Task<ServiceResponse<GetDtos>> LikeUp(int id)
        {
            return await _quotesService.LikeUp(id);
 
        }
 
        [HttpPatch("LikeDown")]
 
        public async Task<ServiceResponse<GetDtos>> LikeDown(int id)
        {
            return await _quotesService.LikeDown(id);
 
        }
 
        [HttpPatch("DislikeUp")]
 
        public async Task<ServiceResponse<GetDtos>> DislikeUp(int id)
        {
            return await _quotesService.DislikeUp(id);
 
        }
 
        [HttpPatch("DislikeDown")]
 
        public async Task<ServiceResponse<GetDtos>> DislikeDown(int id)
        {
            return await _quotesService.DislikeDown(id);
 
        }
    }
}
