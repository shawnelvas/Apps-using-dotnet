using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.ScratchCard;

namespace ScratchCardApp.Services.ScratchCardService
{
    public interface IScratchCardService
    {
        object GenerateScratchCards(int numberOfScratchCards);

        public interface IScratchCardService
    {
        IEnumerable<ScratchCardDto> GenerateScratchCards(int numberOfScratchCards);
    }
    }
}