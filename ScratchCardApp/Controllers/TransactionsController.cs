using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.Transaction;
using ScratchCardApp.Services.TransactionService;

namespace ScratchCardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
     private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public ActionResult<TransactionDto> AddTransaction(CreateTransactionDto createTransactionDto)
        {
            var transaction = _transactionService.AddTransaction(createTransactionDto);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionDto> GetTransactionById(Guid id)
        {
            // Implement logic to get transaction by id
            throw new NotImplementedException();
        }
    }
}