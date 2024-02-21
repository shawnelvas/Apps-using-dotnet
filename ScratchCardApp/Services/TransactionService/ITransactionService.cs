using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScratchCardApp.Dtos.Transaction;

namespace ScratchCardApp.Services.TransactionService
{
    public interface ITransactionService
    {
        TransactionDto AddTransaction(CreateTransactionDto TransactionDto);
        
    }

    public class CreateTransactionDto
    {
    }
}