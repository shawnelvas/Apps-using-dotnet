

using QuotesApp.Controllers;

namespace QuotesApp.Services
{
    public interface IQuotesServices 
    {
        Task<ServiceResponse<List<GetDtos>>> GetAllQuotes(string? quote,string? author);
        Task<ServiceResponse<GetDtos>> GetQuotesById(int id);
        Task<ServiceResponse<GetDtos>> GetByTags();
        Task<ServiceResponse<GetDtos>> AddQuotes(AddDtos addQuote) ; 
        Task<ServiceResponse<GetDtos>> UpdateQuote(int id, UpdateDtos updateQuote);
        Task<ServiceResponse<GetDtos>> DeleteQuote(int id);
        Task<ServiceResponse<GetDtos>> LikeUp(int id);
        Task<ServiceResponse<GetDtos>> LikeDown(int id);
        Task<ServiceResponse<GetDtos>> DislikeUp(int id);
        Task<ServiceResponse<GetDtos>> DislikeDown(int id);

        


        
       
    }
}