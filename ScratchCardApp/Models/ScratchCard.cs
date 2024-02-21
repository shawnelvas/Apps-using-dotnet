using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCardApp.Models
{
    public class ScratchCard
    {
        public Guid Id { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsScratched { get; set; }
        public bool IsActive { get; set; }

    }
}