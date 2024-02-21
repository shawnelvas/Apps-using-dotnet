using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.Transaction;

namespace ScratchCardApp.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {

     public TransactionDto AddTransaction(CreateTransactionDto createTransactionDto)
        {
            // Implement logic to add transaction
            throw new NotImplementedException();
        }

        TransactionDto ITransactionService.AddTransaction(CreateTransactionDto createTransactionDto)
        {
            throw new NotImplementedException();
        }

       
    }
}