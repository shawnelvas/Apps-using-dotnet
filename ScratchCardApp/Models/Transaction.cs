using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCardApp.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public decimal TransactionAmount { get; set; }
        public Guid UserId { get; set; }
        public Guid ScratchCardId { get; set; }
    }
}