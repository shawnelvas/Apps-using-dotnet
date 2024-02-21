using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCardApp.Dtos.User
{
    public class UpdateUserDto
    {
         [Required]
        public string? UserEmail { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public bool IsActive { get; set; }
    }
}