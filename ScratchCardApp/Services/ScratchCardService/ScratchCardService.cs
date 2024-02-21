using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.ScratchCard;

namespace ScratchCardApp.Services.ScratchCardService
{
    public class ScratchCardService : IScratchCardService
    {
        public IEnumerable<ScratchCardDto> GenerateScratchCards(int numberOfScratchCards)
        {
            var scratchCards = new List<ScratchCardDto>();

            // Generate N scratch cards with random discount amount and expiry date
            for (int i = 0; i < numberOfScratchCards; i++)
            {
                var scratchCard = new ScratchCardDto
                {
                    Id = Guid.NewGuid(),
                    DiscountAmount = new Random().Next(0, 1000),
                    ExpiryDate = DateTime.Now.AddDays(5),
                    IsScratched = false,
                    IsActive = true
                };
                scratchCards.Add(scratchCard);
            }

            return scratchCards;
        }

        object IScratchCardService.GenerateScratchCards(int numberOfScratchCards)
        {
            throw new NotImplementedException();
        }
    }
}