using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCardApp.Dtos.User
{
    public class UserDto
    {

        public Guid Id { get; set; }
        public string? UserEmail { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
       
    }
}