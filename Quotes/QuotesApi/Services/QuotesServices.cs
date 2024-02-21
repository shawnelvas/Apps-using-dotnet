

namespace QuotesApp.Services
{
    public class QuotesServices : IQuotesServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
 
        public QuotesServices(IMapper mapper, DataContext context)
        {
           
            _mapper = mapper;
             _context = context;
        }
 
       public async Task<ServiceResponse<GetDtos>> AddQuotes(AddDtos addQuote)
{
    var serviceResponse = new ServiceResponse<GetDtos>();
    try
    {
        var quote = _mapper.Map<Quote>(addQuote);

        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();

      
        var addedQuoteDto = _mapper.Map<GetDtos>(quote);
        serviceResponse.Data = addedQuoteDto;

        serviceResponse.Success = true;
        serviceResponse.Message = "Quote added successfully";
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = "Error Adding Quote: " + ex.Message;
    }
    return serviceResponse;
}

 
    public async Task<ServiceResponse<List<GetDtos>>> GetAllQuotes(string? quote,string? author)
    
    {
    var serviceResponse = new ServiceResponse<List<GetDtos>>();
    
    try
    {
        
        var allQuotes = await _context.Quotes.ToListAsync();

     
        if (!string.IsNullOrEmpty(quote))
        {
            allQuotes = allQuotes
                .Where(q => q.Quotes.Contains(quote, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrEmpty(author))
        {
            allQuotes = allQuotes
                .Where(q => q.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        
        var mappedQuotes = _mapper.Map<List<GetDtos>>(allQuotes);

       
        serviceResponse.Data = mappedQuotes;
        serviceResponse.Success = true;
        serviceResponse.Message = "Quotes retrieved successfully";
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = "Error retrieving quotes: " + ex.Message;
    }

    return serviceResponse;
}


        public async Task<ServiceResponse<GetDtos>> GetQuotesById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDtos>();
            try
            {
                var dbQuotes = await _context.Quotes.FirstOrDefaultAsync(c => c.id == id);
                if (dbQuotes is null)
                {
                    serviceResponse.Success = false;
                    throw new Exception("Task not found");
                }
                serviceResponse.Data = _mapper.Map<GetDtos>(dbQuotes);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetDtos>> GetByTags()
        {
        var serviceResponse = new ServiceResponse<GetDtos>();
        try{
 
        var quotes = await _context.Quotes.ToListAsync();
 
        var allTags = quotes
            .SelectMany(q => q.Tags.Split(';'))
            .Where(tag => !string.IsNullOrEmpty(tag))
            .Distinct()
            .OrderBy(tag => tag)
            .ToList();
 
        serviceResponse.Data = new GetDtos
        {
            Tags = allTags.ToString()
        };
        return serviceResponse;
       
    }catch(Exception e){
        serviceResponse.Success=false;
        serviceResponse.Message="Tags Not Found" + e.Message;
    }
    return serviceResponse;
}


        public async Task<ServiceResponse<GetDtos>> UpdateQuote(int id, UpdateDtos updateQuote)
        {
        var serviceResponse = new ServiceResponse<GetDtos>();
 
        try
        {
         var quote = await _context.Quotes.FirstOrDefaultAsync(c=>c.id == id);
 
         if (quote == null)
         {
             serviceResponse.Success = false;
             serviceResponse.Message = $"Quote with Id:{id} not found.";
             return serviceResponse;
         }
 
         if (!string.IsNullOrEmpty(updateQuote.Quotes))
         {
             quote.Quotes = updateQuote.Quotes;
         }
 
         if (!string.IsNullOrEmpty(updateQuote.Author))
         {
             quote.Author = updateQuote.Author;
         }
 
         if (!string.IsNullOrEmpty(updateQuote.Tags))
         {
             quote.Quotes =updateQuote.Tags;
         }
 
         await _context.SaveChangesAsync();
 
         var updatedDto = _mapper.Map<GetDtos>(quote);
 
         serviceResponse.Data = updatedDto;
         serviceResponse.Success = true;
         serviceResponse.Message = "Quote updated successfully";
     }
     catch (Exception ex)
     {
         serviceResponse.Success = false;
         serviceResponse.Message = $"An error occurred: {ex.Message}";
     }
 
     return serviceResponse;
 }

 public async Task<ServiceResponse<GetDtos>> DeleteQuote(int id)
{
    {
    var serviceResponse = new ServiceResponse<GetDtos>();

    try{
        var quote=await _context.Quotes.FirstOrDefaultAsync(c=>c.id == id);
        if(quote is null)
            throw new Exception($"Task with Id:{id} Not Found.");


    _context.Quotes.Remove(quote);
    await _context.SaveChangesAsync();
    
    serviceResponse.Message=$"Task with Id:{id} Deleted.";

    }catch(Exception e){

        serviceResponse.Success=false;
        serviceResponse.Message=e.Message;
    }
    

    return serviceResponse;
    }
    
}

public async Task<ServiceResponse<GetDtos>> LikeUp(int id)
        {
            var serviceResponse = new ServiceResponse<GetDtos>();
            var quote = await _context.Quotes.FirstAsync(c => c.id == id);
            quote.Likes++;
            await _context.SaveChangesAsync();
 
            serviceResponse.Data = _mapper.Map<GetDtos>(quote);
            return serviceResponse;
        }
 
        public async Task<ServiceResponse<GetDtos>> LikeDown(int id)
        {
            var serviceResponse = new ServiceResponse<GetDtos>();
            var quote = await _context.Quotes.FirstAsync(c => c.id == id);
            if (quote.Likes < 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Cannot decrease the count";
                return serviceResponse;
            }
            quote.Likes--;
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDtos>(quote);
            return serviceResponse;
        }
 
        public async Task<ServiceResponse<GetDtos>> DislikeUp(int id)
        {
            var serviceResponse = new ServiceResponse<GetDtos>();
            var quote = await _context.Quotes.FirstAsync(c => c.id == id);
            quote.Dislikes++;
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDtos>(quote);
            return serviceResponse;
        }
 
        public async Task<ServiceResponse<GetDtos>> DislikeDown(int id)
        {
            var serviceResponse = new ServiceResponse<GetDtos>();
            var quote = await _context.Quotes.FirstAsync(c => c.id == id);
            if (quote.Dislikes < 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Cannot decrease the count";
                return serviceResponse;
            }
            quote.Dislikes--;
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDtos>(quote);
            return serviceResponse;
        }
    }
}


