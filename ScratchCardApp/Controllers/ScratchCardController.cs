using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.ScratchCard;
using ScratchCardApp.Services.ScratchCardService;

namespace ScratchCardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScratchCardController : ControllerBase
    {
       private readonly IScratchCardService _scratchCardService;

        public ScratchCardController(IScratchCardService scratchCardService)
        {
            _scratchCardService = scratchCardService;
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<ScratchCardDto>> GenerateScratchCards(int numberOfScratchCards)
        {
            var scratchCards = _scratchCardService.GenerateScratchCards(numberOfScratchCards);
            return Ok(scratchCards);
        }  
    }
}